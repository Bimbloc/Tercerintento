using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DayEvent : TrackerEvent {
    int time;
    int order;
    int number;
    public DayEvent(DayAsset asset) : base("day") {
        time = asset.getTime();
        order = asset.getOrder();
        number = asset.getNumber();
    }

    public override Dictionary<string, object> GetParams()
    {
        Dictionary<string, object> valuePairs = new Dictionary<string, object>();

        valuePairs.Add("time", time);
        valuePairs.Add("order", order);
        valuePairs.Add("number", number);

        return valuePairs;
    }
}
