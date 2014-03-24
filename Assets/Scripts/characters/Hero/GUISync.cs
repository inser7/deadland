﻿using UnityEngine;
using System.Collections;

public class GUISync : MonoBehaviour {
	#region fields
	//Слайдер нитро
	public UISlider NitroSlider;

	private CBaseHero thisHero;
	#endregion
	// Use this for initialization
	#region void Start () 
	void Start () 
	{
		thisHero = GetComponent<CBaseHero> ();
	}
	#endregion
	
	// Update is called once per frame
	#region void Update () 
	void Update () 
	{
		// значение слайдера уменьшаем
		NitroSlider.sliderValue =  thisHero.currenNitroStock/thisHero.nitroStock; 
	}
	#endregion
}