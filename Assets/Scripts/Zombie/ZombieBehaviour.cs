using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonsterBehaviour {

	public MonsterHp thisHp; //Переменная для хранения скрипта отвечающего за здоровье
	public float monsterSpeed = 3;//скоросто движения монстра

	
	private bool isLive = true;//флаг, показывающий жив или мерт моб

	private Transform thisTransform; 
	// Use this for initialization
	void Start () {
		//Debug.Log ("ZombieBehaviour");
		thisHp = GetComponent<MonsterHp>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool SetDamage(float damage)
	{
		if (isLive)
		{
			if (thisHp.SetDamage(damage))
			{
				//моб жив
			}
			else
			{
				Debug.Log("Моб мертв");
				isLive = false;
			}
		}
		return true;
	}

	public override bool GetLive(){
		if (isLive)
						return true;
				else
						return false;
	}
}
