using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TotalArmyBuilder.Dal.Contexts;
using TotalArmyBuilder.Dal.Interfaces;

namespace TotalArmyBuilder.Api.Integration.Test.Base;

public class IntegrationClassFixture : IDisposable
{
    public readonly WebApplicationFactory<Program> Host;

    public IntegrationClassFixture()
    {
        Host = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(e =>
                {
                    e.AddDbContext<TotalArmyContext>(options => options
                            .EnableSensitiveDataLogging()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString()),
                        ServiceLifetime.Singleton,
                        ServiceLifetime.Singleton);
                    e.AddTransient<ITotalArmyDatabase, TotalArmyContext>();
                });
            });
        DatabaseSeed.SeedDatabase(Host.Services.GetService<TotalArmyContext>());
    }

    public void Dispose()
    {
        Host?.Dispose();
    }
}