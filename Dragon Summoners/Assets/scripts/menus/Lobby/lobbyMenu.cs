using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class lobbyMenu : MonoBehaviour { //This is for menuing in the lobby

    string lobbyName; //the name of the lobby

    //initial joining process
    IEnumerator joinLobby() {
        //first we nee to grab the size
        StreamReader lobby = new StreamReader("Lobby/lobbyInfo.txt");
        string line = lobby.ReadLine();
        line = lobby.ReadLine(); //Have the size
        int size = int.Parse(line); //convert size to int
        bool entered = false;

        //updating
        Process p = new Process(); //creates the process variable
        ProcessStartInfo info = new ProcessStartInfo(); //creates the process info variable
        info.FileName = "cmd.exe"; //the file we're executing
        info.RedirectStandardInput = true;
        info.UseShellExecute = false;
        info.CreateNoWindow = true; //makes the window hidden

        p.StartInfo = info;
        p.Start();
        using (StreamWriter sw = p.StandardInput) {
            if (sw.BaseStream.CanWrite) {
                sw.WriteLine("help");
                sw.WriteLine("git checkout C" + lobbyName);
                sw.WriteLine("git pull");
                sw.WriteLine("exit");
                p.WaitForExit();
            }
        }

        //iterate thourhg each of the possible player files
        for (int player = 1; player < size + 1; player++) {
            if (!File.Exists("Lobby/player" + player.ToString() + ".txt")) {
                //intialize the new player file
                FileStream temp = File.Create("Lobby/player" + player.ToString() + ".txt");
                temp.Close();

                //fill out the playerInfo file
                StreamWriter playerInfo = new StreamWriter("Lobby/player" + player.ToString() + ".txt");

                /* playerInfo format
                 *     player name (curently unsused)
                 *     joined
                 *     position
                 *     ready
                 */

                playerInfo.WriteLine("guest");
                playerInfo.WriteLine("true");
                playerInfo.WriteLine("0");
                playerInfo.WriteLine("false");
                playerInfo.Close();

                //pushing the updates
                using (StreamWriter sw = p.StandardInput) {
                    if (sw.BaseStream.CanWrite) {
                        sw.WriteLine("help");
                        sw.WriteLine("git checkout C" + lobbyName);
                        sw.WriteLine("git add -A");
                        sw.WriteLine("git commit -m \"Initializing player " + player + "\"");
                        sw.WriteLine("git push");
                        sw.WriteLine("exit");
                        p.WaitForExit();
                    }
                }

                entered = true;
                break;
            }
        }

        //if there are no spaces left, kick back to the main menu
        if (!entered) {
            SceneManager.LoadScene("main menu");
        }

        yield return null;
    }

    // Use this for initialization
    void Start() {
        //getting the lobby name
        StreamReader lobbyInfo = new StreamReader("Lobby/lobbyInfo.txt");
        lobbyName = lobbyInfo.ReadLine();
        lobbyInfo.Close();

        //actually joining the lobby
        StartCoroutine(joinLobby());
    }

    // Update is called once per frame
    void Update() {

    }
}
