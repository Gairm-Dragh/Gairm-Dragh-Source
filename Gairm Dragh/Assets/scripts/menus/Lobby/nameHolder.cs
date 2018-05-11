using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.NetworkLobby;

public class nameHolder : MonoBehaviour {
    public GameObject playerList; //The player list
    public GameObject player; //The player
    public GameObject self; //This game object
    public GameObject blank; //Leave this blank

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        playerList = GameObject.Find("PlayerList");

        if (player == self && playerList != blank) {
            //Debug.Log("Equals");
            for (int i = 0; i < playerList.transform.childCount - 1; i++) {
                if (playerList.transform.GetChild(i).GetChild(6).gameObject.activeInHierarchy) {
                    player = playerList.transform.GetChild(i).gameObject;
                    break;
                }
            }
        }
        else if (playerList != blank) {
            globals.name = player.GetComponent<LobbyPlayer>().playerName;
        }
    }
}
