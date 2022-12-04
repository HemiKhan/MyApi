namespace Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Dtos;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Models.ControllerModels;
using Domain.Models.ScheduleModels;
using Domain.Models.TimeZoneModels;
using Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

public class ScheduleRepository : IScheduleRepository
{
    public DbContext DbContext { get; set; }
    private readonly IQClaims _claims;
    /// <inheritdoc/>
    public ScheduleRepository(IDbContextFactory<QDbContext> dbContextFactory, IQClaims claims)
    {
        this.DbContext = dbContextFactory.CreateDbContext();
        _claims = claims;

    }

    public virtual QResult<IEnumerable<GetControllersListForDateTimeSetting>?> ControllerList(GetAllParams getAllParams, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(getAllParams.SearchValue))
            {
                var result = (
                from cdt in DbContext.Set<ControllerDateTime>()
                .Select(_ => new { _.ControllerId, _.OrganizationId })
                .Where(_ => _.OrganizationId == _claims.OrganizationId)
                join c in DbContext.Set<Controller>()
                .Select(_ => new { _.Id, _.Name, _.OrganizationId }) on cdt.ControllerId equals c.Id

                select new GetControllersListForDateTimeSetting
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .OrderBy(_ => _.Name)
               .Pagging(getAllParams.PageIndex, getAllParams.PageSize)
               .ToList();
                return result;
            }
            else
            {
                var result = (
                from cdt in DbContext.Set<ControllerDateTime>()
                .Select(_ => new { _.ControllerId, _.OrganizationId })
                .Where(_ => _.OrganizationId == _claims.OrganizationId)
                join c in DbContext.Set<Controller>()
                .Select(_ => new { _.Id, _.Name, _.OrganizationId }) on cdt.ControllerId equals c.Id

                select new GetControllersListForDateTimeSetting
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .Where(_ => _.Name!.Contains(getAllParams.SearchValue))
                .OrderBy(_ => _.Name)
               .Pagging(getAllParams.PageIndex, getAllParams.PageSize)
               .ToList();
                return result;
            }

        }
        catch (Exception ex)
        {
            return QResults.Exception<IEnumerable<GetControllersListForDateTimeSetting>?>(ex);
        }

    }
}
