using UnityEngine;
using System.Collections;

public class GarageController : MonoBehaviour {
	
	//private Vector3 tracktorTransform;
	private Transform tracktorTransform;
	public float angle = 5.0f;
	// Use this for initialization
	void Start () 
	{
		tracktorTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Vector3 clickPosition;// = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		tracktorTransform.RotateAround (tracktorTransform.position, new Vector3 (0.0f, 1.0f, 0.0f), angle * Mathf.Deg2Rad);

		if (Input.GetButton ("Fire1")) 
		{
			Vector3 clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			tracktorTransform.RotateAround (tracktorTransform.position, new Vector3 (0.0f, 1.0f, 0.0f), angle * Mathf.Deg2Rad  * -50 * Input.GetAxis("Mouse X"));

		}

	}
}
