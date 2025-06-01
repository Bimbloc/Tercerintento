using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPersistence : ScriptableObject {
    [SerializeField] protected ISerializer serializer;
    protected EventQueue queue;
    public void Send(TrackerEvent trackerEvent) {
        queue.AddEvent(trackerEvent);
    }
    public abstract void Flush();
}
