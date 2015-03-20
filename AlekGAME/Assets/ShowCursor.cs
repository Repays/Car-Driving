using UnityEngine;
using System.Collections;

public class ShowCursor : MonoBehaviour
{

    private bool showMenu = true;

    void Start()
    {
        Screen.showCursor = true;
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (showMenu)
        {
            Screen.showCursor = true;
            Screen.lockCursor = false;
        }
    }
}

