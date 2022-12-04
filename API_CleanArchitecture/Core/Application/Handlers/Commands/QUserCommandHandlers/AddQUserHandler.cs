using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.CardSpecifications;
using Domain.Dtos.ControllerDTOs;
using Domain.Dtos.QUserDtos;
using Domain.Models.AccessLevelModels;
using Domain.Models.CardModels;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.QUserCommandHandlers
{
    internal record AddQUserHandler(IRepository Repository, IQClaims QClaims) : ICommandHandler<ADD_QUser_DTO>
    {
        async Task<QResult<long?>> IRequestHandler<CommandRequest<ADD_QUser_DTO>, QResult<long?>>.Handle(CommandRequest<ADD_QUser_DTO> request, CancellationToken cancellationToken)
        {
            var qUser = QUser.Create(request.Dto);

            Serilog.Log.Verbose(Repository.DbContext.ChangeTracker.DebugView.LongView);
            var qRepositoryAddResult = await Repository.AddAsync(qUser);
            var userId = qRepositoryAddResult!.Value!.Id;
            if (request.Dto != null && request.Dto.QUserFile != null)
            {
               var qUserFile = QUserFile.Create(userId, request.Dto.QUserFile.ImageName!, request.Dto.QUserFile.ImageData!);
                var QUserFileadded = await Repository.AddAsync(qUserFile);
            }

            if (request.Dto?.Cards! != null)
            {
                List<Card> cards = new List<Card>();
                foreach (var card in request.Dto.Cards)
                {
                    if (card!.cardNumber != null)
                    {
                        var getCardByCardNumber = await Repository.FirstOrDefaultAsync(CardSpecification.GetCardByCardNumber(card.cardNumber), cancellationToken, false, false);
                        if (getCardByCardNumber.Status == Status.Exception)
                            return getCardByCardNumber.Exception!;

                        if (getCardByCardNumber.Value != null)
                            return HandlerExceptions.QUserCardExecptions.CardNumberAlreadyExist;
                    }

                    if (card.cardRaw != null)
                    {
                        var getCardBycardRaw = await Repository.FirstOrDefaultAsync(CardSpecification.GetCardByCardRaw(card.cardRaw), cancellationToken, false, false);
                        if (getCardBycardRaw.Status == Status.Exception)
                            return getCardBycardRaw.Exception!;
                        if (getCardBycardRaw.Value != null)
                            return HandlerExceptions.QUserCardExecptions.CardRawAlreadyExist;
                    }

                    cards.Add(Card.Create(card.cardNumber, card.cardRaw, card.facilityCode, card.validFrom, card.validTo, card.cardStatus, card.isAdOverride, userId));
                }

                var cardsCreated = await Repository.AddRangeAsync(cards);

                if (cardsCreated.Status == Status.Exception)
                    return cardsCreated.Exception!;
            }

            List<QUserAccessLevel> qUserAccessLevels = new List<QUserAccessLevel>();
            if (request.Dto!.QUserAccessLevels.Count() > 0)
            {
                if (request.Dto.QUserAccessLevels.Count() != request.Dto.QUserAccessLevels.Distinct().Count())
                    return HandlerExceptions.QUserAccessLevelsExecptions.SingleAccessLevelCantBeAssignedMultipleTimes;

                foreach (var item in request.Dto.QUserAccessLevels)
                {
                    qUserAccessLevels.Add(QUserAccessLevel.Create(userId, item!.AccessLevelId));
                }
            }

            var userAccessLevels = await Repository.AddRangeAsync(qUserAccessLevels);
            if (userAccessLevels.Status == Status.Exception)
            {
                return userAccessLevels.Exception!;
            }
            await Repository.SaveChangesAsync(cancellationToken);
            if (qRepositoryAddResult.Status == Status.Exception)
                return qRepositoryAddResult.Exception!;
            return qRepositoryAddResult.Value!.Id;
        }
    }
}
