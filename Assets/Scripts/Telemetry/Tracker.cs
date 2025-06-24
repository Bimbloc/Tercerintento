using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {
    public static Tracker Instance { get; private set; } = null;

    [SerializeField] private IPersistence persistenceObject;

    private Dictionary<string, ITrackerAsset> activeTrackers = new Dictionary<string, ITrackerAsset>();

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
    private void Start() {
        Init();
    }

    void OnApplicationQuit() {
        End();
    }

    private void Init() {
        persistenceObject.Init();
        // Evento de Inicio de Juego
        TrackEvent(new TrackerEvent(EventType.GameStart, new EventParams()));
    }

    private void End() {
        // Evento de Final de Juego
        TrackEvent(new TrackerEvent(EventType.GameEnd, new EventParams()));
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
