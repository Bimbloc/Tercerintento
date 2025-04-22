using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public static Tracker Instance { get; private set; }

    [SerializeField] private IPersistence persistenceObject;

    private Dictionary<string, ITrackerAsset> activeTrackers = new Dictionary<string, ITrackerAsset>();
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

    public void TrackEvent(string key, int param = 0) {
        switch (key) {
            case "DayStartedTime":
                activeTrackers["Day"] = new DayAsset(param);
                break;
            case "DayStartedNumber":
                DayAsset asset = (DayAsset)activeTrackers["Day"];
                if (asset == null)
                    return;
                asset.setNumber(param);
                break;
            case "DayOrder":
                asset = (DayAsset)activeTrackers["Day"];
                if (asset == null)
                    return;
                asset.setOrder(param);
                break;
            case "DayEndedTime":
                asset = (DayAsset)activeTrackers["Day"];
                if (asset == null)
                    return;
                asset.setEndTime(param);
                persistenceObject.Send(new DayEvent(asset));
                activeTrackers.Remove("Day");
                break;

            case "NPCAppeared":
                activeTrackers["Character"] = new CharacterAsset(param);
                break;
            case "NPCSpriteID":
                CharacterAsset character = (CharacterAsset)activeTrackers["Character"];
                if (character == null)
                    return;
                character.setSprite(param);
                break;
            case "Sentence":
                character = (CharacterAsset)activeTrackers["Character"];
                if (character == null)
                    return;
                character.setSentence(param);
                break;
            case "Sinner":
                character = (CharacterAsset)activeTrackers["Character"];
                if (character == null)
                    return;
                character.setSinner(param);
                break;

            case "Favor":
                character = (CharacterAsset)activeTrackers["Character"];
                if (character == null)
                    return;
                character.addFavor(param);
                break;
            case "Pecado":
                character = (CharacterAsset)activeTrackers["Character"];
                if (character == null)
                    return;
                character.addPecado(param);
                break;
            case "Judgement":
                character = (CharacterAsset)activeTrackers["Character"];
                if (character == null)
                    return;
                character.setJudgement(param);
                break;
            case "JudgementTime":
                character = (CharacterAsset)activeTrackers["Character"];
                if (character == null)
                    return;
                character.setEndTime(param);
                persistenceObject.Send(new CharacterEvent(character));
                activeTrackers.Remove("Character");
                break;
            case "FinalObtenido":
                persistenceObject.Send(new FinalEvent(param));
                break;

        }
    }
}
