using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	#region Fields
		// объект пули для выстрела
		public GameObject bullet;
		//будет ли оружие поворачиваться за мышкой?
		public bool fixedAngle = true;
		//основное или альтернативное
		public bool isAlternative = false;
		//скорострельность
		public float rateOfFire = 0.1f;
		//объект для звука выстрела
		public GameObject gunshot;
		//время выстрела
		private float reloadTime;
		private Transform weaponTransform;
		private Vector3 trackorForward;
		private GameObject tracktor;
		//private AudioSource weaponAudio;
	#endregion

	#region void Start ()
	void Start () 
	{
		reloadTime = Time.time + rateOfFire;
		weaponTransform = transform;
	    tracktor = GameObject.Find ("Hero");


		//weaponAudio = GetComponent<AudioSource> ();
	}
	#endregion

	#region void Update ()
	// Update is called once per frame
	void Update () 
	{
		//находим направление цели оружия
		Vector3 lookDirection;
		if (!fixedAngle)
						lookDirection = Camera.main.ScreenToWorldPoint (Input.mousePosition) - weaponTransform.position;
				else {
			Vector2 localTracktorLookAt = tracktor.GetComponent<HeroControllerScript> ().forwardDirection;
						trackorForward = new Vector3 (localTracktorLookAt.x, localTracktorLookAt.y, 0.0f);
						lookDirection = trackorForward;
				}
		var currentZRotation = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
		weaponTransform.rotation= Quaternion.Euler(0.0f, 0.0f,  currentZRotation );

		//если пора стрелять и ЛКМ нажата
		if( (Time.time > reloadTime) && 
		   ((Input.GetButton ("Fire1") && !isAlternative ) || (Input.GetKey (KeyCode.Space) && isAlternative ) )  )
		{ 
			reloadTime = Time.time + rateOfFire;
			//запускаем снаряд 
			Instantiate( bullet, weaponTransform.position, weaponTransform.rotation);
			//запускаем звук выстрела
			var cloneSound  =  Instantiate( gunshot, weaponTransform.position, weaponTransform.rotation);
			//уничтожаем объект со звуком
			Destroy(cloneSound, 0.7f);
			//Debug.Log("shooting");
		}
	}
	#endregion
}
