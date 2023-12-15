using System.Net.Http.Json;
using GraphQL.Client.Http;
using GraphQL.Client;
using GraphQL.Transport;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

public class FetchTimetable {
    public string fetchTimetablebyNSR(string StopPlaceID) {
        // call GRAPHQL API
        var graphQLEndpoint = "https://api.entur.io/journey-planner/v3/graphql";
        var stopPlace = $"NSR:StopPlace:{StopPlaceID}";

        var query = new
        {
            query = $@"{{
                stopPlace(id: ""{stopPlace}"") {{
                    id 
                    name 
                    estimatedCalls(timeRange: 72100, numberOfDepartures: 10) {{
                        aimedArrivalTime 
                        aimedDepartureTime 
                        expectedArrivalTime 
                        expectedDepartureTime 
                        date 
                        destinationDisplay {{
                            frontText
                        }}
                    }}
                }}
            }}"
        };

        using (var client = new HttpClient()) {
            client.DefaultRequestHeaders.Add("ET-Client-Name", "ingraphic-departureboard");
            var response = client.PostAsJsonAsync(graphQLEndpoint, query).Result;
            if (response.IsSuccessStatusCode) {
                var result = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine(result);
                return result;
            } else {
                Console.WriteLine("Error!");
                return $"Error: {response.StatusCode}";
            }
        }
    }
}