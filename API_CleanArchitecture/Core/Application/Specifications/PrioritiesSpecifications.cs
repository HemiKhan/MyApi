namespace Application.Specifications;

using Application.Handlers;
using Application.Interfaces;
using Application.Specifications.Base;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Models.PrioritiesModels;
using System.Linq;

internal static partial class Specs
{
    internal static class PrioritiesSpecs
    {
        
        internal static GenericQSpec<Priority, string> CheckNameAlreadyExists(string Name)
        {
            return new()
            {
                SpecificationFunc = _ => _.Select(x => x.Name!).Where(o => o.ToLower() == Name.ToLower())
            };
        }

        internal static GenericQSpec<Priority, object> CheckNameAlreadyExists(string? Name, long? id)

        {
            return new()
            {
                SpecificationFunc = _ => _.Select(x => new { x.Name, x.Id }).Where(o => o.Name == Name.ToLower() && o.Id != id)
            };
        }

        internal static GenericQSpec<Priority, int?> CheckPriorityLevelAlreadyExists(int? PriorityLevel)
        {
            return new()
            {
                SpecificationFunc = _ => _.Select(x => x.PriorityLevel).Where(o => o == PriorityLevel)
            };
        }

        internal static GenericQSpec<Priority, object?> CheckPriorityLevelAlreadyExists(int? PriorityLevel, long? id)
        {
            return new()
            {
                SpecificationFunc = _ => _.Select(x => new { x.PriorityLevel, x.Id }).Where(o => o.PriorityLevel == PriorityLevel && o.Id != id)
            };
        }

        internal static GenericQSpec<Priority, object?> CheckPriorityExistOrNot(long? id)
        {
            return new()
            {
                SpecificationFunc = _ => _.Select(x => new { x.Id, x.Name, x.PriorityLevel, x.ColorCode }).Where(_ => _.Id == id)
            };
        }

        internal static GetAllSpec<Priority, GetAllPrioritiesDTOScroll> GetAllPrioritiesSpecs(GetAllParams GetAllParams,long OrgId)
        {
            return new GetAllSpec<Priority, GetAllPrioritiesDTOScroll>()
            {
                IgnoreQueryFilter = true,
                SearchValue = GetAllParams.SearchValue,
                PageNumber = GetAllParams.PageIndex,
                PageSize = GetAllParams.PageSize,
                WhereExpression = _=> _.OrganizationId == -1 || _.OrganizationId == OrgId,
                SearchExpression = _ => _ .Name!.ToLower().Contains(GetAllParams.SearchValue!.ToLower()),
                SelectExpression = _ => new GetAllPrioritiesDTOScroll() { Id = _.Id, Name = _.Name},
                OrderByDescending = _ => _.PriorityLevel!
            };
        }

    }
}
