using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using UnityEngine;

public class JsonSerializer : ISerializer
{
    public string Serialize(TrackerEvent trackerEvent)
    {
        string data = "";

        if (trackerEvent.GetName() == "startgame")
        {
            data += "[";
        }

        Dictionary<string, object> values = trackerEvent.GetParams();
        data +="{\"" + trackerEvent.GetName() +"\":";
        data += JsonConvert.SerializeObject(values, Formatting.Indented);
        
        if(trackerEvent.GetName() == "endgame")
        {
            data += "}\n";
            data += "]\n";
        }
        else
        {
            data += "},\n";
        }
        return data;
    }
}
