namespace Application;
using System;

using Application.Handlers;
using Application.Handlers.Commands.AreaCommandHandlers;
using Application.Handlers.Commands.AccessLevelCommands;
using Application.Handlers.Commands.CardFormatCommandHandlers;
using Application.Handlers.Commands.ControllerCommandHandlers.DoorCommandHandlers;
using Application.Handlers.ControllerHandlers.Commands.Controller;
using Application.Handlers.ControllerHandlers.Commands.ControllerCommands;
using Application.Handlers.PrioritiesHandler.Commands;
using Application.Handlers.PrioritiesHandler.Queries;
using Application.Handlers.Queries.AreaQueriesHandlers;
using Application.Handlers.Queries.AccessLevelQueryHandlers;
using Application.Handlers.Queries.CardFormatQueriesHandlers;
using Application.Handlers.Queries.ControllerQueriesHanlders;
using Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers;
using Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers.RexQueryHandlers;
using Application.Handlers.ScheduleHandlers.Commands;
using Application.Handlers.ScheduleHandlers.ScheduleItemHandlers.Commands;
using Application.Interfaces;
using Domain.Dtos;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.ControllerDTOs;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Dtos.Door;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Dtos.Schedule.ScheduleItemsDtos;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Dtos.QUserDtos;
using Application.Handlers.Commands.QUserCommandHandlers;
using Domain.Dtos.OutputSensorDTOs;
using Application.Handlers.Queries.OutputSensorHandlers;
using Domain.Models.OutputSensorModel;
using System.Collections.Generic;
using Domain.Dtos.DoorGroupDtos;
using Application.Handlers.Commands.DoorGroupCommandHandlers;
using Application.Handlers.Queries.DoorGroupQueryHandler;
using Domain.Dtos.ManualControlDtos;
using Application.Handlers.Queries.ManualControlQueryHandlers;
using Domain.Dtos.AccessConfigDTOs;
using Application.Handlers.Commands.AccessConfigCommands;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Application.Handlers.Queries.AccessConfigsQueryHandlers;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringsOption>(configuration.GetSection(ConnectionStringsOption.SectionName));
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddTransient<IQClaims, QClaims>();
        services.AddScoped<IQSender, QSender>();
        services.AddScoped<IDbConnection, DBConnection>();




        //services.AddEventStoreClient(configuration.GetValue<string>("EventStore:ConnectionString")!, _ =>
        //{
        //    _.CreateHttpMessageHandler = () => new SocketsHttpHandler
        //    {
        //        SslOptions = {
        //    RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true,
        //}
        //    };
        //});

        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAll_Controller_DTO>, QResult<IEnumerable<GetAll_Controller_DTO>?>>, Controller_GetAll_Handler>();
        //  services.AddTransient<IRequestHandler<QueryRequest<long, Get_ControllerDTO>, QResult<Get_ControllerDTO?>>, GetByIdControllerHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<AddControllerCommand>, QResult<long?>>, AddControllerHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<Update_ControllerDTO>, QResult<long?>>, UpdateControllerHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<Delete_ControllerDTO>, QResult<long?>>, DeleteControllerHandler>();


        // Door handlers
        services.AddTransient<IRequestHandler<CommandRequest<Door_Add_DTO>, QResult<long?>>, AddDoorHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<Door_GetById_DTO>, QResult<long?>>, UpdateDoorHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<DeleteDoorDTO>, QResult<long?>>, DeleteDoorHandler>();
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAllDoorsDTO>, QResult<IEnumerable<GetAllDoorsDTO>?>>, GetAllDoorsHandler>();
        services.AddTransient<IRequestHandler<QueryRequest<long, Door_GetById_DTO>, QResult<Door_GetById_DTO?>>, GetByIdDoorHandler>();

        // Reader handlers
        //services.AddTransient<IRequestHandler<CommandRequest<AddReaderDTO>, QResult<long?>>, AddReaderHandler>();
        //services.AddTransient<IRequestHandler<CommandRequest<UpdateReaderDTO>, QResult<long?>>, UpdateReaderHandler>();
        //services.AddTransient<IRequestHandler<CommandRequest<DeleteReaderDTO>, QResult<long?>>, DeleteReaderHandler>();
        //services.AddTransient<IRequestHandler<GetAllQueryRequest<Reader_GetById_DTO>, QResult<List<Reader_GetById_DTO>?>>, GetAllReaderHandler>();
        //services.AddTransient<IRequestHandler<QueryRequest<long, Reader_GetById_DTO>, QResult<Reader_GetById_DTO?>>, GetByIdReaderHandler>();

        // Rex handlers
        services.AddTransient<IRequestHandler<GetAllQueryRequest<Rex_GetById_DTO>, QResult<IEnumerable<Rex_GetById_DTO>?>>, GetAllRexHandler>();
        services.AddTransient<IRequestHandler<QueryRequest<long, Rex_GetById_DTO>, QResult<Rex_GetById_DTO?>>, GetByIdRexHandler>();


        //SCHEDULE
        services.AddTransient<IRequestHandler<CommandRequest<AddScheduleDTO>, QResult<long?>>, AddScheduleHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<DeleteScheduleDTO>, QResult<long?>>, DeleteScheduleHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<UpdateScheduleDTO>, QResult<long?>>, UpdateScheduleHandler>();

        // S ITEMS
        services.AddTransient<IRequestHandler<CommandRequest<DeleteScheduleItemDto>, QResult<long?>>, DeleteScheduleItemHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<ScheduleItems_AddUpDate_Request>, QResult<long?>>, AddScheduleItemHandler>();

        // services.AddTransient<IRequestHandler<QueryRequest<ControllerDateTimeSetting, List<GetControllersListForDateTimeSetting>>, QResult<List<GetControllersListForDateTimeSetting>?>>, GetControllerListHandler>();

        // Priorities
        services.AddTransient<IRequestHandler<CommandRequest<AddPriorityDTO>, QResult<long?>>, AddPriorityHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<Update_PriorityDTO>, QResult<long?>>, UpdatePriorityHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<DeletePriorityDTO>, QResult<long?>>, DeletePriorityHandler>();
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAllPrioritiesDTOScroll>, QResult<IEnumerable<GetAllPrioritiesDTOScroll>?>>, GetAllPriorityHandler>();
        services.AddTransient<IRequestHandler<QueryRequest<long, GetByIdPrioritiesDTO>, QResult<GetByIdPrioritiesDTO?>>, GetByIdPriorityHandler>();

        //CARDFORMATS
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAllCardFormatsDto>, QResult<IEnumerable<GetAllCardFormatsDto>?>>, GetAllCardFormatsHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<UpdateCardFormatDto>, QResult<long?>>, UpdateCardFormatHandler>();
        services.AddTransient<IRequestHandler<QueryRequest<long, GetByIdCardFormatDto>, QResult<GetByIdCardFormatDto?>>, GetByIdCardFormatHandler>();

        // AREA
        services.AddTransient<IRequestHandler<CommandRequest<AddAreaDto>, QResult<long?>>, AddAreaCommandHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<UpdateAreaDto>, QResult<long?>>, UpdateAreaCommandHandler>();
        services.AddTransient<IRequestHandler<QueryRequest<long, GetAreaByIdDto>, QResult<GetAreaByIdDto?>>, GetAreaByIdHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<long>, QResult<long?>>, DeleteAreaCommandHandler>();
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAllAreasDto>, QResult<IEnumerable<GetAllAreasDto>?>>, GetAllAreaHandler>();



        //Access Levels
        services.AddTransient<IRequestHandler<CommandRequest<Add_AccessLevel_DTO>, QResult<long?>>, AddAccessLevelHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<Update_AccessLevel_DTO>, QResult<long?>>, UpdateAccesLevelHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<Delete_AccessLevel_DTO>, QResult<long?>>, DeleteAccessLevelHandler>();
        services.AddTransient<IRequestHandler<QueryRequest<long, GetById_AccessLevel_DTO>, QResult<GetById_AccessLevel_DTO?>>, GetByIdAccessLevelHandler>();
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAll_AccessLevel_DTO>, QResult<IEnumerable<GetAll_AccessLevel_DTO>?>>, GetAllAccessLevelHandler>();

        // OUTPUT SENSOR
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAll_Controllers_Dto>, QResult<IEnumerable<GetAll_Controllers_Dto>?>>, GetAllControllersHandler>();
        //services.AddTransient<IRequestHandler<QueryRequest<long,IEnumerable<IOModel>, QResult<IEnumerable<IOModel>?>>, GetAllOutputSenserHanlder>();
        services.AddTransient<IRequestHandler<QueryRequest<long, IEnumerable<IOModel>>, QResult<IEnumerable<IOModel>?>>, GetAllOutputSenserHanlder>();

        // DoorGroup
        services.AddTransient<IRequestHandler<CommandRequest<AddDoorGroupDto>, QResult<long?>>, AddDoorGroupHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<UpdateDoorGroupDto>, QResult<long?>>, UpdateDoorGroupHandler>();

        services.AddTransient<IRequestHandler<QueryRequest<long, GetByIdDoorGroupDto>, QResult<GetByIdDoorGroupDto?>>, GetByIdDoorGroupHandler>();
        services.AddTransient<IRequestHandler<CommandRequest<long, long>, QResult<long>>, DeleteDoorGroupHandler>();
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetAllDoorGroupDto>, QResult<IEnumerable<GetAllDoorGroupDto>?>>, GetAllDoorGroupHandler>();


        services.AddTransient<IRequestHandler<QueryRequest<long, GetDoorDetailsByIdDtoForManualControl>, QResult<GetDoorDetailsByIdDtoForManualControl?>>, GetDoorDetailsByIdHandler>();


        //QUserCards
        services.AddTransient<IRequestHandler<CommandRequest<Delete_QUserCard_DTO>, QResult<long?>>, DeleteQUserCardHandler>();


        //Access Configs

        services.AddTransient<IRequestHandler<CommandRequest<UpdateAccessConfigDTO>, QResult<long?>>, UpdateAccessConfigHandler>();
        services.AddTransient<IRequestHandler<QueryRequest<GetByConfigKey_AccessConfig_Request, GetByConfigKey_AccessConfigsDTO>, QResult<GetByConfigKey_AccessConfigsDTO?>>, GetByConfigKeyHandler>();
        services.AddTransient<IRequestHandler<GetAllQueryRequest<GetByParentIdAccessConfigsDTO>, QResult<IEnumerable<GetByParentIdAccessConfigsDTO>?>>,GetByParentIdAccessConfigHandler>();

    }
}
