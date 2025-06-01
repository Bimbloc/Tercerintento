using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISerializer : ScriptableObject {
    
    protected TraceFormats currentFormat;

    public abstract string Serialize(TrackerEvent trackerEvent);
    public abstract string GetExtension();
    public abstract void SetFormat(TraceFormats format);
}
