using Data;
using Domain.Interfaces.Data;

namespace api
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ISaleRepository, SaleRepository>();
        }
    }
}
