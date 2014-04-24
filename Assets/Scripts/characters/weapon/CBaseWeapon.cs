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
	//public string parentName = "Hero";
	//private GameObject parent;
	private CBaseCharacter parentScript;
	//protected CBaseCharacter target;	

    #endregion

	// Use this for initialization
	#region void Start ()
	void Start ()
	{

		//reloadTime = Time.time;// + rateOfFire;
		weaponTransform = transform;
		//parent = GameObject.Find ( parentName );

		//parentScript = parent.GetComponent<CBaseCharacter> ();
		parentScript = weaponTransform.parent.GetComponent<CBaseCharacter> ();
		//weaponTransform = parent.transform;
}
    #endregion

	// Update is called once per frame
	#region void Update ()
	void Update ()
	{
		if(!globalVars.isGameActive) return;
		Debug.Log( "parentScript = " +parentScript );
		//if ( (parent == null) || (parentScript  == null ) )
		if ( parentScript  == null )
		{ 
			Destroy (gameObject); 
			return; 
		}
		//находим направление цели оружия
		Vector3 lookDirection;
		if (!fixedAngle)
			lookDirection = Camera.main.ScreenToWorldPoint (Input.mousePosition) - weaponTransform.position;
		else 
		{
			lookDirection = new Vector3 (parentScript.forwardDirection.x, parentScript.forwardDirection.y, 0.0f);//  - parent.transform.position;
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
