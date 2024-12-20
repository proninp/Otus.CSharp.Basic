using System.Text.Json.Serialization;
using HomeWork09.Application.Models;

namespace HomeWork09.Application.DTOs;
public sealed class CatFactDto
{
    [JsonPropertyName("fact")]
    public string? Fact { get; set; }

    [JsonPropertyName("length")]
    public int Length { get; set; }
}

public static class CatFactMappig
{
    public static CatFact ToModel(this CatFactDto fact) =>
        new CatFact
        {
            Fact = fact.Fact,
            Length = fact.Length,
        };
}