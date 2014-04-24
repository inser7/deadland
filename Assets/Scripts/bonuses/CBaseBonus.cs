using UnityEngine;
using System.Collections;

public class CBaseBonus : MonoBehaviour {

	#region fields
	public float timeToLive = 4; //сколько живет бонус, пока не взяли
	protected bool isTaken = false; //взят ли бонус
	protected CBaseHero target;
	protected float timeToDie;
	protected Transform thisTransform;
	protected BoxCollider2D thisCollider;
	#endregion

	#region void Start () 
	// Use this for initialization
	void Start () 
	{
		timeToDie = Time.time + timeToLive;
		thisTransform = GetComponent<Transform> ();
		thisCollider  = GetComponent<BoxCollider2D> ();
	}
	#endregion
	
	#region public void Update ()
	// Update is called once per frame
	public void Update () 
	{
		if( !isLive() && !isTaken ) Destroy(gameObject);
		if( endEffect() ) Destroy(gameObject);

	}
	#endregion
	
	#region public bool endEffect()
	virtual public bool endEffect()
	{
		if( !isTaken ) return false;
		return true;
	}
	#endregion
	
	#region bool isLive()
	bool isLive()
	{
		//return !(Time.time > timeToDie);
		if( (Time.time > timeToDie ) ) 
		{
			
			//if( thisTransform.localScale != new Vector3(0,0,0) )
			thisTransform.localScale -= new Vector3(0.05f, 0.05f,0);
			
			if( thisTransform.localScale.x <= 0 )
				thisTransform.localScale = new Vector3(0.0f, 0.0f,0);
		}
		return !(thisTransform.localScale == new Vector3(0,0,0));
	}
	#endregion

	
	#region void setTarget()
	void setTarget( CBaseHero newTarget)
	{
		target = newTarget;
	}
	#endregion

	#region void OnCollisionEnter2D (Collision2D myCollision)
	void OnCollisionEnter2D(Collision2D  myCollision)
	{
		if( target != null ) return;
		if ( ( myCollision.gameObject.tag == "Player") )
		{
			//isTaken = true;
			setTarget( myCollision.gameObject.GetComponent<CBaseHero>() );
			Destroy( thisCollider );
		}
	}
	#endregion
}
