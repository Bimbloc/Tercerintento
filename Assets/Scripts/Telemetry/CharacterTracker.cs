using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTracker : MonoBehaviour {
    public static CharacterTracker Instance { get; private set; } = null;

    private int _initTime;
    private int _sprite;
    private int _type;
    private int _sentence;
    private int _sinner;
    private List<int> _favors = new List<int>();
    private List<int> _sins = new List<int>();
    private int _judgement;
    private int _endTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void newCharacter(int sprite)
    {
        _initTime = (int)Time.time * 1000;
        _sprite = sprite;
        _favors = new List<int>();
        _sins = new List<int>();
    }

    public void setCharacterType(int type, int sentence) 
    { 
        _type = type; 
        _sentence = sentence;
    }

    public void isSinner(int sinner) { _sinner = sinner; }

    public void addFavor(int favor) { _favors.Add(favor); }

    public void addSin(int pecado) { _sins.Add(pecado); }

    public void setCharacterJudgement(int judgement)
    {
        _judgement = judgement;
        _endTime = (int)Time.time * 1000;
        sendTrackerEvent();

    }

    private void sendTrackerEvent()
    {
        Tracker.Instance.TrackEvent(new TrackerEvent(EventType.Character, new CharacterParams()
        {
            time = _endTime - _initTime, 
            sprite = _sprite, 
            type = _type,
            sentence = _sentence, 
            sinner = _sinner, 
            favors = _favors, 
            sins = _sins, 
            judgement = _judgement

        }));
    }
}
