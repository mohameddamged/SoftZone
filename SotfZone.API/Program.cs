using SoftZone.DAL;
using SoftZone.BLL;

namespace SotfZone.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register DAL & BLL Services
            builder.Services.AddDalServices(builder.Configuration);
            builder.Services.AddBllServices();

            // Configure CORS for Angular Frontend
            //builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
            //p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

            builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
            p.WithOrigins("https://softzone-front.vercel.app").AllowAnyHeader().AllowAnyMethod()));

            // Learn more about configuring Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
