using UnityEngine;
using System.Collections;

public class ZombieHp : MonsterHp {

	public float originalHp = 100f; // Начальные значения здоровья(не меняется в ходе игры)
	private float currentHp; // текущее значение здоровья
//	private Transform thisTransform;
	private Animator anim;		
	// Use this for initialization
	void Start () {
		
		//thisTransform = transform;
		currentHp = originalHp;
		anim = GetComponent<Animator>();

		
	}
	public override bool SetDamage(float damage){
		currentHp = currentHp - damage; // Отнимаем домаг от здоровья
	//	Debug.Log(currentHp);
		if (currentHp > 0) {
			return true;
		} 
		else {
		//	thisTransform.localScale = new Vector2(2,2); //увеличить моба в 2 раза при смерти
			anim.SetTrigger("dead");
			Destroy(gameObject,5); //моб изчезаем через 5 минут
			return false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
