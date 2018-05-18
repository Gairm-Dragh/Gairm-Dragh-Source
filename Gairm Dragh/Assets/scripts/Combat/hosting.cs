using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class hosting : NetworkBehaviour {

    public bool host = false; //Whether or not the player is host
    public bool ready = false; //Whether or not everyone is loaded in
    public bool setup = false; //Whether or not we have everything set up
    public bool commands = false; //Whether or not all commands have been input
    public GameObject UI1, UI2, UI3, UI4, UI5, UI6, UI7, UI8; //The UIs for interaction
    public GameObject dragon1, dragon2, dragon3, dragon4, dragon5, dragon6, dragon7, dragon8; //The dragon sprites
    public GameObject x1, x2, x3, x4, x5, x6, x7, x8; //The xs
    public GameObject health1, health2, health3, health4, health5, health6, health7, health8; //The health bars
    public GameObject processing; //The background processing stuff
    public GameObject[] UIs = new GameObject[8];
    GameObject[] dragons = new GameObject[8];
    GameObject[] xs = new GameObject[8];
    List<player> team1;
    List<player> team2;

    [SyncVar(hook = "OnLabeledChanged")]
    public bool labeled = false; //Whether or not stuff is labeled

    //Labels the UI with the proper owner
    public void labelUI() {
        team1 = processing.GetComponent<combatGlobals>().team1;
        team2 = processing.GetComponent<combatGlobals>().team2;

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

            switchDragons(1, team1[0].dragon1);
            switchDragons(2, team1[0].dragon2);
            switchDragons(3, team1[0].dragon3);
            switchDragons(4, team1[0].dragon4);
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

            switchDragons(1, team1[0].dragon1);
            switchDragons(2, team1[0].dragon2);
            switchDragons(3, team1[1].dragon1);
            switchDragons(4, team1[1].dragon2);
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

            switchDragons(1, team1[0].dragon1);
            switchDragons(2, team1[1].dragon1);
            switchDragons(3, team1[1].dragon2);
            switchDragons(4, team1[2].dragon1);
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

            switchDragons(1, team1[0].dragon1);
            switchDragons(2, team1[1].dragon1);
            switchDragons(3, team1[2].dragon1);
            switchDragons(4, team1[3].dragon1);
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

            switchDragons(5, team2[0].dragon1);
            switchDragons(6, team2[0].dragon2);
            switchDragons(7, team2[0].dragon3);
            switchDragons(8, team2[0].dragon4);
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

            switchDragons(5, team2[0].dragon1);
            switchDragons(6, team2[0].dragon2);
            switchDragons(7, team2[1].dragon1);
            switchDragons(8, team2[1].dragon2);
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

            switchDragons(5, team2[0].dragon1);
            switchDragons(6, team2[1].dragon1);
            switchDragons(7, team2[1].dragon2);
            switchDragons(8, team2[2].dragon1);
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

            switchDragons(5, team2[0].dragon1);
            switchDragons(6, team2[1].dragon1);
            switchDragons(7, team2[2].dragon1);
            switchDragons(8, team2[3].dragon1);
        }
    }

    public void OnLabeledChanged(bool newLabel) {
        labeled = newLabel;
    }

    public int findMoveIndex(move move) {
        int index = -1;

        for (int i = 0; i < globals.moves.Length; i++) {
            if (globals.moves[i] == move) {
                index = i;
            }
            else {
            }
        }
        return index;
    }

    public void switchDragons(int slot, Dragon newDrag) {
        dragons[slot - 1].GetComponent<dragonControl>().type = newDrag.type.name;
        dragons[slot - 1].GetComponent<dragonControl>().name = newDrag.nickname;

        UIs[slot - 1].GetComponent<UIControl>().moveName1 = newDrag.moves[0].name;
        UIs[slot - 1].GetComponent<UIControl>().moveName2 = newDrag.moves[1].name;
        UIs[slot - 1].GetComponent<UIControl>().moveName3 = newDrag.moves[2].name;
        UIs[slot - 1].GetComponent<UIControl>().moveName4 = newDrag.moves[3].name;
        //UIs[slot - 1].GetComponent<UIControl>().OnNamesChange();

        UIs[slot - 1].GetComponent<UIControl>().moveIndex1 = findMoveIndex(newDrag.moves[0]);
        UIs[slot - 1].GetComponent<UIControl>().moveIndex2 = findMoveIndex(newDrag.moves[1]);
        UIs[slot - 1].GetComponent<UIControl>().moveIndex3 = findMoveIndex(newDrag.moves[2]);
        UIs[slot - 1].GetComponent<UIControl>().moveIndex4 = findMoveIndex(newDrag.moves[3]);
        //UIs[slot - 1].GetComponent<UIControl>().OnIndeciesChange();

        UIs[slot - 1].GetComponent<UIControl>().changeName(newDrag.nickname);
    }

    //checks if all slots have sent a command
    public bool checkReady() {
        for (int i = 0; i < UIs.Length; i++) {
            if (UIs[i].GetComponent<UIControl>().command == "") {
                return false;
            }
        }

        return true;
    }

    void damageCheck(int crit, move move, Dragon target, Dragon user) {
        float typage = 1f; //The type (dis)advantage

        foreach (Type weakness in target.type.weaknesses) {
            if (weakness == move.type) {
                typage = 2f;
                break;
            }
        }

        foreach (Type resistance in target.type.resistances) {
            if (resistance == move.type) {
                typage = 0.5f;
                break;
            }
        }

        int ATK = 0;
        int DEF = 0;
        float STAB = 1f;

        //select physical or special stats
        if (move.physical) {
            ATK = user.ATK;
            DEF = target.DEF;
        }
        else {
            ATK = user.SPA;
            DEF = target.SPD;
        }

        //check for stab
        if (move.type == user.type) {
            STAB = 1.5f;
        }

        target.currentHP -= Mathf.FloorToInt(((((((2 * user.level) / 5) + 2) * move.power * ATK / DEF) / 50) + 2) * crit * STAB * typage);
    }

    void critCheck(move move, Dragon target, Dragon user) {
        if (Random.Range(0, 100) > 94) {
            damageCheck(2, move, target, user);
        }
        else {
            damageCheck(1, move, target, user);
        }
    }

    void accCheck(move move, Dragon target, Dragon user) {
        //check if the move will auto hit
        if (move.accuracy == 0) {
            critCheck(move, target, user);
        }
        else if (Random.Range(0, 100) > move.accuracy) {
            critCheck(move, target, user);
        }
    }

    void commandsGo() {
        //Go through each UI to determine result
        for (int i = 0; i < UIs.Length; i++) {
            GameObject UI = UIs[i];
            string command = UI.GetComponent<UIControl>().command;

            //check if it's dead or not
            if (command != "true") {
                //get each part
                string[] commandSplice = command.Split(',');

                //fight
                if (commandSplice[1] != "true") {
                    //goes through the stuff to hit
                    accCheck(globals.moves[int.Parse(commandSplice[2])], dragons[int.Parse(commandSplice[3])].GetComponent<dragonControl>().stats, dragons[i].GetComponent<dragonControl>().stats);

                    //edits health bars and faints if at 0
                    if (dragons[i].GetComponent<dragonControl>().stats.currentHP == 0) {

                    }
                }
            }
        }
    }

    // Use this for initialization
    void Start() {
        //Debug.Log(globals.name);

        UIs[0] = UI1;
        UIs[1] = UI2;
        UIs[2] = UI3;
        UIs[3] = UI4;
        UIs[4] = UI5;
        UIs[5] = UI6;
        UIs[6] = UI7;
        UIs[7] = UI8;

        dragons[0] = dragon1;
        dragons[1] = dragon2;
        dragons[2] = dragon3;
        dragons[3] = dragon4;
        dragons[4] = dragon5;
        dragons[5] = dragon6;
        dragons[6] = dragon7;
        dragons[7] = dragon8;

        xs[0] = x1;
        xs[1] = x2;
        xs[2] = x3;
        xs[3] = x4;
        xs[4] = x5;
        xs[5] = x6;
        xs[6] = x7;
        xs[7] = x8;

        /*
        healths[0] = health1;
        healths[1] = health2;
        healths[2] = health3;
        healths[3] = health4;
        healths[4] = health5;
        healths[5] = health6;
        healths[6] = health7;
        healths[7] = health8;
        */
    }

    // Update is called once per frame
    void Update() {
        if (host) {
            if (globals.players == globals.loaded) {
                ready = true;
            }

            if (ready) {
                labelUI();
                OnLabeledChanged(true);
            }
        }

        //distributes the labels
        if (labeled) {
            for (int i = 0; i < UIs.Length; i++) {
                if (UIs[i].GetComponent<UIControl>().owner == globals.name) {
                    UIs[i].SetActive(true);
                }
                else {
                    UIs[i].SetActive(false);
                    xs[i].SetActive(true);
                }
            }

            setup = true;
        }

        commands = checkReady();

        //processes the commands if all of them are no longer blank
        if (commands) {
            //TODO: actually process the commands
            commandsGo();

            //Blanks all the commands for next time
            for (int i = 0; i < UIs.Length; i++) {
                UIs[i].GetComponent<UIControl>().command = "";
            }
        }
    }
}
