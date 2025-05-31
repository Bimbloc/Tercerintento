using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPersistence : ScriptableObject {
    [SerializeField] ISerializer serializer;
    EventQueue queue;
    public void Send(TrackerEvent trackerEvent) {
        queue.AddEvent(trackerEvent);
    }
    public abstract void Flush();
    public abstract void SetFormat(TraceFormats newformat);
}
