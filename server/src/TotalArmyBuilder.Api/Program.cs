

using FluentValidation.AspNetCore;
using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation(s => s.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<ITotalArmyDatabase, TotalArmyContext>(_ => new TotalArmyContext("Server=localhost;Port=5432;Database=tw-army-builder;User Id=admin;Password=password;"));
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddAutoMapper(config => config.AllowNullCollections = true, typeof(Program).Assembly,
    typeof(AccountService).Assembly);

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
