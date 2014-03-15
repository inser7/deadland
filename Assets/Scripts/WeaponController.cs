using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	#region Fields
		public GameObject bullet;
		public float rateOfFire = 0.1f;
		private float timeToFire;
		private Transform weaponTransform;
		//private AudioSource weaponAudio;
	#endregion

	#region void Start ()
	void Start () 
	{
		timeToFire = Time.time + rateOfFire;
		weaponTransform = transform;
		//weaponAudio = GetComponent<AudioSource> ();
	}
	#endregion

	#region void Update ()
	// Update is called once per frame
	void Update () 
	{

		Vector3 lookDirection = Camera.main.ScreenToWorldPoint (Input.mousePosition) - weaponTransform.position;
		var currentZRotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
		weaponTransform.rotation= Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
		
		if(Time.time > timeToFire)
		if (Input.GetButton ("Fire1")) 
		{ 
			//weaponAudio.Play();
			timeToFire = Time.time + rateOfFire;
			//var cloneBullet  = 
				Instantiate( bullet, weaponTransform.position, weaponTransform.rotation);
			//Debug.Log("shooting");
		}
	}
	#endregion
}
