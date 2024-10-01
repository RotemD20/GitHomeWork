
using Book.API.Profiler;
using Book.BL.Interfaces;
using Book.BL.Profilers;
using Book.BL.Servises;
using Book.DAL.DataContext;
using Book.DAL.Interfaces;
using Book.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Book.API
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

            builder.Services.AddScoped<IBooksGitRepository, BooksGitRepository>();
            builder.Services.AddScoped<IBookGitService, BookGitService>();



            builder.Services.AddDbContext <BooksContext> (options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
            });

            builder.Services.AddAutoMapper(typeof(BookProfiler).Assembly);
            builder.Services.AddAutoMapper(typeof(BookProfilerApi).Assembly);


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
