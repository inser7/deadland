using UnityEngine;
using System.Collections;

public class garageInventoryController : MonoBehaviour {
	
	#region Fields
	private Transform slotTransform;
	public float angle = 25.0f;
	public GameObject[] gameObjs;
	#endregion
	// Use this for initialization
	#region void Start () 
	void Start () 
	{
		slotTransform = transform;
	}
	#endregion
	
	// Update is called once per frame
	#region void Update ()
	void Update () 
	{
		if (gameObject.tag != "invButtons")
			slotTransform.RotateAround (slotTransform.position, new Vector3 (0.0f, 1.0f, 0.0f), angle * Mathf.Deg2Rad);

	}
	#endregion
	
	#region OnMouseDown()
	void OnMouseDown()
	{
		if (gameObject.tag == "invButtons")
		{
			Vector3 slotPosition = gameObjs[0].transform.position;
			if( slotPosition.y == 8.0f ) slotPosition.y = 2.5f; else slotPosition.y = 8.0f;
			
			gameObjs[0].transform.position = slotPosition;

			slotPosition = gameObjs[1].transform.position;
			if( slotPosition.y == 8.0f ) slotPosition.y = 2.5f; else slotPosition.y = 8.0f;
			
			gameObjs[1].transform.position = slotPosition;


			#region buttons
			if( gameObject.name == "Up Button" )
			{

			}

			if( gameObject.name == "Down Button" )
			{

			}
			#endregion
		}
	}
	#endregion
}
