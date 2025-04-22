using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializer
{
    public string Serialize(TrackerEvent trackerEvent);
}
