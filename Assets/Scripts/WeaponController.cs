using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {


	public GameObject bullet;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 lookDirection = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		var currentZRotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
		transform.rotation= Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
		if (Input.GetButton ("Fire1")) 
		{
			var cloneBullet = Instantiate( bullet, transform.position, transform.rotation);

		}
	}
}
