using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class DragonGlobals{ //this is the set for keeping track of the generic stats for combat

    public static player player1, player2, player3, player4, player5, player6, player7, player8;
    public static int players; //# of players in the game
    public static Type Fire, Water, Earth, Air, Angelic, Demonic, Balance, Grass, Toxic; //The types
    public static Type[] types = new Type[9]; //array to hold all of the types
    public static Dragon[] dragons; //array of al the dragons, size will depend on how many players there are

    static public void initTypes() {
        //Initializing the types
        Fire = new Type(71, 120, 95, 120, 95, 99, 0, "Fire");
        Water = new Type(80, 80, 90, 110, 130, 110, 1, "Water");
        Earth = new Type(80, 135, 130, 95, 90, 70, 2, "Earth");
        Air = new Type(50, 95, 90, 95, 90, 180, 3, "Air");
        Angelic = new Type(108, 130, 95, 80, 85, 102, 4, "Angelic");
        Demonic = new Type(55, 50, 65, 175, 105, 150, 5, "Demonic");
        Balance = new Type(50, 150, 50, 150, 50, 150, 6, "Balance");
        Grass = new Type(91, 90, 106, 130, 106, 77, 7, "Grass");
        Toxic = new Type(120, 70, 120, 75, 130, 85, 8, "Toxic");

        //putting the types into the types array
        types[0] = Fire;
        types[1] = Water;
        types[2] = Earth;
        types[3] = Air;
        types[4] = Angelic;
        types[5] = Demonic;
        types[6] = Balance;
        types[7] = Grass;
        types[8] = Toxic;
    }
}