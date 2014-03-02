using UnityEngine;
using System.Collections;

public class zombie_walk : MonoBehaviour {
	private GameObject zombie;

	public float moveSpeed;
	public float turnSpeed;


	

	public Transform target;
	private Transform myTransform;


	private Vector3 moveDirection, PlayerMove;

	// Use this for initialization
	void Awake() {
		myTransform = transform;

	}

	// Use this for initialization
	void Start () {
	//	GameObject go = GameObject.FindGameObjectWithTag("Player");
		
	//	target = go.transform;

	//	Debug.Log(target);

		moveDirection = Vector3.up;
		
	}
/*	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(target.transform.position, transform.position);
		Debug.Log(distance);
	
		Debug.DrawLine(target.position, myTransform.position, Color.red);
		//myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		//myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		//animation.Play("walk");
		//zombie = GameObject.FindGameObjectWithTag("zombie");
		//transform.Rotate(0, Time.deltaTime, 1, Space.World);
		//transform.position = Vector2(0, 10);
		//zombie.transform.position = Vector3(0, 10, 0);



			transform.Rotate(-1.0f, 0.0f, 0.0f);  // does nothing, just a bad guess

		
		
			


	
	}
	*/

	void Update () {
		
		// 1
		Vector3 currentPosition = transform.position;

          GameObject go = GameObject.FindGameObjectWithTag("Player");
	     //Debug.Log(target.position);
		// 2
		if( Input.GetButton("Fire1") ) {
			// 3
			Vector3 moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			// 4
			Vector3 PlcurrentPosition = go.transform.position;
		
		 
			PlayerMove = moveToward - PlcurrentPosition;

			PlayerMove.z = 0; 
			PlayerMove.Normalize();
			Vector3 Pltarget = PlayerMove * 5 + PlcurrentPosition;
			go.transform.position = Vector3.Lerp( PlcurrentPosition, Pltarget, Time.deltaTime );
		}

		
		moveDirection = go.transform.position - currentPosition;
		moveDirection.z = 0; 
		moveDirection.Normalize();
		
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		Debug.Log(target);
		transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );
		
		float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg-90;
		transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler( 0, 0, targetAngle ), turnSpeed * Time.deltaTime );
	}
}
