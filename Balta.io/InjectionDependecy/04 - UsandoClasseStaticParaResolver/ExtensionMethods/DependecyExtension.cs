using _02___Resolvendo.Repository;
using _02___Resolvendo.Repository.Contracts;
using _02___Resolvendo.Services;
using _02___Resolvendo.Services.Contracts;
using System.Data.SqlClient;

namespace _04___UsandoClasseStaticParaResolver.ExtensionMethods
{
    public static class DependecyExtension
    {
        public static void AddSqlConnection(this IServiceCollection services, string connectionString)
        {
            services.AddScoped(x=> new SqlConnection(connectionString));
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
        }
    }
}
