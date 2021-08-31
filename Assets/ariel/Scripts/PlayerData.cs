using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool hasDict;
    public bool hasGlasses;
    public bool hasHearingAid;
    public bool hasHandle;
    public bool placeHandle;
    public bool passDoor1;
    public bool passDoor2;
    public bool passDoor3;
    public string playerType;

    public PlayerData(Player player){
        hasDict = player.hasDict;
        hasGlasses = player.hasGlasses;
        hasHearingAid = player.hasHearingAid;
        hasHandle = player.hasHandle;
        placeHandle = player.placeHandle;
        passDoor1 = player.passDoor1;
        passDoor2 = player.passDoor2;
        passDoor3 = player.passDoor3;
        playerType = player.playerType;
    }
}
