
using Day2.DAL;
using Microsoft.EntityFrameworkCore;

namespace Day_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Default
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Database

            var connectionString = builder.Configuration.GetConnectionString("APItask");
            builder.Services.AddDbContext<CompanyContext>(
                options => options.UseSqlServer(connectionString));

            #endregion

            #region Repos

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();
            

            #endregion

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