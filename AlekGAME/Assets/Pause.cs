using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    // Inicjalizacja zmiennych 
    private bool showMenu = false;
    private const int INGAME_MENU_WINDOW_ID = 0;
    private Rect ingameWindowRect = new Rect(Screen.width / 2 - 85, Screen.height / 2 - 200, 170, 200);
    public GUISkin gameSkin;

    void Start()
    {
        Screen.showCursor = false;
        Screen.lockCursor = true;
    }

    // Po naciśnięciu Escape ma pokazać menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu = !showMenu;
        }
    }

    // Funckja obsługująca zdarzenia w GUI
    void OnGUI()
    {
        GUI.skin = gameSkin;

        if (showMenu)
        {
            ingameWindowRect = GUI.Window(INGAME_MENU_WINDOW_ID, ingameWindowRect, IngameMenuDisplay, "");

            Screen.showCursor = true;
            Screen.lockCursor = false;

            if (showMenu == false)
            {
                Screen.showCursor = false;
                Screen.lockCursor = true;
            }
        }
    }

    // Funkcja tworząca kolejne przyciski i opisująca ich akcję po naciśnięciu
    public void IngameMenuDisplay(int INGAME_MENU_WINDOW_ID)
    {
            if (GUI.Button(new Rect(10, 30, 150, 32), "Return", "Button"))
            {
                showMenu = false;
            }

            if (GUI.Button(new Rect(10, 70, 150, 32), "Retry", "Button"))
            {
                Application.LoadLevel("mission1");
            }

            if (GUI.Button(new Rect(10, 110, 150, 32), "Exit", "Button"))
            {
                Application.Quit();
            }
    }
}
