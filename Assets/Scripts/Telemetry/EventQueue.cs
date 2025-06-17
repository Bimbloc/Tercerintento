using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class EventQueue {
    private Queue<TrackerEvent> queue;
    int _maxEvents;
    public EventQueue(int maxEvents)
    {
        queue = new Queue<TrackerEvent>();
        _maxEvents = maxEvents;
    }

    public void AddEvent(TrackerEvent gEvent)
    {
        if (queue.Count >= _maxEvents) 
            queue.Dequeue();
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
