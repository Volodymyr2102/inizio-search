namespace InizioSearch.Models;

public record SearchItem(int Position, string Title, string Link, string Snippet);

public record SearchResponse(string Query, DateTimeOffset FetchedAt, IReadOnlyList<SearchItem> Items);