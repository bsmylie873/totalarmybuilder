using System.Diagnostics.CodeAnalysis;
using TotalArmyBuilder.Api.Extensions;

namespace TotalArmyBuilder.Api;


[ExcludeFromCodeCoverage] 
public static class EnvironmentVariables
{
    private static string DbConnectionStringKey => "DbConnectionString";

    public static string DbConnectionString => DbConnectionStringKey.GetValue("Server=localhost;Port=5432;Database=tw-army-builder;User Id=admin;Password=password;");
}