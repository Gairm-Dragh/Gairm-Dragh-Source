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

        //Giving each type its weaknesses and resistances
        Fire.resistances.Add(Fire);
        Fire.resistances.Add(Air);
        Fire.resistances.Add(Angelic);
        Fire.resistances.Add(Grass);
        Fire.weaknesses.Add(Water);
        Fire.weaknesses.Add(Earth);
        Fire.weaknesses.Add(Balance);
        Water.resistances.Add(Fire);
        Water.resistances.Add(Water);
        Water.resistances.Add(Earth);
        Water.resistances.Add(Demonic);
        Water.weaknesses.Add(Balance);
        Water.weaknesses.Add(Toxic);
        Water.weaknesses.Add(Grass);
        Earth.resistances.Add(Fire);
        Earth.resistances.Add(Earth);
        Earth.weaknesses.Add(Water);
        Earth.weaknesses.Add(Air);
        Earth.weaknesses.Add(Balance);
        Earth.weaknesses.Add(Angelic);
        Earth.weaknesses.Add(Grass);
        Earth.weaknesses.Add(Toxic);
        Air.resistances.Add(Earth);
        Air.resistances.Add(Air);
        Air.resistances.Add(Demonic);
        Air.resistances.Add(Grass);
        Air.weaknesses.Add(Fire);
        Air.weaknesses.Add(Balance);
        Balance.resistances.Add(Balance);
        Balance.weaknesses.Add(Fire);
        Balance.weaknesses.Add(Water);
        Balance.weaknesses.Add(Earth);
        Balance.weaknesses.Add(Air);
        Balance.weaknesses.Add(Angelic);
        Balance.weaknesses.Add(Demonic);
        Angelic.resistances.Add(Water);
        Angelic.resistances.Add(Earth);
        Angelic.resistances.Add(Angelic);
        Angelic.weaknesses.Add(Fire);
        Angelic.weaknesses.Add(Balance);
        Angelic.weaknesses.Add(Demonic);
        Angelic.weaknesses.Add(Toxic);
        Demonic.resistances.Add(Toxic);
        Demonic.weaknesses.Add(Water);
        Demonic.weaknesses.Add(Air);
        Demonic.weaknesses.Add(Balance);
        Demonic.weaknesses.Add(Angelic);
        Demonic.weaknesses.Add(Demonic);
        Grass.resistances.Add(Water);
        Grass.resistances.Add(Grass);
        Grass.weaknesses.Add(Fire);
        Grass.weaknesses.Add(Air);
        Grass.weaknesses.Add(Toxic);
        Toxic.resistances.Add(Water);
        Toxic.resistances.Add(Angelic);
        Toxic.resistances.Add(Grass);

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

        globals.types = types;
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
        moves[2] = Crunch;
        moves[3] = Thundershock;
        moves[4] = Thunderbolt;
        moves[5] = Thunder;
        moves[6] = Ember;
        moves[7] = Flamethrower;
        moves[8] = Overheat;
        moves[9] = VineWhip;
        moves[10] = RazorLeaf;
        moves[11] = MagicalLeaf;
        moves[12] = LeafBlade;
        moves[13] = Earthquake;
        moves[14] = MudShot;
        moves[15] = PoisonSting;
        moves[16] = Acid;
        moves[17] = Smite;
        moves[18] = HolyWater;
        moves[19] = Neutralize;
        moves[20] = Unbalance;
        moves[21] = HydroPump;
        moves[22] = BubbleBeam;
        moves[23] = HydroCannon;

        globals.moves = moves;
    }
}