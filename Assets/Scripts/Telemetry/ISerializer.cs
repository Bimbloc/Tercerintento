using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISerializer : ScriptableObject {
    string extension;
    public ISerializer(string extension) {
        this.extension = extension;
    }
    public abstract string Serialize(TrackerEvent trackerEvent);
    public string GetExtension() {
        return extension;
    }
}
