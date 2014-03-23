﻿using UnityEngine;
using System.Collections;

public class CBaseHero : CBaseCharacter
{
	#region Fields


	//ускорение нитро
	public float nitroSpeed = 5.0f;
	//запас нитро
	public float nitroStock = 30.0f; 
	//текущее кол-вол нитро
	public float currenNitroStock;
	
	//след от гусениц
	public GameObject trail;
	public float trailRate = 0.0f;
	private float timeToCreateTrail = 0.0f;

	//угол поворота
	public float turnAngle = 5.0f; 
	//текущий угол
	public float currentZRotation = 0.0f; 

	//звук мотора
	private AudioSource motorSound;

	#endregion

	#region void Start () 
	void Start () 
	{
		motorSound = GetComponent<AudioSource> ();

		thisTransform = rigidbody2D.transform;
		thisAnimator  = GetComponent<Animator> ();
		thisRigidbody = GetComponent<Rigidbody2D> ();
	}
	//двигаемся в направлении движения со скоростью движения
	float nitro = 0.0f;
	#region void moveTo()
	public override void moveTo()
	{
		//если двигаемся вперед
		if (Mathf.Abs (moveDirection.y) > 0.0f) 
		{ 
			//вкл анимацию гусениц
			thisAnimator.SetFloat ("Speed", Mathf.Abs (moveDirection.y));
			bool isNitroOn = Input.GetKey( KeyCode.LeftShift );
			nitro = ( isNitroOn && ( currenNitroStock > 0 ) )? Mathf.Lerp(nitro, nitroSpeed, Time.deltaTime * 2) : 0;
			//добавляем "Газу" при звучании
			motorSound.pitch = 0.3f + 0.2f*( Mathf.Abs (moveDirection.y)  + nitro * 0.1f );// +  * 0.2f * moveDirection.y ;
			//двигаемся вперед
			rigidbody2D.velocity = forwardDirection * moveSpeed * moveDirection.y + forwardDirection * nitro* moveDirection.y;
			if( isNitroOn && currenNitroStock > 0.0f )
			{   //нитро кончается
				currenNitroStock -= 0.1f;
			}
		}
		//thisRigidbody.velocity = forwardDirection * moveSpeed * moveDirection.y + forwardDirection * nitro* moveDirection.y;
	}
	#endregion

	
	#region void lookAt()
	public override void lookAt()
	{
		//если поворачиваем		
		if( Mathf.Abs( moveDirection.x ) > 0.0f) 
		{
			//вкл анимацию гусениц
			thisAnimator.SetFloat("Speed", Mathf.Abs(moveDirection.x));
			
			//Поворачиваем трактор
			currentZRotation = thisTransform.rotation.eulerAngles.z;
			thisTransform.rotation = Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
			if( moveDirection.y < 0.0f )
				currentZRotation += turnAngle * moveDirection.x;
			else
				currentZRotation -= turnAngle * moveDirection.x;
			
			//получаем новый вектор направления движения
			float newX 	= forwardDirection.x * Mathf.Cos( Mathf.Deg2Rad * ( currentZRotation - thisTransform.rotation.eulerAngles.z ) ) 
				- forwardDirection.y * Mathf.Sin( Mathf.Deg2Rad * ( currentZRotation - thisTransform.rotation.eulerAngles.z ) );// +rigidbody2D.transform.position.x;
			float newY 	= forwardDirection.x * Mathf.Sin( Mathf.Deg2Rad * ( currentZRotation - thisTransform.rotation.eulerAngles.z ) ) 
				+ forwardDirection.y * Mathf.Cos( Mathf.Deg2Rad * ( currentZRotation - thisTransform.rotation.eulerAngles.z ) );// +rigidbody2D.transform.position.y;
			
			forwardDirection = new Vector2( newX, newY ) ;
			forwardDirection.Normalize();
			
			
			thisTransform.rotation = Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
		}
	}
	#endregion

	// Use this for initialization

	#endregion

	#region void makeTrail()
	private void makeTrail()
	{
		//если двигаемся, то оставляем след от гусениц
		if( (Mathf.Abs (moveDirection.y) > 0.0f) || ( Mathf.Abs( moveDirection.x ) > 0.0f) )
			if( Time.time > timeToCreateTrail )
		{ //если пришло время создавать след
			timeToCreateTrail = Time.time + trailRate;
			//задаем следу позицию и поворот трактора
			var cloneTrail  =  Instantiate( trail, thisTransform.position, thisTransform.rotation);
			//уничтожаем след через 2 секунды
			Destroy(cloneTrail, 2.0f);
		}
	}
	#endregion

	#region void FixedUpdate()
	private void FixedUpdate()
	{
		moveDirection 	= new Vector3 ( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f );
		moveTo ();//движение
		lookAt ();//поворот
		//если двигаемся, то оставляем след от гусениц
		makeTrail ();
	}
	#endregion

	// Update is called once per frame
	#region void Update ()
	void Update () 
	{
	
	}
	#endregion
}
