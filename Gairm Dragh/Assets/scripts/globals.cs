using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globals{
    public static int players = 0; //The number of players in the game
    public static int loaded = 0; //The nubmer of players loaded in
    public static string name; //The name of this player

    public static move[] moves = new move[24];
    public static Type[] types = new Type[9];
}
