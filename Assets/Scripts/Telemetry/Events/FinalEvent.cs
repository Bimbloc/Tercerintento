using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEvent : ITrackerEvent {
    int _final;
    public FinalEvent(int final) {
        _final = final;
    }

    public Dictionary<string, object> getParams()
    {
        Dictionary<string, object> valuePairs = new Dictionary<string, object>();

        valuePairs.Add("final", _final);

        return valuePairs;
    }
}
