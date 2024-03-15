
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using YoshiTaskWarehouseLukaszKierzek.Server.Data;
using YoshiTaskWarehouseLukaszKierzek.Server.Services.Implementations;
using YoshiTaskWarehouseLukaszKierzek.Server.Services.Interfaces;

namespace YoshiTaskWarehouseLukaszKierzek.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            }
            );
            builder.Services.AddDbContext<WarehouseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase"))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
            }
            );

            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options =>
                options.WithOrigins("https://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
