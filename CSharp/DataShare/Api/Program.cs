using Business;
using Business.Abstractions;
using Business.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinessServices();

builder.Services.AddScoped<IJwtSettings>
(
    (provider) => new JwtSettings
    {
        Audience = builder.Configuration["JwtSettings:Audience"]!,
        Issuer = builder.Configuration["JwtSettings:Issuer"]!,
        Key = builder.Configuration["JwtSettings:Key"]!
    }
);

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddAuthentication
    (
        (options) =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    )
    .AddJwtBearer
    (
        (options) =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        }
    );

builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors((policy) => policy.WithOrigins("https://localhost:7228", "http://localhost:5109").AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();