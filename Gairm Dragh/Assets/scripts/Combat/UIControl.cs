using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : NetworkBehaviour {
    public GameObject dragonName; //The text that holds the dragon name

    [SyncVar]
    public string command = ""; //The command for this slot

    public GameObject move1, move2, move3, move4; //The buttons with the moves
    public GameObject switch1, switch2, switch3, switch4; //The buttons with the dragons to switch
    GameObject[] commandList = new GameObject[8];
    public GameObject[] UIList = new GameObject[8]; //The other UIs
    public bool dead = false; //Whether or not this slot is dead
    string temp = ""; //the temporary string for the command
    public int slot; //The number of this slot
    public int team; //The team the dragon is on

    public SyncList<string> moveNames = new SyncListString();

    public SyncList<int> moveIndecies = new SyncListInt();

    [SyncVar(hook = "OnOwnerChange")]
    public string owner; //The person who controls this UI

    public void OnOwnerChange(string newOwner) {
        owner = newOwner;
    }

    public void changeName(string newName) {
        dragonName.GetComponent<Text>().text = newName;
    }

    public string getRandomTarget() {
        string target = "";
        int targetNum = 0;
        bool found = false;

        while (!found) {
            targetNum = Random.Range(0, 3);

            if (team == 1) {
                targetNum += 4;
            }

            try {
                if (!UIList[targetNum].GetComponent<UIControl>().dead) {
                    found = true;
                }
            } catch {
                found = false;
            }
            
        }

        target = targetNum.ToString();

        return target;
    }

    [Command]
    public void CmdonTempChange(string com) {
        Debug.Log("Running the hook function.");
        command = com;
    }

    public void onTemp(int commandIndex) {
        temp = ""; //The temporary command, we don't changecommand until filled out

        if (dead) {
            temp = "true";
        } else {
            temp = "false,";

            if (commandIndex > 4) {
                temp += "true,";
                temp += (commandIndex - 5).ToString();
                temp += "," + slot.ToString();
            } else {
                temp += "false,";
                temp += commandList[commandIndex].GetComponent<command>().index;
                temp += ",";

                temp += getRandomTarget();
            }
        }

        Debug.Log("Got temp");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject play in players) {
            Debug.Log("We found some objects");
            Debug.Log(globals.name);
            Debug.Log(play.GetComponent<playerInfo>().playerName);
            if (play.GetComponent<playerInfo>().playerName == globals.name) {
                Debug.Log("One matches, running command");
                play.GetComponent<playerInfo>().CmdChangeCommand(temp, slot);
                break;
            }
        }

        //CmdonTempChange(temp);
    }

    public void OnNamesChange() {
        move1.GetComponent<Text>().text = moveNames[0];
        move2.GetComponent<Text>().text = moveNames[1];
        move3.GetComponent<Text>().text = moveNames[2];
        move4.GetComponent<Text>().text = moveNames[3];
    }

    public void OnIndeciesChange() {
        move1.GetComponent<command>().index = moveIndecies[0];
        move2.GetComponent<command>().index = moveIndecies[1];
        move3.GetComponent<command>().index = moveIndecies[2];
        move4.GetComponent<command>().index = moveIndecies[3];
    }

    // Use this for initialization
    void Start() {
        commandList[0] = move1;
        commandList[1] = move2;
        commandList[2] = move3;
        commandList[3] = move4;
        commandList[4] = switch1;
        commandList[5] = switch2;
        commandList[6] = switch3;
        commandList[7] = switch4;

        moveNames.Add("");
        moveNames.Add("");
        moveNames.Add("");
        moveNames.Add("");

        moveIndecies.Add(0);
        moveIndecies.Add(0);
        moveIndecies.Add(0);
        moveIndecies.Add(0);
    }

    // Update is called once per frame
    void Update() {
    }
}
