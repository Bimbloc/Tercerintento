using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackerEvent {
    string name;
    public abstract Dictionary<string, object> GetParams();
    public string GetName()
    {
        return name;
    }

    public TrackerEvent(string name)
    {
        this.name = name;
    }
}
