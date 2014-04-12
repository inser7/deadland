using UnityEngine;
using System.Collections;
/**
 * базовый класс цели уровня
 * по достижению условия метод isComplete возвращает тру
 * и надо уровень заканчивать
 * */
public class CBaseLevelGoal : MonoBehaviour {

	#region public bool isComplete()
	virtual public bool isComplete()
	{
		return false;
	}
	#endregion
/*	// Use this for initialization
	void Start () {
	
	}
	*/
	// Update is called once per frame
	void Update () 
	{
		if( isComplete() )
		{			
			Debug.Log("LevelComplete! Time is up!");
			//Application.LoadLevel( "2dmenuV2");
			return;
		}
	}
}
