using UnityEngine;
using System.Collections;

public class HeroControllerScript : MonoBehaviour {

	//переменная для установки макс. скорости персонажаssss
	public float maxSpeed = 1.0f; 
	public float turnAngle = 1.0f; 
	public float currentZRotation = 0.0f; 
	//направление движения
	//Vector2 moveDirection 	= new Vector2 (0, 0);
	//public Vector2 forward = new Vector2 (0.5f, 0.5f);
	public Vector2 forward = new Vector2 (0.0f, 1.0f);
	//переменная для определения направления персонажа вправо/влево
	//ссылка на компонент анимаций
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	private void FixedUpdate()
		//	void Update()
	{
		//используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
		//при стандартных настройках проекта 
		//-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
		//1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
		Vector2 moveDirection 	= new Vector2 ( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );
		//Vector3 currentPosition = transform.position;
		//float currentZRotation = transform.rotation.z * Mathf.Rad2Deg;
		//Debug.Log ("moveDirection = " + moveDirection);
		if(Mathf.Abs (moveDirection.y) > 0) //если двигаемся
		{
			anim.SetFloat("Speed", Mathf.Abs(moveDirection.y));
			//transform.position = Vector2.Lerp();
			//transform.position = moveDirection * maxSpeed;

			rigidbody2D.velocity =  forward * maxSpeed * moveDirection.y;

			//Debug.Log ("rigidbody2D.velocity = " + rigidbody2D.velocity);
			Debug.Log ("pos = " + transform.position);
			//rigidbody2D.AddForce( forward * maxSpeed * moveDirection.y);
		}

		if( Mathf.Abs( moveDirection.x ) > 0) //если поворачиваем
		{

			if( Mathf.Abs( currentZRotation ) >= 360.0f ) currentZRotation = 0.0f;

			int koef = 1;
			if( moveDirection.x < 0 ) koef = -1;
			currentZRotation -= turnAngle * koef;// moveDirection.x;
			anim.SetFloat("Speed", Mathf.Abs(moveDirection.x));

			float newX 	= forward.x * Mathf.Cos( Mathf.Deg2Rad * currentZRotation )* Mathf.Rad2Deg 
						- forward.y * Mathf.Sin( Mathf.Deg2Rad * currentZRotation )* Mathf.Rad2Deg;
			float newY 	= forward.x * Mathf.Sin( Mathf.Deg2Rad * currentZRotation )* Mathf.Rad2Deg 
						+ forward.y * Mathf.Cos( Mathf.Deg2Rad * currentZRotation )* Mathf.Rad2Deg;

			forward =  new Vector2( newX, newY );
			forward.Normalize();
		
			transform.rotation = Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
			//float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;// - transform.rotation.z;// - 90;
			//transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, 0, angleKoeff * targetAngle), maxSpeed * Time.deltaTime );
		}


		//обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
		//равную значению оси Х умноженное на значение макс. скорости
		//rigidbody2D.velocity = moveDirection * maxSpeed;
		//rigidbody2D.velocity =  moveDirection * maxSpeed;
		

	}
	/*void Update () {
		
		// 1

		// 2
		if( Input.GetButton("Fire1") ) {
			// 3
			Vector3 moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			
			Vector3 currentPosition = transform.position;
			
			Vector3 target = moveDirection * moveSpeed + currentPosition;
			// 4
			//Debug.Log(moveToward);
			moveDirection = moveToward - currentPosition;

			moveDirection.z = 0; 
			moveDirection.Normalize();
			
			//transform.Rotate (new Vector3 (0, 0, 1), targetAngle);

			Debug.Log(target);
			transform.position = target;
		}
		float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - transform.rotation.z;// - 90;

		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, 0, targetAngle - transform.rotation.z), turnSpeed * Time.deltaTime );
	}*/

	// Update is called once per frame

}
