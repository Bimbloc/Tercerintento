using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvent : TrackerEvent {
    int id;
    int sentence;
    int sprite;
    int sinner;
    int time;
    int judgement;
    List<int> favores;
    List<int> pecados;
    public CharacterEvent(CharacterAsset asset) {
        id = asset.getID();
        sentence = asset.getSentence();
        sprite = asset.getSprite();
        sinner = asset.getSinner();
        time = asset.getTime();
        judgement = asset.getJudgement();
        favores = asset.getFavores();
        pecados = asset.getPecados();
    }
}
