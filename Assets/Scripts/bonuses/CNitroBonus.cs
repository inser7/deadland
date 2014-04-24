using UnityEngine;
using System.Collections;

public class CNitroBonus : CBaseBonus 
{
	
	#region fields
	public int value = 30;
	
	#endregion
	
	#region public bool endEffect()
	public override bool endEffect()
	{
		if( target == null ) return false;
		if(!isTaken)
		{
			target.currenNitroStock = ( target.currenNitroStock + value ) > target.nitroStock ? 
										target.nitroStock : target.currenNitroStock + value;
			isTaken = true;
			/*
			 * здесь можно пустить надпись +Валуе 
			 * вылетающию в позиции героя
			 * */
		}
		
		thisTransform.localScale -= new Vector3(0.05f, 0.05f,0);
		
		if( thisTransform.localScale.x <= 0 )
			thisTransform.localScale = new Vector3(0.0f, 0.0f,0);
		
		return (thisTransform.localScale == new Vector3(0,0,0) );
	}
	#endregion

}
