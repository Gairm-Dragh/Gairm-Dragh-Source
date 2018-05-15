using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIControl : NetworkBehaviour {
    public GameObject dragonName; //The text that holds the dragon name
    public string command = ""; //The command for this slot

    [SyncVar(hook = "OnOwnerChange")]
    public string owner; //The person who controls this UI

    public void OnOwnerChange(string newOwner) {
        owner = newOwner;
    }

    public void changeName(string newName) {
        dragonName.GetComponent<Text>().text = newName;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
}
