using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour {
    public static DayTracker Instance { get; private set; } = null;

    private int _initTime;
    private int _number;
    private int _order;
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

    public void startDay(int number) {
        _initTime = (int)Time.time * 1000;
        _number = number;
    }
    public void endDay(int order)
    {
        _order = order;
        _endTime = (int)Time.time * 1000;
        sendTrackerEvent();
    }
    private void sendTrackerEvent()
    {
        Tracker.Instance.TrackEvent(new TrackerEvent(EventType.Day, new DayParams()
        {
            time = _endTime - _initTime,
            number = _number,
            order = _order
        }));
    }
}
