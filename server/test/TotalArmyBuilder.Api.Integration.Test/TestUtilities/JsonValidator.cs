using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NJsonSchema.Generation;

namespace TotalArmyBuilder.Api.Integration.Test.TestUtilities;
[ExcludeFromCodeCoverage]
public static class JsonValidator
{
    public static string VerifyDeSerialization<T>(this string @this)
    {
        var (dataToValidate, schema) = RetrieveSchemaForComparison<T>(@this);
        var errors = schema.Validate(dataToValidate);
        errors.Should().BeEmpty();

        return @this;
    }

    public static T VerifyDeSerialize<T>(this string @this)
    {
        return JsonConvert.DeserializeObject<T>(VerifyDeSerialization<T>(@this)) ??
               throw new InvalidOperationException();
    }

    private static (string, JsonSchema) RetrieveSchemaForComparison<T>(string data)
    {
        var type = typeof(T);
        if (type.IsArray)
        {
            var elementSchema = JsonSchema.FromType(type.GetElementType()!, RetrieveJsonSettings());
            var elementObject = JArray.Parse(data).ElementAt(0).ToString();
            return (elementObject, elementSchema);
        }

        return (data, JsonSchema.FromType(type, RetrieveJsonSettings()));
    }

    private static JsonSchemaGeneratorSettings RetrieveJsonSettings()
    {
        return new JsonSchemaGeneratorSettings
        {
            SerializerSettings = new JsonSerializerSettings
            {
                CheckAdditionalContent = true,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            }
        };
    }
    
    public static void CheckIfErrorPresent(this JObject @this, string name,  params string[] messages)
    {
        var errors = @this[name].Select(x => x.ToString()).ToList();

        foreach (var message in messages)
        {
            errors.Should().Contain(message);
        }
        
    }
}