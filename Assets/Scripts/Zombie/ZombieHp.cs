﻿using UnityEngine;
using System.Collections;

public class ZombieHp : MonsterHp {

	public float originalHp = 100f; // Начальные значения здоровья(не меняется в ходе игры)
	private float currentHp; // текущее значение здоровья
//	private Transform thisTransform;
	private Animator anim;		
	public GameObject[] blood; //массив с кровягами
	public GameObject shoot; //префаб с анимацией выстрела
	// Use this for initialization
	void Start () {
		
		//thisTransform = transform;
		currentHp = originalHp;
		anim = GetComponent<Animator>();

		
	}
	public override bool SetDamage(BulletFly bullet){
		currentHp = currentHp - bullet.damage; // Отнимаем домаг от здоровья
		var bloodIndex = Random.Range(0, blood.Length);
		Instantiate(blood[bloodIndex], transform.position, transform.rotation);
		Vector3 shootPos = new Vector3 (transform.position.x + bullet.forwardDirection.x, 
		                                transform.position.y + bullet.forwardDirection.y, 
		                               transform.position.z);
		Instantiate(shoot, shootPos, bullet.transform.rotation ); // выстрел
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
