using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class RolesController : Controller
    {
        private string adminRole = "Administrators";
        private string userEmail = "test@cilissen.nl";
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RolesController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager) //Dependancy injection!
        {
            this.roleManager = _roleManager;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!(await roleManager.RoleExistsAsync(adminRole)))
            {
                // maak de adminrole indien deze niet bestaat
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }
            // haal de user op
            IdentityUser? user = await userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                user = new();
                user.UserName = userEmail;
                user.Email = userEmail;

                IdentityResult result = await userManager.CreateAsync(user, "Pa$$w0rd");

                if (result.Succeeded)
                {
                    await Console.Out.WriteLineAsync($"USer {user.UserName} created!");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        await Console.Out.WriteLineAsync(error.Description);
                    }
                }
            }

            if (!user.EmailConfirmed)             
            {
                string token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    await Console.Out.WriteLineAsync($"User {user.UserName} email confirmed succesfully.");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        await Console.Out.WriteLineAsync(error.Description);
                    }
                }
            }

            if (!(await userManager.IsInRoleAsync(user, adminRole)))
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, adminRole);
                if (result.Succeeded)
                {
                    await Console.Out.WriteLineAsync($"User {user.UserName} added to admin role succesfully.");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        await Console.Out.WriteLineAsync(error.Description);
                    }
                }

            }
            return Redirect("/");
        }
    }
}
