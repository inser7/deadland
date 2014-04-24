using UnityEngine;
using System.Collections;

public class CBaseBonusGenerator : MonoBehaviour {

	
	#region fields
	protected Transform thisTransform;
	
	public int limit = 10; //кол-во бонусов
	protected int currentCount = 0;
	public GameObject[] listOfBonus;
	#endregion

	#region void Start ()
	// Use this for initialization
	public void Start () 
	{
		thisTransform = GetComponent<Transform> ();
	}
	#endregion
	
	#region void makeBonus () 
	public void makeBonus () 
	{
		if( currentCount >= limit ) Destroy(gameObject);
		if( listOfBonus.Length == 0 ) 
		{
			Debug.Log("CBaseBonusGenerator: no prefabs in listOfBonus");
			return;
		}
		
		Vector3 pos = new Vector3 (	thisTransform.position.x,// + Random.Range (-15, 15),
		                           thisTransform.position.y,// + Random.Range (-15, 15),
		                           thisTransform.position.z);
		int index = Random.Range (0, listOfBonus.Length);
		Instantiate (listOfBonus [index], pos, Quaternion.identity);
		currentCount++;
	}
	#endregion
}
