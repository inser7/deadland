using UnityEngine;
using System.Collections;

public class CBaseCharacter : MonoBehaviour 
{

	#region fields
	//здоровье персонажа
	//protected CBaseHP hitPoints;
	protected int hitPoints;
	//щит персонажа если есть
	//protected CBaseHP shield;
	//основное оружие
	//publc CBaseWeapon mainWeapon;

	//направление движения
	public Vector2 forwardDirection = new Vector2 (0.0f, 1.0f);

	//скорость движения
	public float moveSpeed;
	//направление движения
	protected Vector3 moveDirection;

	//кэшируем Transform
	protected Transform thisTransform;
	//ссылка на компонент анимаций
	protected Animator thisAnimator;
	//ссылка на ригидбоди
	protected Rigidbody2D thisRigidbody;
	#endregion

	//двигаемся в направлении движения со скоростью движения
	#region void moveTo()
	virtual public void moveTo()
	{
		//thisTransform.position = Vector3.Lerp (thisTransform.position, thisTransform.position + moveDirection * moveSpeed, Time.deltaTime);
		thisRigidbody.velocity = moveDirection * moveSpeed;
	}
	#endregion

	//смотрим в направлении движения
	#region void lookAt()
	virtual public void lookAt()
	{
		//var targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);
		//thisTransform.rotation = 
	}
	#endregion
	// Use this for initialization
	#region void Start ()
	void Start () 
	{
		thisTransform = transform;
		thisAnimator  = GetComponent<Animator> ();
		thisRigidbody = GetComponent<Rigidbody2D> ();
		/*GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		moveDirection = obj.transform.position;
		moveDirection.Normalize ();*/
	}
	#endregion

	#region void setHitPoints () 
	public void setHitPoints ( int newValue) 
	{
		hitPoints = newValue;
	}
	#endregion

	#region void setDamage (int damage) 
	public void setDamage (int damage) 
	{
		incHitPoints (-damage);
	}
	#endregion

	#region void incHitPoints (int incValue) 
	public void incHitPoints (int incValue) 
	{
		hitPoints += incValue;
	}
	#endregion

	#region bool isLive () 
	public bool isLive () 
	{
		return hitPoints > 0;
	}
	#endregion
}
