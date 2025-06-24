using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    GameStart, DayStart, DayEnd, NewCharacter, CharacterSinner, NewFavor, NewSin, CharacterJudgement, Ending, GameEnd
};

public class EventParams {

    protected Dictionary<string, object> dictionary;
    public EventParams(){

        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        int time = (int)utcNow.ToUnixTimeSeconds();

        dictionary = new Dictionary<string, object>()
        {
            { "time", time }
        };
    }
    public Dictionary<string, object> ToDictionary() { return dictionary; }
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


public class DayStartParams : EventParams
{   
    public DayStartParams(int number)
    {
        dictionary.Add("number", number);
    }
};

public class DayEndParams : EventParams
{
    public DayEndParams(int order)
    {
        dictionary.Add("order", order);
    }
};

public class NewCharacterParams : EventParams
{
    public NewCharacterParams(int type, int sentence)
    {
        dictionary.Add("type", type);
        dictionary.Add("sentence", sentence);
    }

};

public class CharacterSinnerParams : EventParams
{
    public CharacterSinnerParams(int sinner)
    {
        dictionary.Add("sinner", sinner);
    }
};

public class NewFavorParams : EventParams
{
    public NewFavorParams(int favor)
    {
        dictionary.Add("favor", favor);
    }
};

public class NewSinParams : EventParams
{
    public NewSinParams(int sin)
    {
        dictionary.Add("sin", sin);
    }
};

public class CharacterJudgementParams : EventParams
{
    public CharacterJudgementParams(int judgement)
    {
        dictionary.Add("judgement", judgement);
    }
};

public class EndingParams : EventParams
{
    public EndingParams(int ending)
    {
        dictionary.Add("ending", ending);
    }
};