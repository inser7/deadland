﻿using UnityEngine;
using System.Collections;


//Класс поведения - что делать если видишь игрока, что делать в разных ситуациях
public class MonsterBehaviour : MonoBehaviour {

	//все монстры получают дамаг
	virtual public bool SetDamage(float damage){
		return true;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
