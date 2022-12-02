using Authorization.Domain;
using AuthorizationService.IdentityServerConfig;
using IdentityServer4.Models;
using MediatR;
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

            builder.Services.AddIdentityServer()
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                .AddInMemoryApiResources(new List<ApiResource>())
                .AddTestUsers(IdentityServerConfiguration.GetTestUsers())
                .AddDeveloperSigningCredential();

            builder.Services.AddDbContext<RepositoryContext>(
                options =>
                options.UseSqlServer(connectionString,
                x => x.MigrationsAssembly("AuthorizationService")));

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