// sectie 1: Namespaces
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Shared;

namespace Northwind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // sectie 2: configure host web server en services
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            // DIT IS EEN VOORBEELD VAN EEN DEPENDENCY SERVICE (Dependency injection): 
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // ENABLE ROLE MANAGEMENT!
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            string? sqlServerConnection = builder.Configuration.GetConnectionString("NorthwindConnection");
            if (String.IsNullOrEmpty(sqlServerConnection))
            {
                Console.WriteLine("SQL server connection string is missing!");
            }
            else
            {
                // hier roep je de extension method aan!
                builder.Services.AddNorthwindContext(sqlServerConnection);
            }

            var app = builder.Build();


            // sectie 3:
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            // sectie 4: starten van de applicatie
            app.Run();
        }
    }
}