using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISerializer : ScriptableObject {
    public abstract string Serialize(TrackerEvent trackerEvent);
}
