using UnityEngine;
using System.Collections;

public class GUISync : MonoBehaviour {
	#region fields
	//Слайдер нитро
	public UISlider NitroSlider;
    public UILabel MoneyLabel; 
	public UISlider ShieldSlider;
    public UISlider HPSlider;

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
        MoneyLabel.text = globalVars.credits.ToString() + " $";
		ShieldSlider.sliderValue = thisHero.currentHitPoints / (float)thisHero.hitPoints;// thisHero.shield;
        HPSlider.sliderValue = thisHero.currentHitPoints / thisHero.hitPoints;
	}
	#endregion
}
