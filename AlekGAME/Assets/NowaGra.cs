using UnityEngine;
using System.Collections;

public class NowaGra : MonoBehaviour {

	public void StartNewGame (string changeScene) 
    {
        Application.LoadLevel("mission1");
	}
}
