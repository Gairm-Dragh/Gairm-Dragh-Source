using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class gittesting : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //code to use to execute git commands
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
                sw.WriteLine("git add -A");
                sw.WriteLine("git commit -m \"More testing of using git in unity\"");
                sw.WriteLine("git push");
                sw.WriteLine("exit");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
