using UnityEngine;
using System.Collections;

public class gunShot : MonoBehaviour 
{
	#region fields
	public float xOffsetKoeff = 1.2f;
	public float yOffsetKoeff = 1.2f;
	Vector2 forwardDirection = new Vector2(0, 1);
	private Animator thisAnimator;
	private Transform thisTransform;

	#endregion
	// Use this for initialization
	void Start () 
	{
		//thisTransform = GameObject.FindGameObjectWithTag ("weapon").transform;//.GetComponent<Transform> ();
		thisTransform = GetComponent<Transform> ();
		thisAnimator = GetComponent<Animator> ();
		
		Vector3 startPos = thisTransform.position;

		float newX = forwardDirection.x * Mathf.Cos (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z))
					- forwardDirection.y * Mathf.Sin (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z));
		float newY = forwardDirection.x * Mathf.Sin (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z))
					+ forwardDirection.y * Mathf.Cos (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z));
		
				//смешаем стартовую позицию пули, что бы вылетала не из центра оружия, а из конца ствола
		startPos.x += newX * xOffsetKoeff;
		startPos.y += newY * yOffsetKoeff;
		
		thisTransform.position = startPos;
		forwardDirection = new Vector2 (newX, newY);
		
		forwardDirection.Normalize ();
		GetComponent<AudioSource> ().pitch *= Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
	/*	Vector3 startPos = thisTransform.position;
		
		float newX = forwardDirection.x * Mathf.Cos (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z))
			- forwardDirection.y * Mathf.Sin (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z));
		float newY = forwardDirection.x * Mathf.Sin (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z))
			+ forwardDirection.y * Mathf.Cos (Mathf.Deg2Rad * (thisTransform.rotation.eulerAngles.z));
		
		//смешаем стартовую позицию пули, что бы вылетала не из центра оружия, а из конца ствола
		startPos.x += newX * xOffsetKoeff;
		startPos.y += newY * yOffsetKoeff;
		
		thisTransform.position = startPos;
		forwardDirection = new Vector2 (newX, newY);
		
		forwardDirection.Normalize ();
	*/
		Destroy (gameObject, 0.3f);
	}
}
