using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type { //The type class is used for keeping track of the base stats of each type
    public int HP, ATK, DEF, SPA, SPD, SPE; //The base stats of the type
    public int typeIndex; //The index for the type
    public string name; //The name of the type
    public List<Type> resistances = new List<Type>();
    public List<Type> weaknesses = new List<Type>();

    //initializer for the class
    public Type(int H, int A, int D, int SA, int SD, int SP, int ind, string nam) {
        HP = H;
        ATK = A;
        DEF = D;
        SPA = SA;
        SPD = SD;
        SPE = SP;
        typeIndex = ind;
        name = nam;
    }
}
