public class TimetableModel
{
    public Data data { get; set; }
}

public class Data
{
    public StopPlace stopPlace { get; set; }
}

public class StopPlace
{
    public string id { get; set; }
    public string name { get; set; }
    public List<EstimatedCalls> estimatedCalls { get; set; }
}

public class EstimatedCalls {
    public DateTime aimedArrivalTime { get; set; }
    public DateTime aimedDepartureTime { get; set; }
    public DateTime expectedArrivalTime { get; set; }
    public DateTime expectedDepartureTime { get; set; }
    public DateTime date { get; set; }
    public DestinationDisplay destinationDisplay { get; set; }
}

public class DestinationDisplay {
    public string frontText { get; set; }
}