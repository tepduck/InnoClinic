using Authorization.Domain;
using Authorization.Domain.Models;
using AuthorizationService.IdentityServerConfig;
using IdentityServer4.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthorizationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services
            var connectionString = builder.Configuration.GetConnectionString("sqlConnection");

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AddDbContext<RepositoryContext>(
                options =>
                options.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("AuthorizationService")));

            builder.Services.AddIdentity<Account, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 8;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddIdentityServer()
                .AddAspNetIdentity<Account>()
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                .AddInMemoryApiResources(new List<ApiResource>())
                .AddDeveloperSigningCredential();

            builder.Services.ConfigureApplicationCookie(config => 
            {
                config.Cookie.Name = "IdentityCookie";
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
            });

            builder.Services.AddControllers();

            #endregion

            var app = builder.Build();

            #region Middlewares/pipeline

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();

            #endregion

        }
    }
}