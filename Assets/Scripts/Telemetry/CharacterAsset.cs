using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAsset : ITrackerAsset {
    int _type;
    int _sentence;
    int _sprite;
    int _sinner;
    int _initTime;
    int _endTime;
    int _judgement;
    List<int> _favores = new List<int>();
    List<int> _pecados = new List<int>();

    public CharacterAsset(int initTime) {
        _initTime = initTime;
    }
    public void setType(int type) { _type = type; }
    public void setSentence(int sentence) { _sentence = sentence; }
    public void setSprite(int sprite) { _sprite = sprite; }
    public void setSinner(int sinner) { _sinner = sinner; }
    public void setEndTime(int endTime) { _endTime = endTime; }
    public void setJudgement(int judgement) { _judgement = judgement; }
    public void addFavor(int favor) { _favores.Add(favor); }
    public void addPecado(int pecado) { _pecados.Add(pecado); }


    public int getType() {
        return _type;
    }
    public int getSentence() { 
        return _sentence; 
    }
    public int getSprite() {
        return _sprite;
    }
    public int getSinner() {
        return _sinner;
    }
    public int getTime() {
        return _endTime - _initTime;
    }
    public int getJudgement() {
        return _judgement;
    }
    public List<int> getFavores() {
        return _favores;
    }
    public List<int> getPecados() {
        return _pecados;
    }

    public void Start() {
    
    }

    public void End() {
    
    }
}
