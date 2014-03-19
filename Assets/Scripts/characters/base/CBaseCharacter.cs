using UnityEngine;
using System.Collections;

public class CBaseCharacter : MonoBehaviour {

	#region fields
	//здоровье персонажа
	protected CBaseHP hitPoints;
	
	//щит персонажа если есть
	//protected CBaseHP shield;
	//основное оружие
	//publc CBaseWeapon mainWeapon;


	//скорость движения
	public float moveSpeed;
	//направление движения
	private Vector3 moveDirection;

	//кэшируем Transform
	protected Transform thisTransform;
	//ссылка на компонент анимаций
	protected Animator thisAnimator;
	#endregion

	//двигаемся в направлении движения со скоростью движения
	#region void moveTo()
	virtual public void moveTo()
	{
		thisTransform.position = Vector3.Lerp (thisTransform.position, thisTransform.position + moveDirection * moveSpeed, Time.deltaTime);
	}
	#endregion

	// Use this for initialization
	#region void Start ()
	void Start () 
	{
		thisTransform = transform;
		thisAnimator = GetComponent<Animator> ();
		/*GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		moveDirection = obj.transform.position;
		moveDirection.Normalize ();*/
	}
	#endregion
	
	// Update is called once per frame
	#region void Update ()
	void Update () 
	{
		//тестирую просто мувТу
		moveDirection =  GameObject.FindGameObjectWithTag ("Player").transform.position - thisTransform.position;
		moveDirection.z = 0.0f;
		moveDirection.Normalize ();
		moveTo ();
	}
	#endregion
}
