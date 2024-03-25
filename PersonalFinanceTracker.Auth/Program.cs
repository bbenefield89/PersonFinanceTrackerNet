
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Auth.Data;
using PersonalFinanceTracker.Auth.Entities;

namespace PersonalFinanceTracker.Auth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Controllers
            builder.Services.AddControllers();

            // Add Services
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<InMemDbContext>()
                .AddDefaultTokenProviders();

            // Add Contexts
            builder.Services.AddDbContext<InMemDbContext>(opts =>
                opts.UseInMemoryDatabase("InMemDbContext"));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
