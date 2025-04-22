using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAsset : ITrackerAsset {
    int _initTime;
    int _number;
    int _order;
    int _endTime;
    public DayAsset(int initTime) {
        _initTime = initTime;
    }
    public void setNumber(int number) {
        _number = number;
    }
    public void setOrder(int order) {
        _order = order;
    }
    public void setEndTime(int endTime) {
        _endTime = endTime;
    }
    public int getTime() {
        return _endTime - _initTime;
    }
    public int getOrder() {
        return _order;
    }
    public int getNumber() {
        return _number;
    }
    public void Start()
    {
    }
    public void End()
    {
    }

}
