using UnityEngine;
using System.Collections;

public class CBaseHP : MonoBehaviour 
{

	#region fields
	//количество здоровья
	protected int Value;
	#endregion

	//устанавливаем новое значение здоровья
	#region void setValue( uint newValue )
	virtual public void setValue( int newValue )
	{
		Value = newValue;
	}
	#endregion

	//увеличиваем/уменьшаем здоровье на incValue
	#region void incValue( int incValue )
	virtual public void incValue( int incValue )
	{
		Value += incValue;
	}
	#endregion

	//проверяем есть ли здоровье еще
	#region bool isAlive()
	virtual public bool isAlive()
	{
		return Value > 0 ? true : false;
	}
	#endregion
	#region 
	
	#endregion
	// Use this for initialization
	
	#region void Start ()
	void Start () 
	{
	
	}
	
	#endregion

	// Update is called once per frame
	#region void Update () 
	void Update () 
	{
	
	}
	#endregion
}
