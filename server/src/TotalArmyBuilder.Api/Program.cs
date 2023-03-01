using System.Diagnostics.CodeAnalysis;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TotalArmyBuilder.Api;
using TotalArmyBuilder.Api.Authentication;
using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;
using AuthenticationService = TotalArmyBuilder.Service.Services.AuthenticationService;
using IAuthenticationService = TotalArmyBuilder.Service.Interfaces.IAuthenticationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(string.Empty)
    .AddScheme<AuthenticationSchemeOptions, AccessAuthenticationFilter>(string.Empty, options => {});

builder.Services.AddAuthorization(options => 
    options.AddPolicy(string.Empty, policy =>
    {
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    }));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation(s => s.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<ITotalArmyDatabase, TotalArmyContext>(_ =>
    new TotalArmyContext(EnvironmentVariables.DbConnectionString));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICompositionService, CompositionService>();
builder.Services.AddScoped<IFactionService, FactionService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddAutoMapper(config => config.AllowNullCollections = true, typeof(Program).Assembly,
    typeof(AccountService).Assembly);
builder.Services.AddAutoMapper(typeof(AccountProfile));
builder.Services.AddHealthChecks();
builder.Services.AddControllers()
    .AddNewtonsoftJson();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers().AllowAnonymous();
}
else
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers().RequireAuthorization();
}

app.UseCors(
    o => o
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
);

app.MapHealthChecks("/health");

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program
{
}