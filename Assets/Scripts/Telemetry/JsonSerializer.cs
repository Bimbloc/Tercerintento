using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;
using Newtonsoft.Json;
using UnityEngine;

public class JsonSerializer : ISerializer
{

    public override string Serialize(TrackerEvent trackerEvent)
    {
        string data = "";

        if (trackerEvent.GetEventType() == EventType.GameStart)
        {
            data += "[";
        }

        Dictionary<string, object> values = trackerEvent.GetEventParams().ToDictionary();
        data +="{\"" + trackerEvent.GetEventType().ToString() +"\":";
        data += JsonConvert.SerializeObject(values, Formatting.Indented);
        
        if(trackerEvent.GetEventType() == EventType.GameEnd)
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

    public override void SetFormat(TraceFormats format)
    {
        currentFormat = format;
    }

    public override string GetExtension()
    {
        string extension = "";
        switch (currentFormat)
        {
            case TraceFormats.json:
                extension = ".json";
                break;
        }

        return extension;
    }
}
