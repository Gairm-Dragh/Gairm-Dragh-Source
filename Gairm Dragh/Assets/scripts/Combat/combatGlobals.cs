using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatGlobals : MonoBehaviour {
    //all the players
    public List<player> players = new List<player>();

    //the teams
    public List<player> team1 = new List<player>();
    public List<player> team2 = new List<player>();

    //the slots
    public GameObject[] slots = new GameObject[8];

    //whether or not you are host
    public bool host = false;

    private void Start() {
        //Debug.Log("Initing stuff");
        DragonGlobals.initTypes();
        DragonGlobals.initMoves();
    }
}
