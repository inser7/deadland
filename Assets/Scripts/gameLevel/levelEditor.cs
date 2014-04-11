using UnityEngine;
using System.Collections;

public class levelEditor : MonoBehaviour 
{
	#region Fields
		
		private CLevelGenerator thisLvlGen; 
		private Transform 		thisTransform;
		private Camera 			thisCamera;
		private float 			fastTrack;
	#endregion

	#region void OnGUI()
	private void OnGUI()
	{
		if(GUI.Button(new Rect( 10, 10, 200, 40 ), "Save Level To File" ) )
	  	{
			Debug.Log("saving level to file = " + thisLvlGen.levelName );
			thisLvlGen.saveFile();
		}

		if(GUI.Button(new Rect( Screen.width - 200 - 10, 10, 200, 40 ), "Load Level from File" ) )
		{
			Debug.Log("loading level from file = " + thisLvlGen.levelName );
			thisLvlGen.loadFile();
		}
		GUI.TextArea (new Rect (10, 60, 200, 20), "  shift - ускорение прокрутки");
	
	}
	#endregion
	
	#region void Start () 
	// Use this for initialization
	void Start () 
	{
		thisLvlGen = gameObject.GetComponent<CLevelGenerator> ();
		thisTransform = gameObject.GetComponent<Transform> ();
		thisCamera = gameObject.GetComponent<Camera> ();
		fastTrack = 1.0f;
	}
	#endregion
	
	#region voidUpdate () 
	// Update is called once per frame
	void Update () 
	{
		//если шифт, то ускоряем прокрутку уровня
		fastTrack = Input.GetKey (KeyCode.LeftShift) ? 5.0f : 1.0f;
		//прокрутка по осям ХУ
		if (Input.GetButton ("Fire1")) 
		{
			thisTransform.position = thisTransform.position - 
									 new Vector3(   Input.GetAxis("Mouse X") * fastTrack,
			                                     	Input.GetAxis("Mouse Y") * fastTrack,
			                                     	0.0f );
		}
		//прокрутка по оси z
		thisCamera.orthographicSize = thisCamera.orthographicSize -  Input.GetAxis("Mouse ScrollWheel")* fastTrack;
	}
	#endregion
}
