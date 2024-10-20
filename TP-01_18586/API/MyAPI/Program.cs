using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;

namespace MyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona o CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Configurar o contexto do banco de dados
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 32))));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Logging.AddConsole(); // Adiciona logging no console

            var app = builder.Build();

            // Middleware de tratamento de exceções
            app.UseExceptionHandler("/error");

            // Middleware para configuração de Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Middleware para redirecionamento HTTPS
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("AllowAll"); // Usar CORS

            // Endpoint para tratamento de erro
            app.MapGet("/error", (HttpContext httpContext) =>
            {
                var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

                // Log the exception (opcional)
                app.Logger.LogError(exception, "An error occurred");

                return app.Environment.IsDevelopment()
                    ? Results.Problem(detail: exception?.StackTrace, title: exception?.Message)
                    : Results.Problem("An error occurred.");
            });

            app.MapControllers(); // Mapeia os controladores da API

            app.Run(); // Executa a aplicação
        }
    }
}
