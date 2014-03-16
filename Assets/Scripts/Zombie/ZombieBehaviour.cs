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

		//для веселья цвет меняем рандомно
		var spriteClr = GetComponent<SpriteRenderer> ().color;
		spriteClr.r = Random.Range (0, 10) / 10.0f;
		spriteClr.g = Random.Range (0, 10) / 10.0f;
		spriteClr.b = Random.Range (0, 10) / 10.0f;
		GetComponent<SpriteRenderer> ().color = spriteClr;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool SetDamage(BulletFly bullet)
	{
		if (isLive)
		{
			if (thisHp.SetDamage(bullet))
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

	#region void OnCollisionEnter2D (Collision2D myCollision)
	/*void OnCollisionEnter2D (Collision2D myCollision)
	{
		//Debug.Log ("Zombie OnCollisionEnter2d");
		//MonsterBehaviour collisionBehaviour = myCollision.gameObject.GetComponent<MonsterBehaviour> ();
			//Патрону все равно какой именно наследник MonsterBehaviour мы получим.
			//BulletFly bullet = myCollision.gameObject.GetComponent<BulletFly> ();
		//if (myCollision.gameObject.tag == "Player") 
//		{
//			Debug.Log("Ты сбил зомби");
//		}

	}*/
	#endregion
}
