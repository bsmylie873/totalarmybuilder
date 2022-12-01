using System.Diagnostics.CodeAnalysis;

namespace TotalArmyBuilder.Service.Services.Exceptions;

[ExcludeFromCodeCoverage]
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
        
    }
}