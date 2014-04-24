using UnityEngine;
using System.Collections;

public class CBonusGenerator : CBaseBonusGenerator 
{
	#region fields
	//время генерации бонуса
	public float bonusRate = 5f;
	private float timeToGenerate;
	#endregion
	
	#region void Start ()
	// Use this for initialization
	void Start () 
	{
		base.Start ();
		timeToGenerate = Time.time + bonusRate;
	}
	#endregion
	
	#region void Update () 
	// Update is called once per frame
	void Update () 
	{
		if( Time.time > timeToGenerate )
		{
			if( currentCount < limit ) makeBonus();
			timeToGenerate = Time.time + bonusRate;

		}
	}
	#endregion


}
