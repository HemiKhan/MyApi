using System.Text.Json.Serialization;
using App_CleanArchitecture.Helpers;
using Application;
using Infrastructure.Data;
using AutoWrapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(((ctx, lc) =>
{
    lc.WriteTo.Console();
    lc.ReadFrom.Configuration(ctx.Configuration);
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);


builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(allowIntegerValues: true));
    options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement;
});



//Add CORS Policy

builder.Services.AddCors(options => options.AddPolicy(
                 Config.DefaultCorsPolicyName,
                  x => x.WithOrigins(builder.Configuration["App:CorsOrigins"]!
                  .Split(",", StringSplitOptions.RemoveEmptyEntries)
                  .Select(o => o.RemoveFromEnd("/")).ToArray())
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials()));


builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.ClaimsIssuer = "http://192.168.1.200:9800";
    options.RequireHttpsMetadata = false;
    options.Authority = builder.Configuration["App:Authority"];

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = "App_CleanArchitecture"
    };
});

builder.Services.AddSwaggerGen(options =>
{

    options.TagActionsBy(api =>
    {
        if (api.GroupName != null)
        {
            return new[] { api.GroupName };
        }

        var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
        if (controllerActionDescriptor != null)
        {
            return new[] { controllerActionDescriptor.ControllerName };
        }

        throw new InvalidOperationException("Unable to determine tag for endpoint.");
    });
    options.DocInclusionPredicate((name, api) => true);

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API - CleanArchitecture",
        Description = Config.GitHubBranch
    });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token * *_only_ * *",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme, // must be lower case
        BearerFormat = "JWT",
        Flows = new OpenApiOAuthFlows
        {
            //Implicit = new OpenApiOAuthFlow
            //{
            //    AuthorizationUrl = new Uri("http://192.168.1.200:9800/connect/token"),
            //}
        },
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
{
{securityScheme, new string[] { }}
});
});

//ignore pascal case by default
builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
}).AddDataAnnotationsLocalization(o =>
{
    o.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(Program));
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});






var app = builder.Build();



if (Config.DoMigrate)
{
    using var s = app.Services.CreateScope();
    var dbContextFactory = s.ServiceProvider.GetService<IDbContextFactory<QDbContext>>();
    var db = await dbContextFactory!.CreateDbContextAsync();
    await db.Database.MigrateAsync();
}



app.UseApiResponseAndExceptionWrapper<MapResponseObject>(new AutoWrapperOptions
{
    IsDebug = true,
    ShowApiVersion = true,
    IsApiOnly = false,
    ApiVersion = Config.ApiVersion,
    WrapWhenApiPathStartsWith = "/api"
});


//CORS
app.UseCors(Config.DefaultCorsPolicyName);


// Configure the HTTP request pipeline.
//Change this line in production
app.UseSwagger();


app.UseSwaggerUI(options =>
{
    options.DocExpansion(DocExpansion.None);
    options.DefaultModelExpandDepth(-1);

});

//app.UseHttpsRedirection();


app.MapControllers().AllowAnonymous();
//if (app.Environment.IsDevelopment())
//else
//app.MapControllers();



app.Run();

