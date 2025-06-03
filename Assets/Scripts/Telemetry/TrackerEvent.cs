using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    GameStart, Day, Character, Ending, GameEnd
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
    public int time;
    public Dictionary<string, object> ToDictionary() {
        return new Dictionary<string, object> {
            { "time", time } 
        };
    }
};

public struct DayParams : EventParams
{
    public int time;
    public int number;
    public int order;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "time", time },
            { "number", number },
            { "order", order }
        };
    }
};

public struct CharacterParams : EventParams
{
    public int time;
    public int sprite;
    public int type;
    public int sentence;
    public int sinner;
    public List<int> favors;
    public List<int> sins;
    public int judgement;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "time", time },
            { "sprite", sprite },
            { "type", type },
            { "sentence", sentence },
            { "sinner", sinner },
            { "favors", favors },
            { "sins", sins },
            { "judgement", judgement }
        };
    }
};

public struct EndingParams : EventParams
{
    public int ending;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "ending", ending }
        };
    }
};

public struct GameEndParams : EventParams
{
    public int time;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "time", time }
        };
    }
};