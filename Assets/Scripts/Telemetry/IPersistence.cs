using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPersistence : ScriptableObject {
    [SerializeField] protected ISerializer serializer;
    [SerializeField] protected int maxEvents;
    protected EventQueue queue;
    private void OnEnable() {
        queue = new EventQueue(maxEvents);
    }
    public void Send(TrackerEvent trackerEvent) {
        queue.AddEvent(trackerEvent);
    }
    public abstract void Flush();
    public abstract void Init();
    public abstract void End();
}
