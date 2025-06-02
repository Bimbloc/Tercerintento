using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    GameStart, GameEnd
};

public interface EventParams {
    Dictionary<string, object> ToDictionary();
};

public class TrackerEvent {
    EventType type;
    EventParams evParams;
    public TrackerEvent(EventType eventType, EventParams eventParams) {
        type = eventType;
        evParams = eventParams;
    }
    public EventType GetEventType() {
        return type;
    }
    public EventParams GetEventParams() {
        return evParams;
    }
}

public struct GameStartParams : EventParams {
    public float timestamp;
    public Dictionary<string, object> ToDictionary() {
        return new Dictionary<string, object> {
            { "timestamp", timestamp } 
        };
    }
};
public struct GameEndParams : EventParams {
    public float timestamp;
    public Dictionary<string, object> ToDictionary() {
        return new Dictionary<string, object> {
            { "timestamp", timestamp }
        };
    }
};