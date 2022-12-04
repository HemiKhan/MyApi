using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Dtos.CardDtos;
using Domain.Dtos.Door;
using Domain.Dtos.QUserDtos;
using Domain.Dtos.QUserDtos.QUserFileDTOs;
using Domain.Models.QUserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Queries.QUserQueryHandlers
{
    public record GetByIdQUserHandler(IRepository Repository) : IQueryHandler<long, GetById_QUser_DTO>
    {

        public async Task<QResult<GetById_QUser_DTO?>> Handle(QueryRequest<long, GetById_QUser_DTO> request, CancellationToken cancellationToken)
        {
            var getByIdSpec = new GenericQSpec<QUser, GetById_QUser_DTO>()
            {
                SpecificationFunc = _ => _.Where(_ => _.Id == request.Request)
                .Include(_ => _.QUserFiles)
                .Include(_ => _.QUserAccessLevels)
                .Include(_ => _.Cards)
                .Select(o => new GetById_QUser_DTO(
                   o.Id,
                  o.FirstName,
                  o.LastName,
                  o.MiddleName,
                  o.EmployeeId,
                  o.DepartmentName,
                  o.CompanyName,
                  o.Gender,
                  o.LastUse,
                  o.LastArea,
                  o.LastLocation,
                  o.Nationality,
                  o.Email,
                  o.QUserType,
                  o.Phone,
                  o.Cards.Select(c => new Get_Card_DTO(
                        c.Id,
                        c.CardNumber,
                           c.CardRaw,
                           c.FacilityCode,
                           c.ValidFrom,
                           c.ValidTo,
                           c.CardStatus,
                           c.IsAdOverride,
                           c.QUserId
                  )).ToList(),
                  o.QUserAccessLevels.Select(a => new Get_QUserAccessLevels_DTO(a.Id,a.AccessLevelId, a.QUserId)).ToList(),
                  new Get_QUserFile_DTO(
                      o.QUserFiles.Id,
                      o.QUserFiles.ImageName,
                      o.QUserFiles.ImageData)

                    ))
            };

            var getQUser = await Repository.FirstOrDefaultAsync(getByIdSpec, cancellationToken);
            if (getQUser.Status is Status.Exception)
                return getQUser.Exception!;


            return getQUser;
        }
    }
}
