using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Shared
{
    public static class NorthwindContextExtensions
    {
        // zie boek blz 551
        public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string connecttionstring = "Data Source=.;Initial Catalog=NorthwindData;Integrated Security=True;TrustServerCertificate=True;")
        {
            services.AddDbContext<NorthwindDataContext>(options =>
            {
                options.UseSqlServer(connecttionstring);
                //  options.LogTo(WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
            });
            return services;
        }
    }
}
