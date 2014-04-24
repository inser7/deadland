using UnityEngine;
using System.Collections;

public class CSlowMoBonus : CBaseBonus
{
	
	#region fields
	public int time = 30;
	protected float timeToEndEffect;
	#endregion
	
	#region public bool endEffect()
	public override bool endEffect()
	{
		if( target == null ) return false;
		if(!isTaken)
		{
			//target.incHitPoints (value);
			isTaken = true;
			timeToEndEffect = Time.time + time;

		} 

		//слооооууу мооооуууушнн
		Time.timeScale = Mathf.Lerp (Time.timeScale, 
		                             (Time.time + 2) > timeToEndEffect ? 0.2f : 1.0f, 
		                             0.2f);//Time.fixedTime );


		thisTransform.localScale -= new Vector3(0.05f, 0.05f,0);
		
		if( thisTransform.localScale.x <= 0 )
			thisTransform.localScale = new Vector3(0.0f, 0.0f,0);
		bool isEndEffect = Time.time > timeToEndEffect ? true : false;
		if( isEndEffect )
		{
			Time.timeScale = 1.0f;
		}
		return isEndEffect;
	}
	#endregion
}

