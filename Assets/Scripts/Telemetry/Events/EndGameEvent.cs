using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameEvent : ITrackerEvent {
    int _time;
    public EndGameEvent(int time) {
        _time = time;
    }
    public Dictionary<string, object> getParams() {
        Dictionary<string, object> valuePairs = new Dictionary<string, object>();

        valuePairs.Add("time", _time);

        return valuePairs;
    }
}
