
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Data;
using PersonalFinanceTracker.TransactionsRestApi.Services;

namespace PersonalFinanceTracker.TransactionsRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register Controllers
            builder.Services.AddControllers();

            // Register Services
            builder.Services.AddScoped<ITransactionsService, TransactionsService>();

            // Register Contexts
            builder.Services.AddDbContext<InMemDbContext>(opts =>
                opts.UseInMemoryDatabase("InMemDbContext"));

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
