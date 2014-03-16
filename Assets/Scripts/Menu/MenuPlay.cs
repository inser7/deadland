using UnityEngine;
using System.Collections;

public class MenuPlay : MonoBehaviour {
	
	void OnMouseDown(){
		//	Debug.Log(this);
		Application.LoadLevel("MainScene.unity.REMOTE");
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
