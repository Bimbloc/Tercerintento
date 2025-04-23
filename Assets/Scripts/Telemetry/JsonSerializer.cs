using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class JsonSerializer : ISerializer
{
    public string Serialize(ITrackerEvent trackerEvent)
    {
        Dictionary<string, object> values = trackerEvent.getParams();
        return JsonConvert.SerializeObject(values, Formatting.Indented);
    }
}
