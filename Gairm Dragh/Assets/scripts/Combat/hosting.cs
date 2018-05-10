using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class hosting : NetworkBehaviour {

    public bool host = false; //Whether or not the player is host
    public bool ready = false; //Whether or not everyone is loaded in
    public bool setup = false; //Whether or not we have everything set up
    public GameObject UI1, UI2, UI3, UI4, UI5, UI6, UI7, UI8; //The UIs for interaction
    public GameObject processing; //The background processing stuff

    //Labels the UI with the proper owner
    public void labelUI() {
        List<player> team1 = processing.GetComponent<combatGlobals>().team1;
        List<player> team2 = processing.GetComponent<combatGlobals>().team2;
        int team1Size = team1.Count;
        int team2Size = team2.Count;

        //distribute team 1's slots
        if (team1Size == 1) {
            UI1.GetComponent<UIControl>().owner = team1[0].name;
            UI2.GetComponent<UIControl>().owner = team1[0].name;
            UI3.GetComponent<UIControl>().owner = team1[0].name;
            UI4.GetComponent<UIControl>().owner = team1[0].name;
        }
        else if (team1Size == 2) {
            UI1.GetComponent<UIControl>().owner = team1[0].name;
            UI2.GetComponent<UIControl>().owner = team1[0].name;
            UI3.GetComponent<UIControl>().owner = team1[1].name;
            UI4.GetComponent<UIControl>().owner = team1[1].name;
        }
        else if (team1Size == 3) {
            UI1.GetComponent<UIControl>().owner = team1[0].name;
            UI2.GetComponent<UIControl>().owner = team1[1].name;
            UI3.GetComponent<UIControl>().owner = team1[1].name;
            UI4.GetComponent<UIControl>().owner = team1[2].name;
        }
        else if (team1Size == 4) {
            UI1.GetComponent<UIControl>().owner = team1[0].name;
            UI2.GetComponent<UIControl>().owner = team1[1].name;
            UI3.GetComponent<UIControl>().owner = team1[2].name;
            UI4.GetComponent<UIControl>().owner = team1[3].name;
        }

        //distribute team 2's slots
        if (team2Size == 1) {
            UI5.GetComponent<UIControl>().owner = team2[0].name;
            UI6.GetComponent<UIControl>().owner = team2[0].name;
            UI7.GetComponent<UIControl>().owner = team2[0].name;
            UI8.GetComponent<UIControl>().owner = team2[0].name;
        }
        else if (team2Size == 2) {
            UI5.GetComponent<UIControl>().owner = team2[0].name;
            UI6.GetComponent<UIControl>().owner = team2[0].name;
            UI7.GetComponent<UIControl>().owner = team2[1].name;
            UI8.GetComponent<UIControl>().owner = team2[1].name;
        }
        else if (team2Size == 3) {
            UI5.GetComponent<UIControl>().owner = team2[0].name;
            UI6.GetComponent<UIControl>().owner = team2[1].name;
            UI7.GetComponent<UIControl>().owner = team2[1].name;
            UI8.GetComponent<UIControl>().owner = team2[2].name;
        }
        else if (team2Size == 4) {
            UI5.GetComponent<UIControl>().owner = team2[0].name;
            UI6.GetComponent<UIControl>().owner = team2[1].name;
            UI7.GetComponent<UIControl>().owner = team2[2].name;
            UI8.GetComponent<UIControl>().owner = team2[3].name;
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (host) {
            if (globals.players == globals.loaded) {
                ready = true;
            }

            if (ready) {
                labelUI();
            }
        }
    }
}
