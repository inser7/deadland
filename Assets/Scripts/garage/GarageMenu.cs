using UnityEngine;
using System.Collections;

public class GarageMenu : MonoBehaviour 
{

	
	void OnGUI()
	{
		if(GUI.Button(new Rect( Screen.width - 210, 10, 200, 40 ), "Exit to Main Menu" ) )
		{
			Application.LoadLevel("2dmenuV2");
		}

	}


}
