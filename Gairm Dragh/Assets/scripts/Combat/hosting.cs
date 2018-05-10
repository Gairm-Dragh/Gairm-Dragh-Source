using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class hosting : NetworkBehaviour {

    public bool host = false; //Whether or not the player is host
    public bool ready = false; //Whether or not everyone is loaded in
    public bool setup = false; //Whether or not we have everything set up
    public GameObject UI1, UI2, UI3, UI4, UI5, UI6, UI7, UI8; //The UIs for interaction
    public GameObject dragon1, dragon2, dragon3, dragon4, dragon5, dragon6, dragon7, dragon8;
    public GameObject processing; //The background processing stuff

    //Labels the UI with the proper owner
    public void labelUI() {
        List<player> team1 = processing.GetComponent<combatGlobals>().team1;
        List<player> team2 = processing.GetComponent<combatGlobals>().team2;
        int team1Size = team1.Count;
        int team2Size = team2.Count;

        //distribute team 1's slots andsending out their initial dragons
        if (team1Size == 1) {
            UI1.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon1.GetComponent<dragonControl>().changeDragon(team1[0].dragon1);
            UI2.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon2.GetComponent<dragonControl>().changeDragon(team1[0].dragon2);
            UI3.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon3.GetComponent<dragonControl>().changeDragon(team1[0].dragon3);
            UI4.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon4.GetComponent<dragonControl>().changeDragon(team1[0].dragon4);

            team1[0].dragon1.inUse = true;
            team1[0].dragon2.inUse = true;
            team1[0].dragon3.inUse = true;
            team1[0].dragon4.inUse = true;
        }
        else if (team1Size == 2) {
            UI1.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon1.GetComponent<dragonControl>().changeDragon(team1[0].dragon1);
            UI2.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon2.GetComponent<dragonControl>().changeDragon(team1[0].dragon2);
            UI3.GetComponent<UIControl>().OnOwnerChange(team1[1].name);
            dragon3.GetComponent<dragonControl>().changeDragon(team1[1].dragon1);
            UI4.GetComponent<UIControl>().OnOwnerChange(team1[1].name);
            dragon4.GetComponent<dragonControl>().changeDragon(team1[1].dragon2);

            team1[0].dragon1.inUse = true;
            team1[0].dragon2.inUse = true;
            team1[1].dragon1.inUse = true;
            team1[1].dragon2.inUse = true;
        }
        else if (team1Size == 3) {
            UI1.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon1.GetComponent<dragonControl>().changeDragon(team1[0].dragon1);
            UI2.GetComponent<UIControl>().OnOwnerChange(team1[1].name);
            dragon2.GetComponent<dragonControl>().changeDragon(team1[1].dragon1);
            UI3.GetComponent<UIControl>().OnOwnerChange(team1[1].name);
            dragon3.GetComponent<dragonControl>().changeDragon(team1[1].dragon2);
            UI4.GetComponent<UIControl>().OnOwnerChange(team1[2].name);
            dragon4.GetComponent<dragonControl>().changeDragon(team1[2].dragon1);

            team1[0].dragon1.inUse = true;
            team1[1].dragon1.inUse = true;
            team1[1].dragon2.inUse = true;
            team1[2].dragon1.inUse = true;
        }
        else if (team1Size == 4) {
            UI1.GetComponent<UIControl>().OnOwnerChange(team1[0].name);
            dragon1.GetComponent<dragonControl>().changeDragon(team1[0].dragon1);
            UI2.GetComponent<UIControl>().OnOwnerChange(team1[1].name);
            dragon2.GetComponent<dragonControl>().changeDragon(team1[1].dragon1);
            UI3.GetComponent<UIControl>().OnOwnerChange(team1[2].name);
            dragon3.GetComponent<dragonControl>().changeDragon(team1[2].dragon1);
            UI4.GetComponent<UIControl>().OnOwnerChange(team1[3].name);
            dragon4.GetComponent<dragonControl>().changeDragon(team1[3].dragon1);

            team1[0].dragon1.inUse = true;
            team1[1].dragon1.inUse = true;
            team1[2].dragon1.inUse = true;
            team1[3].dragon1.inUse = true;
        }

        //distribute team 2's slots
        if (team2Size == 1) {
            UI5.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon5.GetComponent<dragonControl>().changeDragon(team2[0].dragon1);
            UI6.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon6.GetComponent<dragonControl>().changeDragon(team2[0].dragon2);
            UI7.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon7.GetComponent<dragonControl>().changeDragon(team2[0].dragon3);
            UI8.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon8.GetComponent<dragonControl>().changeDragon(team2[0].dragon4);

            team2[0].dragon1.inUse = true;
            team2[0].dragon2.inUse = true;
            team2[0].dragon3.inUse = true;
            team2[0].dragon4.inUse = true;
        }
        else if (team2Size == 2) {
            UI5.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon5.GetComponent<dragonControl>().changeDragon(team2[0].dragon1);
            UI6.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon6.GetComponent<dragonControl>().changeDragon(team2[0].dragon2);
            UI7.GetComponent<UIControl>().OnOwnerChange(team2[1].name);
            dragon7.GetComponent<dragonControl>().changeDragon(team2[1].dragon1);
            UI8.GetComponent<UIControl>().OnOwnerChange(team2[1].name);
            dragon8.GetComponent<dragonControl>().changeDragon(team2[1].dragon2);

            team2[0].dragon1.inUse = true;
            team2[0].dragon2.inUse = true;
            team2[1].dragon1.inUse = true;
            team2[1].dragon2.inUse = true;
        }
        else if (team2Size == 3) {
            UI5.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon5.GetComponent<dragonControl>().changeDragon(team2[0].dragon1);
            UI6.GetComponent<UIControl>().OnOwnerChange(team2[1].name);
            dragon6.GetComponent<dragonControl>().changeDragon(team2[1].dragon1);
            UI7.GetComponent<UIControl>().OnOwnerChange(team2[1].name);
            dragon7.GetComponent<dragonControl>().changeDragon(team2[1].dragon2);
            UI8.GetComponent<UIControl>().OnOwnerChange(team2[2].name);
            dragon8.GetComponent<dragonControl>().changeDragon(team2[2].dragon1);

            team2[0].dragon1.inUse = true;
            team2[1].dragon1.inUse = true;
            team2[1].dragon2.inUse = true;
            team2[2].dragon1.inUse = true;
        }
        else if (team2Size == 4) {
            UI5.GetComponent<UIControl>().OnOwnerChange(team2[0].name);
            dragon5.GetComponent<dragonControl>().changeDragon(team2[0].dragon1);
            UI6.GetComponent<UIControl>().OnOwnerChange(team2[1].name);
            dragon6.GetComponent<dragonControl>().changeDragon(team2[1].dragon1);
            UI7.GetComponent<UIControl>().OnOwnerChange(team2[2].name);
            dragon7.GetComponent<dragonControl>().changeDragon(team2[2].dragon1);
            UI8.GetComponent<UIControl>().OnOwnerChange(team2[3].name);
            dragon8.GetComponent<dragonControl>().changeDragon(team2[3].dragon1);

            team2[0].dragon1.inUse = true;
            team2[1].dragon1.inUse = true;
            team2[2].dragon1.inUse = true;
            team2[3].dragon1.inUse = true;
        }
    }

    // Use this for initialization
    void Start() {
        Debug.Log(globals.name);
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
