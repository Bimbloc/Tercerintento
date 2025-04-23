using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPersistence
{
    void Send(ITrackerEvent trackerEvent);

    void Flush();
    void SetFormat(TraceFormats newformat);
}
