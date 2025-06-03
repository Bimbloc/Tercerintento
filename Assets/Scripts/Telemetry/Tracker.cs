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
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit() {
        End();
    }

    private void Init() {
        // Evento de Inicio de Juego
        TrackEvent(new TrackerEvent(EventType.GameStart, new GameStartParams() { time = (int)(Time.time * 1000) }));
    }

    private void End() {
        // Evento de Final de Juego
        TrackEvent(new TrackerEvent(EventType.GameEnd, new GameEndParams() { time = (int)(Time.time * 1000) }));
        persistenceObject.Flush();
    }

    public void TrackEvent(TrackerEvent trackedEvent) {
        persistenceObject.Send(trackedEvent);
    }
}
