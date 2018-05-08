using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dragonControl : NetworkBehaviour {
    public GameObject dragon; //The dragon object this is attached to

    //[SyncVar]
    public int team; //The team this dragon is on

    //[SyncVar]
    public string type; //The type of the dragon

    public Sprite AngelicF, AngelicB; //The sprites for the dragons

    //changes the sprite to the correct type
    public void changeSprite() {
        Debug.Log("Changing sprite");
        if (type == "Angelic" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = AngelicB;
            
        }
        else if (type == "Angelic" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = AngelicF;
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        changeSprite();
    }
}
