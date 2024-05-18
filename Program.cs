
using ClassLibary;
using Microsoft.EntityFrameworkCore;
using SUT23_Projekt___Avancerad_.NET.Data;
using SUT23_Projekt___Avancerad_.NET.Services;
using System.Text.Json.Serialization;

namespace SUT23_Projekt___Avancerad_.NET
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
            builder.Services.AddScoped<ICompany<Company>, CompanyRepo>();
            builder.Services.AddScoped<IAppData<Appointment>, AppointmentRepo>();
            builder.Services.AddScoped<ICustomer<Customer>, CustomerRepo>();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            //EF till SQL
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));


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
