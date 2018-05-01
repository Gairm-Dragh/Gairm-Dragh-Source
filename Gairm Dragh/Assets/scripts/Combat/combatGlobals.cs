using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class combatGlobals{ //This is where the general variables are stored
    //the teams
    [SyncVar]
    public static player[] team1 = new player[4];

    [SyncVar]
    public static player[] team2 = new player[4];
}
