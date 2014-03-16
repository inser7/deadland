using UnityEngine;
using System.Collections;

public class HeroControllerScript : MonoBehaviour 
{
	#region Fields
	//след от гусениц
	public GameObject trail;
	//урон при бортовании за счет пули
	//public BulletFly bullet;
	//переменная для установки макс. скорости персонажа
	public float maxSpeed = 10.0f; 
	//угол поворота
	public float turnAngle = 5.0f; 
	//текущий угол
	public float currentZRotation = 0.0f; 
	//направление движения
	public Vector2 forwardDirection = new Vector2 (0.0f, 1.0f);



	public float trailRate = 0.0f;
	private float timeToCreateTrail = 0.0f;

	private Transform heroTransform;
	private AudioSource heroSound;
	//ссылка на компонент анимаций
	private Animator anim;
	#endregion


	// Use this for initialization
	#region void Start ()
	void Start () 
	{
		anim = GetComponent<Animator>();
		heroTransform = rigidbody2D.transform;
		currentZRotation = heroTransform.rotation.eulerAngles.z;
		timeToCreateTrail = Time.time + trailRate;
		heroSound = audio;

	}
	#endregion

	#region void OnCollisionEnter2D (Collision2D myCollision)
	//OnCollisionStay  OnCollisionExit
	/*void OnCollisionEnter2D (Collision2D myCollision)
	{
		Debug.Log ("Hero OnCollisionEnter2d");
			/*MonsterBehaviour collisionBehaviour = myCollision.gameObject.GetComponent<MonsterBehaviour> ();
			//Патрону все равно какой именно наследник MonsterBehaviour мы получим.
			//BulletFly bullet = myCollision.gameObject.GetComponent<BulletFly> ();
			if (collisionBehaviour) 
			{//Если MonsterBehaviour eсть
				//collisionBehaviour.SetDamage(bullet);

			}
				/
	}*/

	#endregion

	#region private void FixedUpdate()
	private void FixedUpdate()
	{
		Vector2 moveDirection 	= new Vector2 ( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );
		//если двигаемся вперед
		if (Mathf.Abs (moveDirection.y) > 0.0f) 
		{ 
			//вкл анимацию гусениц
			anim.SetFloat ("Speed", Mathf.Abs (moveDirection.y));		
			//добавляем "Газу" при звучании
			heroSound.pitch = 0.3f + 0.2f* Mathf.Abs (moveDirection.y);
			//двигаемся вперед
			rigidbody2D.velocity = forwardDirection * maxSpeed * moveDirection.y;
		}
		//если поворачиваем		
		if( Mathf.Abs( moveDirection.x ) > 0.0f) 
		{
			//вкл анимацию гусениц
			anim.SetFloat("Speed", Mathf.Abs(moveDirection.x));

			//Поворачиваем трактор
			currentZRotation = heroTransform.rotation.eulerAngles.z;
			heroTransform.rotation= Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
			if( moveDirection.y < 0.0f )
				currentZRotation += turnAngle * moveDirection.x;
			else
				currentZRotation -= turnAngle * moveDirection.x;

			//получаем новый вектор направления движения
			float newX 	= forwardDirection.x * Mathf.Cos( Mathf.Deg2Rad * ( currentZRotation - heroTransform.rotation.eulerAngles.z ) ) 
				- forwardDirection.y * Mathf.Sin( Mathf.Deg2Rad * ( currentZRotation - heroTransform.rotation.eulerAngles.z ) );// +rigidbody2D.transform.position.x;
			float newY 	= forwardDirection.x * Mathf.Sin( Mathf.Deg2Rad * ( currentZRotation - heroTransform.rotation.eulerAngles.z ) ) 
				+ forwardDirection.y * Mathf.Cos( Mathf.Deg2Rad * ( currentZRotation - heroTransform.rotation.eulerAngles.z ) );// +rigidbody2D.transform.position.y;

			forwardDirection = new Vector2( newX, newY ) ;
			forwardDirection.Normalize();


			heroTransform.rotation= Quaternion.Euler(0.0f, 0.0f,  currentZRotation );
		}

		//если двигаемся, то оставляем след от гусениц
		if( (Mathf.Abs (moveDirection.y) > 0.0f) || ( Mathf.Abs( moveDirection.x ) > 0.0f) )
		if( Time.time > timeToCreateTrail )
		{ //если пришло время создавать след
			timeToCreateTrail = Time.time + trailRate;
			//задаем следу позицию и поворот трактора
			var cloneTrail  =  Instantiate( trail, heroTransform.position, heroTransform.rotation);
			//уничтожаем след через 2 секунды
			Destroy(cloneTrail, 2.0f);
		}
	}
	#endregion
}
