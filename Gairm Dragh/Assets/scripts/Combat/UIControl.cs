using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UIControl : NetworkBehaviour {

    [SyncVar(hook = "OnOwnerChange")]
    public string owner; //The person who controls this UI

    public void OnOwnerChange(string newOwner) {
        owner = newOwner;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
}
