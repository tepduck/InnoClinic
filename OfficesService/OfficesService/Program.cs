using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OfficesService.Domain;
using OfficesService.Domain.Interfaces;
using OfficesService.ServiceExtensions;

namespace OfficesService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<OfficeDatabaseSettings>(
                builder.Configuration.GetSection(nameof(OfficeDatabaseSettings)));

            builder.Services.AddSingleton<IOfficeDatabaseSettings>(provider => 
                provider.GetRequiredService<IOptions<OfficeDatabaseSettings>>().Value);
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            builder.Services.ConfigureSwagger();
            builder.Services.AddSwaggerGen(s =>
            {
                s.IncludeXmlComments("swagger.xml");
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
            app.UseAuthorization();

            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}