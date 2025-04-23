using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DayEvent : ITrackerEvent {
    int time;
    int order;
    int number;
    public DayEvent(DayAsset asset) {
        time = asset.getTime();
        order = asset.getOrder();
        number = asset.getNumber();
    }

    public Dictionary<string, object> getParams()
    {
        Dictionary<string, object> valuePairs = new Dictionary<string, object>();

        valuePairs.Add("time", time);
        valuePairs.Add("order", order);
        valuePairs.Add("number", number);

        return valuePairs;
    }
}
