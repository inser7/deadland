using UnityEngine;
using System.Collections;

public class GarageController : MonoBehaviour {
	
	#region Fields
	private Transform tracktorTransform;
	public float angle = 5.0f;
	#endregion
	// Use this for initialization
	#region void Start () 
	void Start () 
	{
		tracktorTransform = transform;
	}
	#endregion
	
	// Update is called once per frame
	#region void Update ()
	void Update () 
	{
		tracktorTransform.RotateAround (tracktorTransform.position, new Vector3 (0.0f, 1.0f, 0.0f), angle * Mathf.Deg2Rad);
		if (Input.GetButton ("Fire1")) 
		{
			tracktorTransform.RotateAround (tracktorTransform.position, new Vector3 (0.0f, 1.0f, 0.0f), angle * Mathf.Deg2Rad  * -50 * Input.GetAxis("Mouse X"));
		}
	}
	#endregion
}
