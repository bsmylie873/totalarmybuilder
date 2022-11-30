using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using System.Text.Json;

namespace TotalArmyBuilder.Api.Integration.Test.TestUtilities;
[ExcludeFromCodeCoverage]
public static class HttpClientJsonExtensionsPatch
{
    public static Task<HttpResponseMessage> PatchAsJsonAsync<T>(this HttpClient @this, string? requestUri, T value,
        JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (@this == null) throw new ArgumentNullException(nameof(@this));

        var content = JsonContent.Create(value, null, options);
        return @this.PatchAsync(requestUri, content, cancellationToken);
    }

    public static Task<HttpResponseMessage> PatchAsJsonAsync<T>(this HttpClient @this, Uri? requestUri, T value,
        JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (@this == null) throw new ArgumentNullException(nameof(@this));

        var content = JsonContent.Create(value, null, options);
        return @this.PatchAsync(requestUri, content, cancellationToken);
    }
}