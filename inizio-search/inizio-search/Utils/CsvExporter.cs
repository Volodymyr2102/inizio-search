using InizioSearch.Models;
using System.Text;

namespace InizioSearch.Utils;

public static class CsvExporter
{
    public static string ToCsv(IEnumerable<SearchItem> items)
    {
        var sb = new StringBuilder();
        sb.AppendLine("position,title,link,snippet");
        foreach (var i in items)
        {
            string Esc(string v) => "\"" + v.Replace("\"", "\"\"") + "\"";
            sb.AppendLine($"{i.Position},{Esc(i.Title)},{Esc(i.Link)},{Esc(i.Snippet)}");
        }
        return sb.ToString();
    }
}