
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace WebApp.Data
{
    public static class DbInitializer
    {

        public static async Task<int> SeedRolesDoctorNurse(IServiceProvider serviceProvider)
        {
            // create the database if it doesn't exist
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Check if roles already exist and exit if there are
            if (roleManager.Roles.Count() > 0)
                return 1;  // should log an error message here

            // Seed roles
            int result = await SeedRoles(roleManager);
            if (result != 0)
                return 2;  // should log an error message here

            return 0;
        }

        private static async Task<int> SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Create Doctor Role
            var result = await roleManager.CreateAsync(new IdentityRole("Doctor"));
            if (!result.Succeeded)
                return 1;

            // Create Nurse Role
            result = await roleManager.CreateAsync(new IdentityRole("Nurse"));
            if (!result.Succeeded)
                return 2;

            return 0;
        }
    }
}
