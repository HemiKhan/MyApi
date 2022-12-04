using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.AccessLevelSpecifications;
using Application.Specifications.CardSpecifications;
using Domain.Dtos.ControllerDTOs;
using Domain.Dtos.Door;
using Domain.Dtos.QUserDtos;
using Domain.Models.QUserModels;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.QUserCommandHandlers
{
    public record UpdateQUserHandler(IRepository Repository, IQClaims claims) : ICommandHandler<Update_QUser_DTO>
    {
        public async Task<QResult<long?>> Handle(CommandRequest<Update_QUser_DTO> request, CancellationToken cancellationToken)
        {
            var hasException = await Repository.FirstOrDefaultAsync(
                     Specifications.Specs.QUserSpecs.GetQUser(request.Dto.Id),
                      cancellationToken, false, false);

            if (hasException.Status == Status.Exception)
                return hasException.Exception!;

            try
            {
                var qUser = hasException.Value!;
                await Repository.EnableChangeTracker(qUser);
                // check validation for card number and card row
                foreach (var card in request.Dto.Cards)
                {
                    if (card!.cardNumber != null)
                    {
                        var getCardByCardNumber = await Repository.FirstOrDefaultAsync(CardSpecification.GetCardValidationData(card.cardNumber,null), cancellationToken, false, false);
                        if (getCardByCardNumber.Status == Status.Exception)
                            return getCardByCardNumber.Exception!;
                        if (getCardByCardNumber.Value != null)
                        {
                            if (getCardByCardNumber.Value.Id != card.Id && getCardByCardNumber.Value.CardNumber == card.cardNumber)
                            return HandlerExceptions.QUserCardExecptions.CardNumberAlreadyExist;
                        }
                        
                    }
                    if (card.cardRaw != null)
                    {
                        var getCardBycardRaw = await Repository.FirstOrDefaultAsync(CardSpecification.GetCardValidationData(null,card.cardRaw), cancellationToken, false, false);
                        if (getCardBycardRaw.Status == Status.Exception)
                            return getCardBycardRaw.Exception!;

                        if (getCardBycardRaw.Value != null)
                        { 
                            if (getCardBycardRaw.Value.Id != card.Id && getCardBycardRaw.Value.CardRaw == card.cardRaw)
                            return HandlerExceptions.QUserCardExecptions.CardRawAlreadyExist;
                        }
                    }
                }

                var qUserAccesLevels = await Repository.GetAllAsync(AccessLevelSpecification.GetAllQUserAccessLevelsByUserId(request.Dto.Id), cancellationToken, false, false);
                if(qUserAccesLevels.Status == Status.Exception)
                    return qUserAccesLevels.Exception!;

                foreach (var ual in request.Dto.QUserAccessLevels)
                {
                    var existingAccessLevel = qUserAccesLevels.Value.Where(x=>x.AccessLevelId == ual.AccessLevelId).FirstOrDefault();
                    if (existingAccessLevel != null)
                    {
                        if (existingAccessLevel.Id != ual.Id)
                        {
                            return HandlerExceptions.QUserAccessLevelsExecptions.SingleAccessLevelCantBeAssignedMultipleTimes;
                        }
                    }
                }

                var GetQUserFileByUserId = await Repository.FirstOrDefaultAsync(QUserFileSpecification.GetQUserFileByQUserId(request.Dto.Id));
                if (GetQUserFileByUserId.Value == null && request.Dto.QUserFile != null)
                {
                    var qUserFile = QUserFile.Create(request.Dto.Id, request.Dto.QUserFile.ImageName!, request.Dto.QUserFile.ImageData!);
                    var QUserFileadded = await Repository.AddAsync(qUserFile);
                }

                qUser.Update(request.Dto);

                var qUserUpdateResult = await Repository.SaveChangesAsync();

                if (qUserUpdateResult.Status is Status.Exception)
                    return qUserUpdateResult.Exception!;

                return qUserUpdateResult.Status is Status.Exception ? qUserUpdateResult.Exception! : qUser.Id;
            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();

        }
    }
}
