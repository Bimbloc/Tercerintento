using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEvent : TrackerEvent {
    int _final;
    public FinalEvent(int final) : base ("final"){
        _final = final;
    }

    public override Dictionary<string, object> GetParams()
    {
        Dictionary<string, object> valuePairs = new Dictionary<string, object>();

        valuePairs.Add("final", _final);

        return valuePairs;
    }
}
