using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Tracker Instance { get; private set; }

    [SerializeField] private IPersistence persistenceObject;   

    private List<ITrackerAsset> activeTrackers = new List<ITrackerAsset>();
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

    }

    private void Init()
    {

    }

    private void End()
    {

    }

    public void TrackEvent(string key, int param = 0)
    {
        switch (key)
        {
            case "DayTimeStart":
                break;
            case "DayTimeEnd":
                break;
            case "JudgementTimeStart":
                break;
            case "JudgementTimeEnd":
                break;
        }
    }
}
