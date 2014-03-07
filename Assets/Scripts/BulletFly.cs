﻿using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour {

	public float maxSpeed = 20.0f; 
	public Vector2 forwardDirection = new Vector2 (0.0f, 1.0f);
	public float timeToDie = 3.0f;
	// Use this for initialization
	void Start () 
	{
		float newX 	= forwardDirection.x * Mathf.Cos( Mathf.Deg2Rad * ( transform.rotation.eulerAngles.z ) ) 
					- forwardDirection.y * Mathf.Sin( Mathf.Deg2Rad * ( transform.rotation.eulerAngles.z ) );
		float newY 	= forwardDirection.x * Mathf.Sin( Mathf.Deg2Rad * ( transform.rotation.eulerAngles.z ) ) 
					+ forwardDirection.y * Mathf.Cos( Mathf.Deg2Rad * ( transform.rotation.eulerAngles.z ) );
		
		forwardDirection = new Vector2( newX, newY ) ;
		forwardDirection.Normalize();
	}


	void OnCollisionEnter2D (Collision2D myCollision){
		MonsterBehaviour collisionBehaviour = myCollision.gameObject.GetComponent<MonsterBehaviour> ();
		//Патрону все равно какой именно наследник MonsterBehaviour мы получим.
		if (collisionBehaviour) {//Если MonsterBehaviour eсть
			collisionBehaviour.SetDamage(30);
		}
		Destroy (gameObject);//после попадания в любой обьект, патрон исчещает
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//if( timeToDie <= 0.0f ) Destroy(
		rigidbody2D.velocity = forwardDirection * maxSpeed;
	}
}
