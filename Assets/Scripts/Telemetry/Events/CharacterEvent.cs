using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvent : ITrackerEvent {
    int type;
    int sentence;
    int sprite;
    int sinner;
    int time;
    int judgement;
    List<int> favores;
    List<int> pecados;
    public CharacterEvent(CharacterAsset asset) {
        type = asset.getType();
        sentence = asset.getSentence();
        sprite = asset.getSprite();
        sinner = asset.getSinner();
        time = asset.getTime();
        judgement = asset.getJudgement();
        favores = asset.getFavores();
        pecados = asset.getPecados();
    }

    public Dictionary<string, object> getParams()
    {
        Dictionary<string, object> valuePairs = new Dictionary<string, object>();

        valuePairs.Add("type", type);
        valuePairs.Add("sentence", sentence);
        valuePairs.Add("sprite", sprite);
        valuePairs.Add("sinner", sinner);
        valuePairs.Add("time", time);
        valuePairs.Add("judgement", judgement);
        valuePairs.Add("favores", favores);
        valuePairs.Add("pecados", pecados);

        return valuePairs;
    }
}
