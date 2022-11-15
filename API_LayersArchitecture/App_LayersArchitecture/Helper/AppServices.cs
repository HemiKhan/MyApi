using Services.Account;
using Services.Mail;
using Services.Portfolio;
using Services.Seed;
using Services.StoredProcedures;

namespace App_LayersArchitecture.Helper
{
    public static class AppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection appservices)
        {
            appservices.AddTransient<IPortfolioServices, PortfolioServices>();
            appservices.AddTransient<IStoredProcedureService, StoredProcedureService>();
            appservices.AddTransient<IAccountService, AccountService>();
            appservices.AddTransient<ISeedService, SeedService>();
            appservices.AddTransient<IMailService, MailService>();
            appservices.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            return appservices;
        }
    }
}
