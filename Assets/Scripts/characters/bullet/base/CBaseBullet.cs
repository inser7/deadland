using UnityEngine;
using System.Collections;

public class CBaseBullet : CBaseCharacter
{
	#region Fields
	//public int Damage = 30;
	public float damageRadius = 1;


	public float xOffsetKoeff = 1.2f;
	public float yOffsetKoeff = 1.2f;
	public float timeToDie = 1.0f;
	private float timeToLive;
	//private Transform bulletTransform;
	#endregion

	// Use this for initialization
	#region void Start ()
	void Start ()
	{

		thisRigidbody = GetComponent<Rigidbody2D> ();
		thisTransform = thisRigidbody.transform;
		thisAnimator  = GetComponent<Animator> ();

		Vector3 startPos = thisTransform.position;

		timeToLive = Time.time + timeToDie;
		float newX 	= forwardDirection.x * Mathf.Cos( Mathf.Deg2Rad * ( thisTransform.rotation.eulerAngles.z ) )
			- forwardDirection.y * Mathf.Sin( Mathf.Deg2Rad * ( thisTransform.rotation.eulerAngles.z ) );
		float newY 	= forwardDirection.x * Mathf.Sin( Mathf.Deg2Rad * ( thisTransform.rotation.eulerAngles.z ) )
			+ forwardDirection.y * Mathf.Cos( Mathf.Deg2Rad * ( thisTransform.rotation.eulerAngles.z ) );

		//смешаем стартовую позицию пули, что бы вылетала не из центра оружия, а из конца ствола
		startPos.x += newX * xOffsetKoeff ;
		startPos.y += newY * yOffsetKoeff;

		thisTransform.position = startPos;
		forwardDirection = new Vector2( newX, newY ) ;

		forwardDirection.Normalize();
	}
	#endregion

	#region void OnCollisionEnter2D (Collision2D myCollision)
	void OnCollisionEnter2D  (Collision2D  myCollision)
	{
		if (myCollision.gameObject.tag == "zombie")
		{
			Debug.Log("bullet damage!!!" + damage);
			CBaseZombie collisionBehaviour = myCollision.gameObject.GetComponent<CBaseZombie> ();
			//Патрону все равно какой именно наследник MonsterBehaviour мы получим.
			if (collisionBehaviour != null && collisionBehaviour.isLive() )
			{//Если MonsterBehaviour eсть
				collisionBehaviour.setDamage ( damage );
				collisionBehaviour.shootForwardDirection = forwardDirection;
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
