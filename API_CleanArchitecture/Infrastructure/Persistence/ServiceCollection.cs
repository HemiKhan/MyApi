namespace Application;

using Infrastructure.Data;
using Persistence.Interceptors;
using SharedKernel;
using SharedKernel.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddScoped<AuditOnSavingChanges>();



        services.AddPooledDbContextFactory<QDbContext>((s, o) =>
        {
            using var scope = s.CreateScope();
            var auditOnSaveChanges = scope.ServiceProvider.GetService<AuditOnSavingChanges>();
            //if (auditOnSaveChanges is not null)
            //    o.AddInterceptors(auditOnSaveChanges);
            o.ConfigureWarnings(b =>
            {
                b.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning);
            });
            o.AddInterceptors(new LogCommandInterceptor());

            o.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")!,
                b =>
                {
                 //   b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    b.MigrationsAssembly("Persistence");
                });
        });
    }
}
