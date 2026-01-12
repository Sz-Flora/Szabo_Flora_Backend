
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Szabo_Flora_backend.Models;
using Szabo_Flora_backend.Services;
using Szabo_Flora_backend.Services.Iservices;

namespace Szabo_Flora_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CinemadbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MySQL");
                options.UseMySQL(connectionString);
            });

            builder.Services.AddScoped<IActor, ActorService>();
            builder.Services.AddScoped<IMovie, MovieService>();
            builder.Services.AddScoped<IFilmType, FilmTypeService>();

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
