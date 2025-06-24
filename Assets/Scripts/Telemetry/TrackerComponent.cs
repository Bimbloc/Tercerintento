using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerComponent : MonoBehaviour {
    public static TrackerComponent Instance { get; private set; }
    [SerializeField] private IPersistence persistenceObject;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Tracker.Init(persistenceObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        // Evento de Inicio de Juego
        Tracker.Instance.Start();
        Tracker.Instance.TrackEvent(new TrackerEvent(EventType.GameStart, new EventParams()));
    }

    void OnApplicationQuit() {
        // Evento de Final de Juego
        Tracker.Instance.TrackEvent(new TrackerEvent(EventType.GameEnd, new EventParams()));
        Tracker.Instance.End();
    }
}
