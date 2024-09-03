using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ReturnUrlParameter = "unauthorized";
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                context.Response.ContentType = "application/json";
                var messege = new
                {
                    error = "No autorizado",
                    messege = "Debe iniciar sesion para acceder a este recurso"
                };
                var jsoMessage = JsonSerializer.Serialize(messege);
                return context.Response.WriteAsync(jsoMessage);

            }

        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
