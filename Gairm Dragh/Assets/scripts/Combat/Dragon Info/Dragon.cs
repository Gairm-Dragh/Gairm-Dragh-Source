using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon { //The Dragon Class is used for keeping track of the stats of dragons
    public int maxHP, currentHP, ATK, DEF, SPA, SPD, SPE, move1, move2, move3, move4, move5, level; //the stats of the dragon
    public Type type; //the type of the dragon
    public string nickname; //the nickname of the dragon
    int[] EVs = new int[6]; //the EVs of the dragon
    int[] IVs = new int[6]; //the IVs of the dragon
    public string age; //the age of the dragon

    void calcStats() {
        this.maxHP = ((2 * type.HP + IVs[0] + (EVs[0] / 4)) * level / 100) + level + 10;
        this.ATK = (2 * type.ATK + IVs[1] + (EVs[1] / 4) * level / 100) + 5;
        this.DEF = (2 * type.DEF + IVs[2] + (EVs[2] / 4) * level / 100) + 5;
        this.SPA = (2 * type.SPA + IVs[3] + (EVs[3] / 4) * level / 100) + 5;
        this.SPD = (2 * type.SPD + IVs[4] + (EVs[4] / 4) * level / 100) + 5;
        this.SPE = (2 * type.SPE + IVs[5] + (EVs[5] / 4) * level / 100) + 5;
    }

    //Dragon intializer
    public Dragon(Type ty, int lvl, int[] EV, int[] IV, string name) {
        type = ty;
        level = lvl;
        EVs = EV;
        IVs = IV;
        calcStats();
        currentHP = maxHP;
        nickname = name;
    }

}
