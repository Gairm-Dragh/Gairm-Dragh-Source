using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move{ //This is the class for moves
    public int power, pp; //The pwoer of the move and its PP
    public string name; //The name of the move
    public Type type; //The move's type
    public bool physical; //whether or not the move is physical

    public move(int pow, int p, string nam, Type typ, bool phys) {
        power = pow;
        pp = p;
        name = nam;
        type = typ;
        physical = phys;
    }
}
