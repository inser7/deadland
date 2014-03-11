using UnityEngine; 
using System.Collections;

public class GarageController : MonoBehaviour {
	
	#region Fields
	private Transform tracktorTransform;
	public float angle = 5.0f;
	public GameObject[] weapons;
	public bool isTopWeaponExist = true;

	//private bool isTopWeaponCreate = true;
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
		//MeshRenderer obj = gameObject.GetComponent<MeshRenderer> ();

		//obj.
		//if( isTopWeaponCreate
		if (isTopWeaponExist) 
		{
			GameObject obj = GameObject.Find ("machineGun");
			isTopWeaponExist = false;
			//gameObject.ch
			//obj = Resources.Load("miniMachineGun");
			Vector3 pos = tracktorTransform.position;
			Quaternion rot = tracktorTransform.rotation;
			rot.eulerAngles = new Vector3( -90.0f ,rot.eulerAngles.x,tracktorTransform.rotation.eulerAngles.z); 
			pos.y += 1.0f;
			var cloneTopWeapon  = Instantiate( obj/*weapons[0]*/, pos, rot);
			//gameObject.
		}
	}
	#endregion
}
