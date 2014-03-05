using UnityEngine;
using System.Collections;

public class HeroControllerScript : MonoBehaviour {

	//переменная для установки макс. скорости персонажаssss
	public float maxSpeed = 10.0f; 
	public float turnAngle = 5.0f; 
	public float currentZRotation = 0.0f; 
	//направление движения
	public Vector2 forwardDirection = new Vector2 (0.0f, 1.0f);

	//ссылка на компонент анимаций
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		currentZRotation = rigidbody2D.transform.rotation.eulerAngles.z;
	}

	//void Update() { }
	private void FixedUpdate()
	{
		Vector2 moveDirection 	= new Vector2 ( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );

		if (Mathf.Abs (moveDirection.y) > 0.5f) 
		{ //если двигаемся
			anim.SetFloat ("Speed", Mathf.Abs (moveDirection.y));		
			rigidbody2D.velocity = forwardDirection * maxSpeed * moveDirection.y;
		} else
			rigidbody2D.velocity = new Vector2 (0.0f, 0.0f );
					
		if( Mathf.Abs( moveDirection.x ) > 0.2f) //если поворачиваем
		{
			anim.SetFloat("Speed", Mathf.Abs(moveDirection.x));

			currentZRotation = rigidbody2D.transform.rotation.eulerAngles.z;
			if( moveDirection.x > 0 ) currentZRotation -= turnAngle; else currentZRotation += turnAngle;

			float newX 	= forwardDirection.x * Mathf.Cos( Mathf.Deg2Rad * ( currentZRotation - rigidbody2D.transform.rotation.eulerAngles.z ) ) 
				- forwardDirection.y * Mathf.Sin( Mathf.Deg2Rad * ( currentZRotation - rigidbody2D.transform.rotation.eulerAngles.z ) );// +rigidbody2D.transform.position.x;
			float newY 	= forwardDirection.x * Mathf.Sin( Mathf.Deg2Rad * ( currentZRotation - rigidbody2D.transform.rotation.eulerAngles.z ) ) 
				+ forwardDirection.y * Mathf.Cos( Mathf.Deg2Rad * ( currentZRotation - rigidbody2D.transform.rotation.eulerAngles.z ) );// +rigidbody2D.transform.position.y;

			forwardDirection = new Vector2( newX, newY ) ;

			forwardDirection.Normalize();
			rigidbody2D.transform.rotation= Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
		}


	}

}
