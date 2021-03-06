﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dragonControl : NetworkBehaviour {
    public GameObject dragon; //The dragon object this is attached to

    [SyncVar]
    public int team; //The team this dragon is on

    [SyncVar]
    public string type; //The type of the dragon

    [SyncVar]
    public string dragonName;

    [SyncVar]
    public string command; //The command that thi slsot has in format "Switch?,Move/TargetDragon,TargetSlot"

    [SyncVar]
    public int healthPercent; //The percent for the health

    public Sprite AirB, AirF, AngelicB, AngelicF, BalanceB, BalanceF, DemonicB, DemonicF, EarthB, EarthF, FireB, FireF, GrassB, GrassF, ToxicB, ToxicF, WaterB, WaterF; //The sprites for the dragons
    public GameObject health; //The health bar
    public GameObject UI; //The UI this dragon goes to
    public int num; //The number of this slot
    public int healthPercentLast; //The last health percent we changed to
    public Dragon stats; //The dragon currently in this slot

    public void changeDragon(Dragon newDragon) {
        stats = newDragon;
        type = newDragon.type.name;
        dragonName = newDragon.nickname;
    }

    //changes the sprite to the correct type
    public void changeSprite() {
        if (type == "Air" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = AirB;

        }
        else if (type == "Air" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = AirF;
        }
        else if (type == "Angelic" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = AngelicB;

        }
        else if (type == "Angelic" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = AngelicF;
        }
        else if (type == "Balance" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = BalanceB;

        }
        else if (type == "Balance" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = BalanceF;
        }
        else if (type == "Demonic" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = DemonicB;

        }
        else if (type == "Demonic" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = DemonicF;
        }
        else if (type == "Earth" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = EarthB;

        }
        else if (type == "Earth" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = EarthF;
        }
        else if (type == "Fire" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = FireB;

        }
        else if (type == "Fire" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = FireF;
        }
        else if (type == "Grass" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = GrassB;

        }
        else if (type == "Grass" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = GrassF;
        }
        else if (type == "Toxic" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = ToxicB;

        }
        else if (type == "Toxic" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = ToxicF;
        }
        else if (type == "Water" && team == 1) {
            dragon.GetComponent<SpriteRenderer>().sprite = WaterB;

        }
        else if (type == "Water" && team == 2) {
            dragon.GetComponent<SpriteRenderer>().sprite = WaterF;
        }

        UI.GetComponent<UIControl>().changeName(dragonName);
    }

    public void changeHealth() {
        health.transform.localScale = new Vector3(healthPercentLast, 10, 1);
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        changeSprite();

        if (healthPercentLast != healthPercent) {
            healthPercentLast = healthPercent;
            changeHealth();
            
        }
    }
}
