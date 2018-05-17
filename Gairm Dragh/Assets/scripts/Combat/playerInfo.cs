using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerInfo : NetworkBehaviour { //This class holds the information of a player
    public string playerName; //The name of the player
    public int playerTeam; //The team of the palyer
    public player player; //The palyer itself
    string[] names = new string[100]; //All the random names
    Type[] allTypes = DragonGlobals.types; //Al the types
    move[] allMoves = DragonGlobals.moves;
    public GameObject processing;
    public bool host = false; //whether or not the player is host
    public bool doneLoaded = false; //Whether or not we've run through the update loop and succeeded
    public bool found = false; //Whether or not things are found
    GameObject blank; //Leave this blank

    [Command]
    public void CmdChangeCommand(string command, int slot) {
        processing.GetComponent<hosting>().UIs[slot - 1].GetComponent<UIControl>().command = command;
    }

    //creates a random team of dragons to initialize into a player
    public void randomTeam() {
        //setting the names
        names[1] = "Grilban";
        names[2] = "Kaynno";
        names[3] = "Grimenth";
        names[4] = "Koldro";
        names[5] = "Iga";
        names[6] = "Morvu";
        names[7] = "Unnyg";
        names[8] = "Imracrien";
        names[9] = "Cheinyrorth";
        names[10] = "Meitiros";
        names[11] = "Viekoss";
        names[12] = "Essonth";
        names[13] = "Yndray";
        names[14] = "Fumrass";
        names[15] = "Comrimth";
        names[16] = "Yrolth";
        names[17] = "Giozzeirth";
        names[18] = "Shiomrinath";
        names[19] = "Vemmayla";
        names[20] = "Sormuli";
        names[21] = "Puvnaenth";
        names[22] = "Iolriss";
        names[23] = "Tiezzud";
        names[24] = "Xoadhias";
        names[25] = "Qaikuth";
        names[26] = "Nulrut";
        names[27] = "Deinulth";
        names[28] = "Naervionit";
        names[29] = "Raydrainiarth";
        names[30] = "Freomuderth";
        names[31] = "Ivo";
        names[32] = "Sille";
        names[33] = "Dervie";
        names[34] = "Aerys";
        names[35] = "Nothurth";
        names[36] = "Dandel";
        names[37] = "Chemeit";
        names[38] = "Haghyphior";
        names[39] = "Urmoruth";
        names[40] = "Cikeneth";
        names[41] = "Cozer";
        names[42] = "Dennyth";
        names[43] = "Golrut";
        names[44] = "Zovarth";
        names[45] = "Franeorth";
        names[46] = "Gelzriar";
        names[47] = "Grudrod";
        names[48] = "Yvysduss";
        names[49] = "Pirsodorth";
        names[50] = "Cydiantenth";
        names[51] = "Xayvie";
        names[52] = "Ulria";
        names[53] = "Coty";
        names[54] = "Cheisut";
        names[55] = "Xuroit";
        names[56] = "Sylriar";
        names[57] = "Qayris";
        names[58] = "Aezonelth";
        names[59] = "Tylryssaet";
        names[60] = "Xaireodayt";
        names[61] = "Qainalth";
        names[62] = "Mymmut";
        names[63] = "Ero";
        names[64] = "Ophyr";
        names[65] = "Vimmunth";
        names[66] = "Ermei";
        names[67] = "Vepeoss";
        names[68] = "Pezzedy";
        names[69] = "Haivnuly";
        names[70] = "Lymmossyn";
        names[71] = "Rogin";
        names[72] = "Eddri";
        names[73] = "Genar";
        names[74] = "Besym";
        names[75] = "Rysian";
        names[76] = "Tenirth";
        names[77] = "Yginth";
        names[78] = "Burudeg";
        names[79] = "Pytinty";
        names[80] = "Chyterass";
        names[81] = "Xoizoi";
        names[82] = "Dighor";
        names[83] = "Railu";
        names[84] = "Riothai";
        names[85] = "Qairiot";
        names[86] = "Rumrayt";
        names[87] = "Nommoith";
        names[88] = "Nepanaed";
        names[89] = "Goagheodu";
        names[90] = "Choalrioneot";
        names[91] = "Versi";
        names[92] = "Rephis";
        names[93] = "Fere";
        names[94] = "Chiphol";
        names[95] = "Toldrio";
        names[96] = "Sirgait";
        names[97] = "Shurmilth";
        names[98] = "Honniruth";
        names[99] = "Ellolu";
        names[0] = "Favnyrat";

        //names are random
        string[] randomNames = new string[4];
        randomNames[0] = names[Random.Range(0, 100)];
        randomNames[1] = names[Random.Range(0, 100)];
        randomNames[2] = names[Random.Range(0, 100)];
        randomNames[3] = names[Random.Range(0, 100)];

        //types are random
        Type[] randomTypes = new Type[4];

        randomTypes[0] = allTypes[Random.Range(0, allTypes.Length - 1)];
        randomTypes[1] = allTypes[Random.Range(0, allTypes.Length - 1)];
        randomTypes[2] = allTypes[Random.Range(0, allTypes.Length - 1)];
        randomTypes[3] = allTypes[Random.Range(0, allTypes.Length - 1)];

        //levels are all set to 50 (adult)
        int[] levels = new int[4];

        for (int i = 0; i < levels.Length; i++) {
            levels[i] = 50;
        }

        //IVs are semi-random
        int[][] randomIVs = new int[4][];

        for (int i = 0; i < randomIVs.Length; i++) {
            randomIVs[i] = new int[6];

            for (int j = 0; j < 6; j++) {
                randomIVs[i][j] = Random.Range(10, 21);
            }
        }

        //EVs are all set to 0
        int[][] EVs = new int[4][];

        for (int i = 0; i < EVs.Length; i++) {
            EVs[i] = new int[6];

            for (int j = 0; j < 6; j++) {
                EVs[i][j] = 0;
            }
        }

        //moves are selected randomly
        move[][] randomMoves = new move[4][];
        for (int i = 0; i < randomMoves.Length; i++) {
            randomMoves[i] = new move[5];

            for (int j = 0; j < randomMoves[i].Length; j++) {
                randomMoves[i][j] = allMoves[Random.Range(0, allMoves.Length - 1)];
            }
        }

        player = new player(playerName, randomTypes, levels, randomIVs, EVs, randomNames, playerTeam, randomMoves);
        //Debug.Log("Player " + playerName + " initialized");
    }

    // Use this for initialization
    void Start() {
        //Debug.Log(host);
        //Debug.Log(globals.players);

        

        if (host) {
            
        }
    }

    // Update is called once per frame
    void Update() {
        if (host) {
            if (!found) {
                processing = GameObject.Find("background");
                if (processing != blank) {
                    found = true;
                }

            } else if (!doneLoaded) {
                randomTeam();
                processing.GetComponent<combatGlobals>().host = true;
                processing.GetComponent<hosting>().host = true;

                //add the player to the lists
                processing.GetComponent<combatGlobals>().players.Add(player);

                if (player.team == 1) {
                    processing.GetComponent<combatGlobals>().team1.Add(player);
                }
                else {
                    processing.GetComponent<combatGlobals>().team2.Add(player);
                }

                globals.loaded++;
                doneLoaded = true;
            }
            
        }

    }
}
