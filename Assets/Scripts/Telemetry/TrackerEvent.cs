using System;//Para tener time stamps independietes del motor 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType {
    GameStart, DayStart, DayEnd, NewCharacter, CharacterSinner, NewFavor, NewSin, CharacterJudgement, Ending, GameEnd
};

public class MyRandom {
    public System.Random rnd = new System.Random();
   
}

public class EventParams {

    protected Dictionary<string, object> dictionary;
    protected System.Security.Cryptography.SHA256 myHasher = System.Security.Cryptography.SHA256.Create();
    System.Text.StringBuilder myBuilder = new  System.Text.StringBuilder();
    //System.Random rnd = new System.Random(); si el seed es el mismo tick todos los eventos tendran el mismo qeu lo cree el tracker al principio y ya
    public EventParams(){

        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        int time = (int)utcNow.ToUnixTimeSeconds();


       
        int offset = Tracker.Instance.rnd.Next(0, 9999);
        System.UInt64 hashsable = (UInt64)time/1000 + (UInt64)offset ;
        byte[] idHash = myHasher.ComputeHash(BitConverter.GetBytes( (hashsable)));
        for (int i = 0; i < idHash.Length; i++)
        {
            myBuilder.Append(idHash[i].ToString("x2"));
        }
        string eventId = myBuilder.ToString();
        string userId= System.Environment.UserName;
        string gameId = System.AppDomain.CurrentDomain.FriendlyName;
        dictionary = new Dictionary<string, object>()
        {
            { "time", time },
            { "eventID",eventId},
            { "userID",userId},
            { "gameID",gameId}
        

        };
      
        Debug.Log(offset);

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