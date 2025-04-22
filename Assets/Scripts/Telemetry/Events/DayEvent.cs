using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEvent : TrackerEvent {
    int time;
    int order;
    int number;
    public DayEvent(DayAsset asset) {
        time = asset.getTime();
        order = asset.getOrder();
        number = asset.getNumber();
    }
}
