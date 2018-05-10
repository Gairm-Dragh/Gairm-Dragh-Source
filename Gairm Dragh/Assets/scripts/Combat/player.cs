using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player { //this class is for storing the data for each player in the combat
    public Dragon dragon1, dragon2, dragon3, dragon4; //The dragons the player has
    public int playerNum; //The position number of the player, needed for file searching
    public string name;
    public int team;
    public Dragon[] dragons = new Dragon[4];

    public player(string nam, Type[] types, int[] levels, int[][] EVs, int[][] IVs, string[] names, int tem, move[][] moves) {

        //initialize the dragons for this player, there will always be 4
        dragon1 = new Dragon(types[0], levels[0], EVs[0], IVs[0], names[0], moves[0]);
        dragon2 = new Dragon(types[1], levels[1], EVs[1], IVs[1], names[1], moves[1]);
        dragon3 = new Dragon(types[2], levels[2], EVs[2], IVs[2], names[2], moves[2]);
        dragon4 = new Dragon(types[3], levels[3], EVs[3], IVs[3], names[3], moves[3]);
        dragons[0] = dragon1;
        dragons[1] = dragon1;
        dragons[2] = dragon1;
        dragons[3] = dragon1;
        name = nam;
        team = tem;
    }

}
