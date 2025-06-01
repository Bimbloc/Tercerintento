using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class EventQueue {
    private Queue<TrackerEvent> queue;
    public EventQueue()
    {
        queue = new Queue<TrackerEvent>();
    }

    public void AddEvent(TrackerEvent gEvent)
    {
        queue.Enqueue(gEvent);
    }

    public TrackerEvent HandleEvent()
    {
        return queue.Dequeue();
    }

    public bool HasEvents()
    {
        return queue.Count > 0;
    }
}
