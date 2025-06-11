using System.Text;
using API.Services;
using Application.Core;
using Application.Interfaces;
using Application.Students;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(typeof(Application.Schools.List.Handler));
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<Create>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<TokenService>();
builder.Services.AddScoped<IUserAccessor, UserAccessor>();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:TokenKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    // var logger = services.GetRequiredService<Logger<Program>>();
    // logger.LogError(ex, "An error occured dusing migration");
}

app.Run();
