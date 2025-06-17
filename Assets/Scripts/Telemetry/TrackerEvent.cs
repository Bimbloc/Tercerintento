using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    GameStart, DayStart, DayEnd, NewCharacter, CharacterSinner, NewFavor, NewSin, CharacterJudgement, Ending, GameEnd
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

public struct DayStartParams : EventParams
{
    public int time;
    public int number;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "time", time },
            { "number", number },
        };
    }
};

public struct DayEndParams : EventParams
{
    public int time;
    public int order;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "time", time },
            { "order", order }
        };
    }
};

public struct NewCharacterParams : EventParams
{
    public int time;
    public int type;
    public int sentence;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "time", time },
            { "type", type },
            { "sentence", sentence },
        };
    }

};

public struct CharacterSinnerParams : EventParams
{
    public int sinner;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "sinner", sinner },
        };
    }
};

public struct NewFavorParams : EventParams
{
    public int favor;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "favor", favor},
        };
    }
};

public struct NewSinParams : EventParams
{
    public int sin;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "sin", sin },
        };
    }
};

public struct CharacterJudgementParams : EventParams
{
    public int time;
    public int judgement;
    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object> {
            { "time", time },
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