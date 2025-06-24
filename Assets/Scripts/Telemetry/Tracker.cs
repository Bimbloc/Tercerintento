using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker {
    public static Tracker Instance { get; private set; } = null;

    private IPersistence persistenceObject;

    public static void Init(IPersistence persistence) {
        if (Instance == null) {
            Instance = new Tracker();
            Instance.persistenceObject = persistence;
        }
    }

    public void Start() {
        persistenceObject.Init();
    }

    public void End() {
        persistenceObject.Flush();
        persistenceObject.End();
    }

    public void TrackEvent(TrackerEvent trackedEvent) {
        persistenceObject.Send(trackedEvent);
        if (trackedEvent.GetEventType() == EventType.DayEnd) {
            persistenceObject.Flush();
        }
    }
}
