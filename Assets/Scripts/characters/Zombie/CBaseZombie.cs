using UnityEngine;
using System.Collections;

public class CBaseZombie : CBaseCharacter
{

	#region fields
	//цена за зомби
	public uint price = 1;
	//public GameObject blood;

	//цель зомби - игрок
	protected GameObject target;
	 //массив с кровягами
	public GameObject[] blood;
	 //префаб с анимацией выстрела
	public GameObject shoot;
	//префаб с "последним вздохом"
	public GameObject deathSound;// \м/

	protected bool  isDead = false;
	protected CBaseWeapon weapon;
	#endregion

	// Use this for initialization
	#region void Start ()
	void Start ()
	{
		thisRigidbody = GetComponent<Rigidbody2D> ();
		thisTransform = thisRigidbody.transform;
		thisAnimator  = GetComponent<Animator> ();

		target = GameObject.FindGameObjectWithTag ("Player");

        isDead = false;

		//для веселья цвет меняем рандомно
		var spriteClr = GetComponent<SpriteRenderer> ().color;
		spriteClr.r = Random.Range (0, 10) / 10.0f;
		spriteClr.g = Random.Range (0, 10) / 10.0f;
		spriteClr.b = Random.Range (0, 10) / 10.0f;
		GetComponent<SpriteRenderer> ().color = spriteClr;

		weapon = gameObject.GetComponentInChildren<CBaseWeapon> ();
		currentHitPoints = hitPoints;
	}
	#endregion

	//двигаемся в направлении движения со скоростью движения
	#region void moveTo()
	public override void moveTo()
	{
	    if( isLive() )
            thisRigidbody.velocity = forwardDirection * moveSpeed;
	}
	#endregion
	#region void lookAt()
	public override void lookAt()
	{
		var targetAngle = Mathf.Atan2 (forwardDirection.y, forwardDirection.x) * Mathf.Rad2Deg - 90;

		thisTransform.rotation = Quaternion.Slerp ( thisTransform.rotation, Quaternion.Euler (0, 0, targetAngle), 2 * Time.deltaTime);

	}

#endregion


	#region void FixedUpdate()
	private void FixedUpdate()
	{
	   // if(!isLive() ) return;
		Vector3 direction = target.transform.position - thisTransform.position;

        //если  мы еще живы
		if( isLive() )
		{
            forwardDirection = new Vector2 (direction.x, direction.y);
            forwardDirection.Normalize ();

            moveTo ();
            lookAt ();
			//if( weapon ) weapon.Attack();
		}
		else//если померли
		{
		    if(!isDead)
			{
				deathSound.GetComponent<AudioSource>().volume = Random.Range( 0.5f, 1.0f);
				deathSound.GetComponent<AudioSource>().pitch = Random.Range( 0.5f, 1.2f);
				var deathSnd = Instantiate( deathSound, thisTransform.position, thisTransform.rotation );
				Destroy( deathSnd, 3 );

                isDead = true;
                thisAnimator.SetTrigger("dead");
                Destroy(gameObject,5); //моб изчезаем через 5 минут

                globalVars.credits += price;

                Destroy ( thisRigidbody ); //

                Destroy ( GetComponent<BoxCollider2D>() ); 
            }

		}
	}
	#endregion

	#region void setDamage (int damage)
    public override void setDamage (int damage)
	{
	    if(!isLive() ) return;
		incHitPoints (-damage);
		var bloodIndex = Random.Range(0, blood.Length);
		Instantiate(blood[bloodIndex], thisTransform.position, thisTransform.rotation);

		Vector3 shootPos = new Vector3 (thisTransform.position.x + shootForwardDirection.x * shoot.transform.localScale.y * (-1),
		                                thisTransform.position.y + shootForwardDirection.y * shoot.transform.localScale.y * (-1),
		                               thisTransform.position.z);

        var targetAngle = Mathf.Atan2 (forwardDirection.y, forwardDirection.x) * Mathf.Rad2Deg - 90;

        Quaternion shootRot = Quaternion.Euler (0, 0, targetAngle);
       	Instantiate(shoot, shootPos, shootRot ); // выстрел

	}
	#endregion

	#region void OnCollisionEnter2D (Collision2D myCollision)
	/*void OnCollisionEnter2D(Collision2D  myCollision)
	{
		if ( ( myCollision.gameObject.tag == "Player") && ( isLive() ))
		{
			int dmg = myCollision.gameObject.GetComponent<CBaseHero>().damage;
			if( dmg > 0 ) setDamage( dmg );
			if( weapon ) weapon.Attack();
			
			Debug.Log(" CBaseZombie OnCollisionEnter2D damage = " +myCollision.gameObject.GetComponent<CBaseHero>().damage);
		}
	}*/
	#endregion

    #region void OnCollisionEnter2D (Collision2D myCollision)
	/*public */void OnCollisionStay2D(Collision2D  myCollision)
	{
		if ( ( myCollision.gameObject.tag == "Player") && ( isLive() ))
		{
			int dmg = myCollision.gameObject.GetComponent<CBaseHero>().damage;
			if( dmg > 0 ) setDamage( dmg );
			if( weapon ) weapon.Attack();
			
			//Debug.Log(" CBaseZombie OnCollisionEnter2D damage = " +myCollision.gameObject.GetComponent<CBaseHero>().damage);
		}
	}
	#endregion

	#region void Update()
   /* private void Update()
	{

	}*/
	#endregion
}
