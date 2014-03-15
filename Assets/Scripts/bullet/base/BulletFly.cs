﻿using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour {

	#region Fields
	public float maxSpeed = 20.0f; 
	public float damage = 30.0f;
	public Vector2 forwardDirection = new Vector2 (0.0f, 1.0f);
	public float timeToDie = 1.0f;
	private float timeToLive;
	private Transform bulletTransform;
	#endregion
	// Use this for initialization
	#region void Start () 
	void Start () 
	{
		bulletTransform = transform;

		Vector3 startPos = bulletTransform.position;

		timeToLive = Time.time + timeToDie;
		float newX 	= forwardDirection.x * Mathf.Cos( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) ) 
					- forwardDirection.y * Mathf.Sin( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) );
		float newY 	= forwardDirection.x * Mathf.Sin( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) ) 
					+ forwardDirection.y * Mathf.Cos( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) );
		
		startPos.x += newX * 3;
		startPos.y += newY * 3;
		bulletTransform.position = startPos;
		forwardDirection = new Vector2( newX, newY ) ;
		
		forwardDirection.Normalize();
	}
	#endregion

	#region void OnCollisionEnter2D (Collision2D myCollision)
	void OnCollisionEnter2D (Collision2D myCollision)
	{

		if (myCollision.gameObject.tag == "zombie") 
		{
			MonsterBehaviour collisionBehaviour = myCollision.gameObject.GetComponent<MonsterBehaviour> ();
			//Патрону все равно какой именно наследник MonsterBehaviour мы получим.
			if (collisionBehaviour) 
			{//Если MonsterBehaviour eсть			
				collisionBehaviour.SetDamage (this);
				//collisionBehaviour.gameObject.SendMessage("SetDamage", this);
			}
			Destroy (gameObject);//после попадания в любой обьект, патрон исчещает		
		}
	}
	#endregion

	// Update is called once per frame
	#region private void FixedUpdate()
	private void FixedUpdate()
	{	
		rigidbody2D.velocity = forwardDirection * maxSpeed;
		if (Time.time > timeToLive)
			Destroy (gameObject);
	}
	#endregion
}
