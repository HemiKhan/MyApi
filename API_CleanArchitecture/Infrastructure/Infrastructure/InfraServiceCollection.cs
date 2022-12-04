namespace Application;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.Services.AccessConfig;
using Application.Interfaces.Services.AccessLevelServices;
using Application.Interfaces.Services.CardFormatServices;
using Application.Interfaces.Services.ControllerDateTimeSettingServices;
using Application.Interfaces.Services.DoorServices;
using Application.Interfaces.Services.PrioritiesServices;
using Application.Interfaces.Services.QUserServices;
using Application.Interfaces.Services.ReaderServices;
using Application.Interfaces.Services.ScheduleServices;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Infrastructure.Services;
using Infrastructure.Services.AccessConfigsServices;
using Infrastructure.Services.AccesslevelServices;
using Infrastructure.Services.CardFormatServices;
using Infrastructure.Services.ControllerDateTimeSettingServices;
using Infrastructure.Services.ControllerServices;
using Infrastructure.Services.DoorServices;
using Infrastructure.Services.PrioritiesServices;
using Infrastructure.Services.QUserServices;
using Infrastructure.Services.ReaderServices;
using Infrastructure.Services.ScheduleServices;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        //REPOSITORIES
        services.AddScoped(typeof(IRepository), typeof(Repository));
        services.AddTransient<IDapperRepository, DapperRepository>();
        services.AddScoped<IScheduleRepository, ScheduleRepository>();

        // SERVICES
        services.AddScoped<IControllerService, ControllerService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<IScheduleItemService, ScheduleItemService>();

        services.AddScoped<IDoorService, DoorService>();
        services.AddScoped<IDoorAdvanceConfigurationService, DoorAdvanceConfigurationService>();
        services.AddScoped<IReaderService, ReaderService>();

        services.AddScoped<IControllerDateTimeSettingService, ControllerDateTimeSettingService>();
        services.AddScoped<IPrioritiesServices, PrioritiesServices>();
        services.AddScoped<ICardFormatService, CardFormatService>();

        services.AddScoped<IQUserServices, QUserServices>();
        services.AddScoped<IAreaService, AreaService>();
        services.AddScoped<IAccessLevelService, AccessLevelService>();
        services.AddScoped<IOutputSensorService, OutputSensorService>();
        services.AddScoped<IDoorGroupService, DoorGroupService>();
        services.AddScoped<IManualControlService, ManualControlService>();
        services.AddScoped<IAccessConfigService, AccessConfigService>();
    }
}
