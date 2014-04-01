using UnityEngine;
using System.Collections;

public class Zombie : CBaseZombie {

	public float CurveSpeed = 5;
	public float MoveSpeed = 1;
	
	float fTime = 0;
	Vector3 vLastPos = Vector3.zero;

	// Use this for initialization
	#region void Start ()
	void Start ()
	{

		vLastPos = transform.position;

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
	}
	#endregion
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		Vector3 direction = target.transform.position - thisTransform.position;
		forwardDirection.Normalize ();

		vLastPos = transform.position;
		
		fTime += Time.deltaTime * CurveSpeed;
		
		Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);
		//Vector3 vLin = new Vector3(MoveSpeed, MoveSpeed, 0);
		Vector3 vLin = new Vector3 (direction.x, direction.y, 0);
		
		transform.position += (vSin + vLin) * Time.deltaTime;

		
		//Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
	}

	/*
	//двигаемся в направлении движения со скоростью движения
	#region void moveTo()
	public override void moveTo()
	{
		Vector3 direction = target.transform.position - thisTransform.position;
		//Debug.Log("wearelivingdead )");
		forwardDirection = new Vector2 (direction.x, direction.y);
		forwardDirection.Normalize ();

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

		
		
		//если  мы еще живы
		if( isLive() )
		{

			
			moveTo ();
			lookAt ();
		}
		else//если померли
		{
			if(!isDead)
			{
				isDead = true;
				thisAnimator.SetTrigger("dead");
				Destroy(gameObject,5); //моб изчезаем через 5 минут
				
				//Debug.Log("zombie is dead");
				globalVars.credits += price;
				//    			foreach(Collider2D c in cols)
				//    			{
				//    				c.isTrigger = true;
				//    			}
				
				
				//Debug.Log("zombie is dead2");
				Destroy ( thisRigidbody ); //
				
				Destroy ( GetComponent<BoxCollider2D>() ); //
			}
			
		}
	}
	#endregion

	// Use this for initialization
	//void Start () {

		//CBaseZombie x = GetComponent<CBaseZombie>();
		//x.f
	
	//}
	
	// Update is called once per frame
	//void Update () {

		//CBaseZombie x = GetComponent<CBaseZombie>();
	
	//}*/
}
