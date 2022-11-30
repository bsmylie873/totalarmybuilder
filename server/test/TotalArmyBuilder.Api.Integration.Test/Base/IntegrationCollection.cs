using System.Diagnostics.CodeAnalysis;

namespace TotalArmyBuilder.Api.Integration.Test.Base;
[ExcludeFromCodeCoverage]
[CollectionDefinition("Integration")]
public class IntegrationCollection : ICollectionFixture<IntegrationClassFixture>
{
}