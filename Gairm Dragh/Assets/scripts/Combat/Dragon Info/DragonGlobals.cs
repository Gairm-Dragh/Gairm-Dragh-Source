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
    public static move[] moves = new move[24];

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

    static public void initMoves() {
        //initializing the classes
        move Bite = new move(60, 25, "Bite", Demonic, true, 100);
        move FeintAttack = new move(60, 20, "Feint Attack", Demonic, true, 0);
        move Crunch = new move(80, 15, "Crunch", Demonic, true, 100);
        move Thundershock = new move(40, 30, "Thundershock", Air, false, 100);
        move Thunderbolt = new move(90, 15, "Thunderbolt", Air, false, 100);
        move Thunder = new move(110, 10, "Thunder", Air, false, 70);
        move Ember = new move(40, 25, "Ember", Fire, false, 100);
        move Flamethrower = new move(90, 15, "Flamethrower", Fire, false, 100);
        move Overheat = new move(130, 5, "Overheat", Fire, false, 90);
        move VineWhip = new move(45, 25, "Vine Whip", Grass, true, 100);
        move RazorLeaf = new move(55, 25, "Razor Leaf", Grass, true, 95);
        move MagicalLeaf = new move(60, 20, "Magical Leaf", Grass, false, 0);
        move LeafBlade = new move(90, 15, "Leaf Blade", Grass, true, 100);
        move Earthquake = new move(100, 10, "Earthquake", Earth, true, 100);
        move MudShot = new move(55, 15, "Mud Shot", Earth, false, 95);
        move PoisonSting = new move(15, 35, "Poison Sting", Toxic, true, 100);
        move Acid = new move(40, 30, "Acid", Toxic, false, 100);
        move Smite = new move(140, 5, "Smite", Angelic, false, 90);
        move HolyWater = new move(65, 20, "Holy Water", Angelic, false, 100);
        move Neutralize = new move(90, 10, "Neutralize", Balance, false, 100);
        move Unbalance = new move(100, 15, "Unbalance", Balance, false, 100);
        move HydroPump = new move(110, 5, "Hydro Pump", Water, false, 80);
        move BubbleBeam = new move(65, 20, "Bubble Beam", Water, false, 100);
        move HydroCannon = new move(150, 5, "Hydro Cannon", Water, false, 90);

        //putting the moves in the array
        moves[0] = Bite;
        moves[1] = FeintAttack;
        moves[3] = Crunch;
        moves[4] = Thundershock;
        moves[5] = Thunderbolt;
        moves[6] = Thunder;
        moves[7] = Ember;
        moves[8] = Flamethrower;
        moves[9] = Overheat;
        moves[10] = VineWhip;
        moves[11] = RazorLeaf;
        moves[12] = MagicalLeaf;
        moves[13] = LeafBlade;
        moves[14] = Earthquake;
        moves[15] = MudShot;
        moves[16] = PoisonSting;
        moves[17] = Acid;
        moves[18] = Smite;
        moves[19] = HolyWater;
        moves[20] = Neutralize;
        moves[21] = Unbalance;
        moves[22] = HydroPump;
        moves[23] = BubbleBeam;
        moves[24] = HydroCannon;
    }
}