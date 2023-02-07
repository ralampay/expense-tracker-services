using Microsoft.EntityFrameworkCore;
using ExpenseTrackerServices.Interfaces;
using ExpenseTrackerServices.Services;
using ExpenseTrackerServices.Data;

namespace ExpenseTrackerServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            var corsConfigName = "CORS-Config";

            // Add services to the container.
            builder.Services.AddCors(options => {
                options.AddPolicy(name: corsConfigName, policy => {
                    policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();

            builder.Services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services here
            builder.Services.AddScoped<IExpenseItemsService, ExpenseItemsMSSQLService>();
            builder.Services.AddScoped<ICategoriesService, CategoriesMSSQLService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(corsConfigName);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    }
}
