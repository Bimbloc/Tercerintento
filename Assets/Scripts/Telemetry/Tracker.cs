using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {
    public static Tracker Instance { get; private set; } = null;

    [SerializeField] private IPersistence persistenceObject;

    private Dictionary<string, ITrackerAsset> activeTrackers = new Dictionary<string, ITrackerAsset>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit() {
        End();
    }

    private void Init() {
        TrackEvent("StartGame", (int)(Time.time * 1000));
    }

    private void End() {
        TrackEvent("EndGame", (int)(Time.time * 1000));
    }

    public void TrackEvent(string key, int param = 0) {
        switch (key) {
            case "StartGame":
                //persistenceObject.Send(new StartGameEvent(param));
                break;
            case "DayStartedTime":
                activeTrackers["Day"] = new DayAsset(param);
                break;
            case "DayStartedNumber":
                if (!activeTrackers.ContainsKey("Day"))
                    return;
                DayAsset asset = (DayAsset)activeTrackers["Day"];
                asset.setNumber(param);
                break;
            case "DayOrder":
                if (!activeTrackers.ContainsKey("Day"))
                    return;
                asset = (DayAsset)activeTrackers["Day"];
                asset.setOrder(param);
                break;
            case "DayEndedTime":
                if (!activeTrackers.ContainsKey("Day"))
                    return;
                asset = (DayAsset)activeTrackers["Day"];
                asset.setEndTime(param);
                //persistenceObject.Send(new DayEvent(asset));
                activeTrackers.Remove("Day");
                break;

            case "NPCAppeared":
                activeTrackers["Character"] = new CharacterAsset(param);
                break;
            case "NPCSpriteID":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                CharacterAsset character = (CharacterAsset)activeTrackers["Character"];
                character.setSprite(param);
                break;
            case "NPCType":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                character = (CharacterAsset)activeTrackers["Character"];
                character.setType(param);
                break;
            case "Sentence":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                character = (CharacterAsset)activeTrackers["Character"];
                character.setSentence(param);
                break;
            case "Sinner":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                character = (CharacterAsset)activeTrackers["Character"];
                character.setSinner(param);
                break;

            case "Favor":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                character = (CharacterAsset)activeTrackers["Character"];
                character.addFavor(param);
                break;
            case "Pecado":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                character = (CharacterAsset)activeTrackers["Character"];
                character.addPecado(param);
                break;
            case "Judgement":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                character = (CharacterAsset)activeTrackers["Character"];
                character.setJudgement(param);
                break;
            case "JudgementTime":
                if (!activeTrackers.ContainsKey("Character"))
                    return;
                character = (CharacterAsset)activeTrackers["Character"];
                character.setEndTime(param);
                //persistenceObject.Send(new CharacterEvent(character));
                activeTrackers.Remove("Character");
                break;
            case "FinalObtenido":
                //persistenceObject.Send(new FinalEvent(param));
                break;
            case "EndGame":
                //persistenceObject.Send(new EndGameEvent(param));
                persistenceObject.Flush();
                break;

        }
    }
}
