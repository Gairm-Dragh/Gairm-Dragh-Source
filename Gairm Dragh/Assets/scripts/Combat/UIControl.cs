using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIControl : NetworkBehaviour {
    public GameObject name; //Thetext that holds the dragon name

    [SyncVar(hook = "OnOwnerChange")]
    public string owner; //The person who controls this UI

    public void OnOwnerChange(string newOwner) {
        owner = newOwner;
    }

    public void changeName(string newName) {
        name.GetComponent<Text>().text = newName;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
}
