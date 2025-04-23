using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameEvent : TrackerEvent {
    int _time;
    public StartGameEvent(int time) : base("startgame") {
        _time = time;
    }
    public override Dictionary<string, object> GetParams() {
        Dictionary<string, object> valuePairs = new Dictionary<string, object>();

        valuePairs.Add("time", _time);

        return valuePairs;
    }
}
