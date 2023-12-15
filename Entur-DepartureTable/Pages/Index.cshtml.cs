using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Entur_DepartureTable.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public TimetableModel TimetableModel { get; set; }
    public void OnGet()
    {
        var fetchTimetable = new FetchTimetable();
        var timetableJson = fetchTimetable.fetchTimetablebyNSR("127");
        TimetableModel = JsonSerializer.Deserialize<TimetableModel>(timetableJson);
    }
}
