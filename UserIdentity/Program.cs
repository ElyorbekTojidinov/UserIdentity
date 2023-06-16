
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserIdentity.Data;
using UserIdentity.Models;

namespace UserIdentity
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         //  var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql("Server=localhost;Port=5432;Database=IdentityUserTest;User Id=postgres;Password=Elyorbek;");
            });

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            
            }

            //using(var scope = app.Services.CreateScope())
            //{
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //    var roles = new[] { "elyor", "admin", "user" };
            //    foreach (var item in roles)
            //    {
            //        if(!(await roleManager.RoleExistsAsync(item)))
            //            await roleManager.CreateAsync(new IdentityRole(item));
            //    }
            //}


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();



            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}