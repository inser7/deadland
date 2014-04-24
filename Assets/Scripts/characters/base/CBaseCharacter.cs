using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (AudioSource))]
public class CBaseCharacter : MonoBehaviour
{

	#region fields

    /*protected*/public int damage = 0;

	//здоровье персонажа
	public int maxHitPoints;
	public int currentHitPoints;
	//щит персонажа если есть
	public int maxShieldPoints;
	public int currentShieldPoints;
	//основное оружие
	//publc CBaseWeapon mainWeapon;
	
	//"направление" брызг
	public Vector2 shootForwardDirection;
	//направление движения
	public Vector2 forwardDirection = new Vector2 (0.0f, 1.0f);

	//скорость движения
	public float moveSpeed = 5.0f;
	//направление движения
	protected Vector2 moveDirection;

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
		thisRigidbody.velocity = forwardDirection * moveSpeed;
	}
	#endregion

	//смотрим в направлении движения
	#region void lookAt()
	virtual public void lookAt()
	{
		var targetAngle = Mathf.Atan2 (forwardDirection.y, forwardDirection.x) * Mathf.Rad2Deg - 90;
		
		thisTransform.rotation = Quaternion.Slerp ( thisTransform.rotation, Quaternion.Euler (0, 0, targetAngle), 2 * Time.deltaTime);

	}
	#endregion
	// Use this for initialization
	#region void Start ()
	public void Start ()
	{
		thisRigidbody = GetComponent<Rigidbody2D> ();
		thisTransform = thisRigidbody.transform;
		thisAnimator  = GetComponent<Animator> ();
		currentHitPoints 	= maxHitPoints;
		currentShieldPoints = maxShieldPoints;
	}
	#endregion

	#region void setHitPoints ()
	public void setHitPoints ( int newValue)
	{
		maxHitPoints = newValue;
		currentHitPoints = newValue;
	}
	#endregion

	#region void setShieldPoints ()
	public void setShieldPoints ( int newValue)
	{
		maxShieldPoints = newValue;
		currentShieldPoints = newValue;
	}
	#endregion

	#region void setDamage (int damage)
	virtual public void setDamage (int Value)
	{
		if( currentShieldPoints > 0 )
			incShieldPoints( - Value );
		else
			incHitPoints (-Value);
		//Debug.Log (currentHitPoints + " " + currentShieldPoints + " " + Value);
	}
	#endregion
	
	#region void incHitPoints (int incValue)
	public void incHitPoints (int incValue)
	{
		currentHitPoints += incValue;
		
		if( currentHitPoints >= maxHitPoints ) currentHitPoints = maxHitPoints;
	}
	#endregion

	#region void incShieldPoints (int incValue)
	public void incShieldPoints (int incValue)
	{
		currentShieldPoints += incValue;
	}
	#endregion

	#region bool isLive ()
	public bool isLive ()
	{
		return currentHitPoints > 0;
	}
	#endregion

}

