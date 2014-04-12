using UnityEngine;
using System.Collections;

public class CLevelGoalTimeIsUp : CBaseLevelGoal 
{
	#region Fields
	public float timeLimit = 1.0f;

	private float timeIsUp;
		
	#endregion
	
	#region void Start ()
	// Use this for initialization
	void Start () 
	{
		timeIsUp = Time.time + timeLimit;
	}
	#endregion
	
	/*#region void Update ()
	// Update is called once per frame
	void Update () {
	
	}
	#endregion
*/
	#region public bool isComplete()
	public override bool isComplete()
	{
		return Time.time > timeIsUp ? true : false;
	}
	#endregion
}
