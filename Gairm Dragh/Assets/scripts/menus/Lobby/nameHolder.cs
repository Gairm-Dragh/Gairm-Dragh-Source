using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prototype.NetworkLobby;

public class nameHolder : MonoBehaviour {
    public GameObject playerList; //The player list
    public GameObject player; //The player
    public GameObject self; //This game object

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (player == self) {
            //Debug.Log("Equals");
            for (int i = 0; i < playerList.transform.childCount - 1; i++) {
                if (playerList.transform.GetChild(i).GetChild(6).gameObject.activeInHierarchy) {
                    Debug.Log("Found the player");
                    player = playerList.transform.GetChild(i).gameObject;
                    break;
                }
                else {
                    Debug.Log("Still Looking");
                }
            }
        }
        else {
            globals.name = player.GetComponent<LobbyPlayer>().playerName;
        }
    }
}
