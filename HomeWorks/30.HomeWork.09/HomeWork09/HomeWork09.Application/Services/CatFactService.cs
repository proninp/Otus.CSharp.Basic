using HomeWork09.Application.Abstract;
using HomeWork09.Application.DTOs;
using HomeWork09.Application.Options;
using Microsoft.Extensions.Options;
using Serilog;

namespace HomeWork09.Application.Services;
public sealed class CatFactService : ICatFactService
{
    private const string NoFactsMessage = "На сегодня нет фактов. Попробуйте завтра.";
    private readonly AppSettings _appSettings;
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public CatFactService(IOptionsSnapshot<AppSettings> options, HttpClient httpClient, ILogger logger)
    {
        _appSettings = options.Value;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string> GetCatFactAsync()
    {
        var catFactDto = await ExecuteWebRequest();
        if (catFactDto is null)
            return NoFactsMessage;
        
        var fact = catFactDto.ToModel();
        return fact.Fact ?? NoFactsMessage;
    }

    private async Task<CatFactDto?> ExecuteWebRequest()
    {
        try
        {
            var response = await _httpClient.GetAsync(_appSettings.CatFactUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<CatFactDto>(content);
        }
        catch (HttpRequestException ex)
        {
            _logger.Error($"HTTP Request failed: {ex.Message}");
            return null;
        }
        catch (System.Text.Json.JsonException ex)
        {
            _logger.Error($"JSON Parsing failed: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            _logger.Error($"Unknow exception: {ex.Message}");
            return null;
        }
    }
}
