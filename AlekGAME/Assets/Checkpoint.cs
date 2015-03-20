using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{

    // Funckja ma wykrywać, czy pojazd dojechał do końca misji i wczytać nową scenę
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Car")
        {
            Application.LoadLevel("End");
        }
    }
}
