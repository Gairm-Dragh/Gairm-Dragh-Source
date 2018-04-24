using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour { //this is used to run the menu

    public GameObject errorTextC, lobbyNameC, passwordC; //The required gameobjects to create a lobby
    public GameObject errorTextJ, lobbyNameJ, passwordJ; //The required game objects to join a lobby
    string lobbyName, password; //string versions for easier access

    IEnumerator createProcess(int size) {
        //check availability
        bool taken = false; //whether or not the name is taken

        //pull updates first
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
                sw.WriteLine("git checkout master");
                sw.WriteLine("git pull");
                sw.WriteLine("exit");
                p.WaitForExit();
            }
        }

        StreamReader activeLobby = new StreamReader("Hub/activeBranches.txt"); //used to check if the lobby name is not in affect right now
        string line = activeLobby.ReadLine(); //read the first line of the names of all he currently active branches

        while (line != null) {
            //break if the name is taken
            if (line == lobbyName) {
                taken = true;
                break;
            }
            //go to the next line if not
            else {
                line = activeLobby.ReadLine();
            }
        }

        activeLobby.Close(); //closing the file to save on memory

        //checks the taken value and continues if the name is available
        if (!taken) {
            File.AppendAllText("Hub/activeBranches.txt", lobbyName + "\r\n"); //appends and reserves the lobby name
            p.Start();

            //updates the git repository with the new active name
            using (StreamWriter sw = p.StandardInput) {
                sw.WriteLine("help");
                sw.WriteLine("git checkout master");
                sw.WriteLine("git pull");
                sw.WriteLine("git add -A");
                sw.WriteLine("git commit -m \"adding branch " + lobbyName + " to active branches\"");
                sw.WriteLine("git push");
                sw.WriteLine("git branch " + lobbyName);
                sw.WriteLine("git checkout " + lobbyName);
                sw.WriteLine("exit");
                p.WaitForExit();
            }

            //deletes any old files to make sure space is clear
            if (Directory.Exists("Lobby")) {
                Directory.Delete("Lobby", true);
                new WaitForSeconds(0.5f);
            }

            //create a new folder
            Directory.CreateDirectory("Lobby");

            //create the lobbyInfo file
            FileStream lobbyInfo = File.Create("Lobby/lobbyInfo.txt");
            lobbyInfo.Close();

            //appends all the appropriate text to lobbyInfo
            File.AppendAllText("Lobby/lobbyInfo.txt", lobbyName + "\r\n" + size.ToString() + "\r\n" + password);

            /* lobbyInfo file structure:
             *     Lobby Name
             *     Lobby Size
             *     Lobby Password
             */

            //commit the changes for the branch to exist
            p.Start();

            using (StreamWriter sw = p.StandardInput) {
                if (sw.BaseStream.CanWrite) {
                    sw.WriteLine("help");
                    sw.WriteLine("git add -A");
                    sw.WriteLine("git commit -m \"Creating branch " + lobbyName + "\"");
                    sw.WriteLine("git push --set-upstream origin " + lobbyName);
                    sw.WriteLine("exit");
                    p.WaitForExit();
                }
            }

            SceneManager.LoadScene("private lobby");
        }
        else {
            errorTextC.GetComponent<Text>().text += "Lobby name is currently unavailable. Please enter a new name.";
        }
        yield return new WaitForSeconds(0);
    }

    //for creating a lobby
    public void create() {
        errorTextC.GetComponent<Text>().text = ""; //ressetting the error text for the repress
        //check first if we have a valid lobby name
        Regex r = new Regex("^[a-zA-Z0-9]*$"); //Regular expression used for checking
        lobbyName = "C" + lobbyNameC.GetComponent<InputField>().text;
        password = passwordC.GetComponent<InputField>().text;


        if (r.IsMatch(lobbyName) && 0 < lobbyName.Length && lobbyName.Length < 13) {
            //run the coroutine if name is valid
            StartCoroutine(createProcess(2));
        }
        else {
            errorTextC.GetComponent<Text>().text = "Lobby name is invalid. Please make sure it is alphanumeric and no more than 12 characters.";
        }
    }

    IEnumerator joinProcess(int size) {
        bool found = false; //whether or not the lobby has been found
        //check first if the lobby name exists as an active lobby
        //updating info
        Process p = new Process(); //creates the process variable
        ProcessStartInfo info = new ProcessStartInfo(); //creates the process info variable
        info.FileName = "cmd.exe"; //the file we're executing
        info.RedirectStandardInput = true;
        info.UseShellExecute = false;
        info.CreateNoWindow = false; //makes the window hidden

        p.StartInfo = info;


        StreamReader lobbies = new StreamReader("Hub/activeBranches.txt");
        string branch = lobbies.ReadLine();

        while (branch != null) {
            if (branch == lobbyName) {
                //we have matched a lobby
                //'UnityEngine.Debug.Log("Found!");
                found = true;
                break;
            }
            else {
                //UnityEngine.Debug.Log("Nope");
                branch = lobbies.ReadLine();
            }
        }

        //only proceed if found
        if (found) {
            //check password

            p.Start();

            //go to the branch to get the lobby info
            using (StreamWriter sw = p.StandardInput) {
                if (sw.BaseStream.CanWrite) {
                    sw.WriteLine("help");
                    sw.WriteLine("git checkout " + lobbyName);
                    sw.WriteLine("git pull");
                    sw.WriteLine("exit");
                    p.WaitForExit();
                }
            }

            StreamReader lobbyInfo = new StreamReader("Lobby/lobbyInfo.txt"); //getting the file
            string line = lobbyInfo.ReadLine(); //getting to the line with the password on it
            line = lobbyInfo.ReadLine(); //size
            line = lobbyInfo.ReadLine(); //password

            if (line == password) {
                //join the lobby
                SceneManager.LoadScene("private lobby");
            }
            else {
                errorTextJ.GetComponent<Text>().text = "Incorrect password";
            }
        }
        else {
            errorTextJ.GetComponent<Text>().text = "That lobby does not exist.";
        }



        yield return new WaitForSeconds(0);
    }

    //for joining a lobby
    public void join() {
        errorTextJ.GetComponent<Text>().text = ""; //ressetting the error text for the repress
        lobbyName = "C" + lobbyNameJ.GetComponent<InputField>().text;
        password = passwordJ.GetComponent<InputField>().text;
        StartCoroutine(joinProcess(2));
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
