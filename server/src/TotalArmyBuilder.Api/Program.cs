using System.Diagnostics.CodeAnalysis;
using FluentValidation.AspNetCore;
using TotalArmyBuilder.Api;
using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
}

app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program
{
}