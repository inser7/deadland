using UnityEngine;
using System.Collections;

public class CBaseWeapon : MonoBehaviour
{
    #region Fields

		// объект пули для выстрела
		public GameObject bullet;
		//будет ли оружие поворачиваться за мышкой?
		public bool fixedAngle = true;
		//основное или альтернативное
		public bool isAlternative = false;


		//объект для звука выстрела/удара
		public GameObject gunshot;
		
		public bool isControlledByKeys = true;

	public float rateOfFire = 0.1f;

	//время выстрела
	private float reloadTime = 0.0f;
	private Transform weaponTransform;
	private Vector3 parentForward;
	public string parentName = "Hero";
	private GameObject parent;
	private CBaseCharacter parentScript;
	//protected CBaseCharacter target;	

    #endregion

	// Use this for initialization
	#region void Start ()
	void Start ()
	{
		//reloadTime = Time.time;// + rateOfFire;
		weaponTransform = transform;
		parent = GameObject.Find ( parentName );
		parentScript = parent.GetComponent<CBaseCharacter> ();
		//weaponTransform = parent.transform;
}
    #endregion

	// Update is called once per frame
	#region void Update ()
	void Update ()
	{
		//if (!parent) Destroy (gameObject);
		//if (!parentScript) Destroy (gameObject);
		//находим направление цели оружия
		Vector3 lookDirection;
		if (!fixedAngle)
			lookDirection = Camera.main.ScreenToWorldPoint (Input.mousePosition) - weaponTransform.position;
		else 
		{
			Debug.Log("localParentLookAt");
			Vector2 localParentLookAt = parentScript.forwardDirection;
			Debug.Log("localParentLookAt22@");
			//parentForward = ;
			lookDirection = new Vector3 (localParentLookAt.x, localParentLookAt.y, 0.0f);//  - parent.transform.position;

		}
		lookDirection.Normalize();
		var currentZRotation = Mathf.Atan2 (lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
		weaponTransform.rotation= Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
		//weaponTransform.rotation = Quaternion.Slerp ( parent.transform.rotation, Quaternion.Euler (0, 0, currentZRotation), 2 * Time.deltaTime);

		if ( isControlledByKeys &&  
		    (Input.GetButton ("Fire1") && !isAlternative) || 
		    (Input.GetKey (KeyCode.Space) && isAlternative) )
			Attack ();
	}
	#endregion

	#region void Attack ()
	virtual public void Attack ()
	{
		if( Time.time > reloadTime )
		{ 
			reloadTime = Time.time + rateOfFire;
			//запускаем снаряд 
			Instantiate( bullet, weaponTransform.position, weaponTransform.rotation);
			if( gunshot != null )
				Instantiate( gunshot, weaponTransform.position, weaponTransform.rotation);
		}
	}
	#endregion

	/*#region void Start ()
	void Start ()
	{
		
	}
	#endregion
*/


}
