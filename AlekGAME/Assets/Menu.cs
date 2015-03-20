using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width /2.5f, Screen.height / 6, Screen.width / 5, Screen.height / 5), "Car Driving");
        //GUI.Label(new Rect(Screen.width /2.5f, Screen.height/1.6f ,Screen.width,Screen.height), "Use left and right arrow to drive a car");

        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "New Game"))
            Application.LoadLevel("mission1");

        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Exit Game"))
            Application.Quit();
    }
}
