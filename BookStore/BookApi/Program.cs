using BookApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BookApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<BookContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Swagger services (if in development mode)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            /* Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            */
            app.UseDeveloperExceptionPage();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Explicitly tell the app to listen on all network interfaces
            app.Run("http://0.0.0.0:5000"); // Set your desired port here (5000 is common for APIs)

        }
    }
}
