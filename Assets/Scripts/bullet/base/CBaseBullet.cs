﻿using UnityEngine;
using System.Collections;

public class CBaseBullet : CBaseCharacter
{
	#region Fields
	public int damage = 30;
	public float damageRadius = 1;

	public float timeToDie = 1.0f;
	private float timeToLive;
	private Transform bulletTransform;
	#endregion

	// Use this for initialization
	#region void Start () 
	void Start () 
	{/*
		bulletTransform = transform;
		
		Vector3 startPos = bulletTransform.position;
		
		timeToLive = Time.time + timeToDie;
		float newX 	= forwardDirection.x * Mathf.Cos( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) ) 
			- forwardDirection.y * Mathf.Sin( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) );
		float newY 	= forwardDirection.x * Mathf.Sin( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) ) 
			+ forwardDirection.y * Mathf.Cos( Mathf.Deg2Rad * ( bulletTransform.rotation.eulerAngles.z ) );
		
		startPos.x += newX * 1.2f ;
		startPos.y += newY * 1.2f;
		bulletTransform.position = startPos;
		forwardDirection = new Vector2( newX, newY ) ;
		
		forwardDirection.Normalize();*/
	}
	#endregion

	#region void OnCollisionEnter2D (Collision2D myCollision)
	void OnCollisionEnter2D  (Collision2D  myCollision)
	{
		if (myCollision.gameObject.tag == "zombie") 
		{
			CBaseZombie collisionBehaviour = myCollision.gameObject.GetComponent<CBaseZombie> ();
			//Патрону все равно какой именно наследник MonsterBehaviour мы получим.
			if (collisionBehaviour) 
			{//Если MonsterBehaviour eсть			
				collisionBehaviour.setDamage (damage);
				//collisionBehaviour.gameObject.SendMessage("SetDamage", this);
			}
		}
		//после попадания в любой обьект, патрон исчезает	
		Destroy (gameObject);
	}
	#endregion

	#region private void FixedUpdate()
	private void FixedUpdate()
	{	
		//движемся в направлении клика
		moveTo ();
		//если время жизни закончилось, уничтожаем снаряд
		if (Time.time > timeToLive)
			Destroy (gameObject);
	}
	#endregion
}