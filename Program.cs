﻿
using LABMedicine.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace LABMedicine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connectionString = "Server=DESKTOP-DA6EN1S\\SQLEXPRESS;Database=labmedicinebd;Trusted_Connection=True;TrustServerCertificate=True;";
            //Inje��o de Depencencia do Context
            builder.Services.AddDbContext<BancoDadosContext>(o => o.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}