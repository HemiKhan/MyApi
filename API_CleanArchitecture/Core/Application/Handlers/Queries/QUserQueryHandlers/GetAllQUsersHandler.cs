using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.Door;
using Domain.Dtos.QUserDtos;
using Domain.Models.CardFormatsModels;
using Domain.Models.QUserModels;
using Domain.Models.ScheduleModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Queries.QUserQueryHandlers
{
    public record GetAllQUsersHandler(IRepository Repository, IQClaims claims) : IGetAllQueryHandler<GetAll_QUser_DTO>
    {
        public async Task<QResult<IEnumerable<GetAll_QUser_DTO>?>> Handle(GetAllQueryRequest<GetAll_QUser_DTO> request, CancellationToken cancellationToken)
        {
            var spec = new GenericQSpec<QUser, GetAll_QUser_DTO>()
            {
                SpecificationFunc = _ => _.OrderBy(_ => _.FirstName).Select(_ => new GetAll_QUser_DTO(_.Id, _.FirstName + " " + _.LastName))
                .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
            };


            var specWithSearch = new GenericQSpec<QUser, GetAll_QUser_DTO>()
            {
                SpecificationFunc = _ => _.Where(_ => _.FirstName.ToLower().Contains(request.GetAllParams.SearchValue!.ToLower()) ||
                                    _.LastName.ToLower().Contains(request.GetAllParams.SearchValue!.ToLower())).OrderBy(p => p.FirstName)
                                    .Select(_ => new GetAll_QUser_DTO(_.Id, _.FirstName + " " + _.LastName))
                                    .Pagging(request.GetAllParams.PageIndex, request.GetAllParams.PageSize)
            };



            var response = await Repository.
                GetAllAsync(!string.IsNullOrEmpty(request.GetAllParams.SearchValue) ? specWithSearch : spec, cancellationToken, true, false);

            if (response.Status is Status.Exception)
                return response.Exception!;
            return QResults.From(response.Value);
        }
    }
}
