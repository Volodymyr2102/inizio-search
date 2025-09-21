using InizioSearch.Models;
using System.Text.Json;

namespace InizioSearch.Services;

public interface ISearchService
{
    Task<SearchResponse> SearchAsync(string query, int count = 10);
}

public class GoogleSearchService : ISearchService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;
    private readonly string _cx;

    public GoogleSearchService(HttpClient http)
    {
        _http = http;
        _apiKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY")
                  ?? throw new InvalidOperationException("GOOGLE_API_KEY not set");
        _cx = Environment.GetEnvironmentVariable("GOOGLE_CSE_ID")
              ?? throw new InvalidOperationException("GOOGLE_CSE_ID not set");
    }

    public async Task<SearchResponse> SearchAsync(string query, int count = 10)
    {
        var url = $"https://www.googleapis.com/customsearch/v1?q={Uri.EscapeDataString(query)}&num={count}&key={_apiKey}&cx={_cx}";

        var json = await _http.GetFromJsonAsync<JsonElement>(url);

        var items = new List<SearchItem>();
        if (json.TryGetProperty("items", out var arr))
        {
            int pos = 1;
            foreach (var it in arr.EnumerateArray())
            {
                var title = it.GetProperty("title").GetString() ?? "";
                var link = it.GetProperty("link").GetString() ?? "";
                var snippet = it.TryGetProperty("snippet", out var snip) ? snip.GetString() ?? "" : "";
                items.Add(new SearchItem(pos++, title, link, snippet));
            }
        }

        return new SearchResponse(query, DateTimeOffset.UtcNow, items);
    }
}