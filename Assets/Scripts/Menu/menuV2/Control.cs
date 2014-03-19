using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	// Use this for initialization
	void Newgame () {
        Application.LoadLevel("MainScene.unity.REMOTE");
	
	}
	
	// Update is called once per frame
	void Garage () {
        Application.LoadLevel("garage3D");
	}
}
