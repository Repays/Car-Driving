using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour
{
    // Funkcja która w parametrze pobiera nazwę sceny i ładuję ją
    public void StartNewGame(string changeScene)
    {
        Application.LoadLevel(changeScene);
    }
}