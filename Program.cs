using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helpers;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection1") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();


            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("DoctorNurse", policy =>
                {
                    string[] emails = new string[] { "doctor.ca", "nurse.ca" };
                    policy.Requirements.Add(new EmailDomainRequirement(emails));
                });
            });

            builder.Services.AddSingleton<IAuthorizationHandler, EmailDomainHandler>();

            var app = builder.Build();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });
            
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    ctx.Context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                    ctx.Context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                    // Strict-Transport-Security: max-age=31536000; includeSubDomains
                    ctx.Context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");


                }

            });

            app.Use(async (context, next) => {
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must- revalidate");
                context.Response.Headers.Add("Pragma", "no-cache");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
               
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-eval'; style-src 'self' ; img-src 'self' data:; font-src 'self'; connect-src 'self'; frame-ancestors 'self'; form-action 'self'; base-uri 'self';");

                // adding header policy to remove X-Powered-By
                context.Response.Headers.Remove("X-Powered-By");
                // adding header policy for removing server
                context.Response.Headers.Remove("Server");
                // Strict -Transport-Security header
                context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");


                await next();
            });

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseHsts();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                DbInitializer.SeedRolesDoctorNurse(scope.ServiceProvider).Wait();
            }
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}