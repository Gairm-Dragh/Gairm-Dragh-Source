using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DragonGlobals : MonoBehaviour { //this is the set for keeping track of the generic stats for combat

    public player player1, player2, player3, player4, player5, player6, player7, player8;
    public int players; //# of players in the game
    public Type Fire, Water, Earth, Air, Angelic, Demonic, Balance, Grass, Toxic; //The types
    public Type[] types = new Type[9]; //array to hold all of the types
    public Dragon[] dragons; //array of al the dragons, size will depend on how many players there are

    void Start() {
        //Initializing the types
        Fire = new Type(71, 120, 95, 120, 95, 99, 0, "Fire");
        Water = new Type(80, 80, 90, 110, 130, 110, 1, "Water");
        Earth = new Type(80, 135, 130, 95, 90, 70, 2, "Earth");
        Air = new Type(50, 95, 90, 95, 90, 180, 3, "Air");
        Angelic = new Type(108, 130, 95, 80, 85, 102, 4, "Angelic");
        Demonic = new Type(55, 50, 65, 175, 105, 150, 5, "Demonic");
        Balance = new Type(50, 150, 50, 150, 50, 150, 6, "Balance");
        Grass = new Type(91, 90, 106, 130, 106, 77, 7, "Grass");
        Toxic = new Type(120, 70, 120, 75, 130, 85, 8, "Toxic");

        //putting the types into the types array
        types[0] = Fire;
        types[1] = Water;
        types[2] = Earth;
        types[3] = Air;
        types[4] = Angelic;
        types[5] = Demonic;
        types[6] = Balance;
        types[7] = Grass;
        types[8] = Toxic;
    }

    public void prepPlayerInit() {

    }

    public void initDragons() {
        //Don't need to check # of players for the first 2, as minimum size is 1v1
        for (int playerNum = 1; playerNum <= players; playerNum++) {
            string line; //the line that we are reading
            Type[] types = new Type[4]; //the types to use for the player
            int[] levels = new int[4]; //the levels to use for the player
            int[][] EVs = new int[4][]; //the EVs to use for the player
            int[][] IVs = new int[4][]; //the IVs to use for the player
            string[] names = new string[4]; //the names for the player to use
            string name; //the name of the player

            //gets the variables for the dragons
            for (int i = 0; i < 4; i++) {
                StreamReader dragon = new StreamReader("Combat/Player" + playerNum.ToString() + "/dragon" + (i + 1).ToString()); //open the file for the dragon we are on
                line = dragon.ReadLine(); //Reading the first line of the save file
                int lineNum = 1; //which line we're on

                /* Save file format:
                 *     Name
                 *     Level
                 *     HP EV,ATK EV,DEF EV,SPA EV, SPD EV,SPE EV
                 *     HP IV,ATK IV,DEF IV,SPA IV, SPD IV,SPE IV
                 *     Type
                 */

                //goes through each line
                while (line != null) {
                    if (lineNum == 1) {
                        //the name of the dragon
                        names[i] = line;
                    }
                    else if (lineNum == 2) {
                        //the level of the dragon
                        levels[i] = int.Parse(line);
                    }
                    else if (lineNum == 3) {
                        //parsing the EVs of the dragon
                        string[] temp = line.Split(',');
                        int[] temp2 = new int[6];

                        //parses into ints
                        for (int j = 0; j < temp.Length; j++) {
                            temp2[i] = int.Parse(temp[i]);
                        }

                        EVs[i] = temp2;
                    }
                    else if (lineNum == 4) {
                        //parsing the IVs of the dragon
                        string[] temp = line.Split(',');
                        int[] temp2 = new int[6];

                        //parses into ints
                        for (int j = 0; j < temp.Length; j++) {
                            temp2[i] = int.Parse(temp[i]);
                        }

                        IVs[i] = temp2;
                    }
                    else if (lineNum == 5) {
                        //parses the type
                        foreach (Type type in types) {
                            if (type.name == line) {
                                types[i] = type;
                            }
                        }
                    }

                    line = dragon.ReadLine();
                }

                dragon.Close();
            }

            //getting the player name
            StreamReader play = new StreamReader("Combat/Player" + playerNum.ToString() + "/playerInfo");
            line = play.ReadLine();
            name = line;
            play.Close();

            //checks which player to initialize
            if (playerNum == 1) {
                player1 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
            else if (playerNum == 2) {
                player2 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
            else if (playerNum == 3) {
                player3 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
            else if (playerNum == 4) {
                player4 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
            else if (playerNum == 5) {
                player5 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
            else if (playerNum == 6) {
                player6 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
            else if (playerNum == 7) {
                player7 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
            else if (playerNum == 8) {
                player8 = new player(playerNum, name, types, levels, EVs, IVs, names);
            }
        }
    }
}