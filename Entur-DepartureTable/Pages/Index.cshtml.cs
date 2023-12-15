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
    public TimetableModel TimetableModelTrain { get; set; }
    public TimetableModel TimetableModelBus { get; set; }
    public void OnGet()
    {
        var fetchTimetable = new FetchTimetable();
        // NSR codes:
        // 127 = Ski stasjon (train)
        // 4992 = Ski stasjon Jernbaneveien (bus)

        // TODO: find codes for Drammen

        var timetableJson = fetchTimetable.fetchTimetablebyNSR("127");
        TimetableModelTrain = JsonSerializer.Deserialize<TimetableModel>(timetableJson);

        var timetableJsonBus = fetchTimetable.fetchTimetablebyNSR("4992");
        TimetableModelBus = JsonSerializer.Deserialize<TimetableModel>(timetableJsonBus);
    }
}
