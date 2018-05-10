using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UIControl : NetworkBehaviour {

    [SyncVar]
    public string owner; //The person who controls this UI

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
