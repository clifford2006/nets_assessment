
using Microsoft.EntityFrameworkCore;
using PaymentService.DB;

namespace PaymentService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MainDBContext>(opt => opt.UseInMemoryDatabase("PaymentDB"));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
