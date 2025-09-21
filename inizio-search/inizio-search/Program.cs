using InizioSearch.Models;
using InizioSearch.Services;
using InizioSearch.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<ISearchService, GoogleSearchService>();

var app = builder.Build();

app.MapGet("/api/search", async (string? q, string? format, ISearchService service) =>
{
    if (string.IsNullOrWhiteSpace(q))
        return Results.BadRequest("Parameter ?q= is required");

    var resp = await service.SearchAsync(q.Trim(), 10);

    if (string.Equals(format, "csv", StringComparison.OrdinalIgnoreCase))
    {
        var csv = CsvExporter.ToCsv(resp.Items);
        return Results.Text(csv, "text/csv");
    }

    return Results.Json(resp);
});
app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();