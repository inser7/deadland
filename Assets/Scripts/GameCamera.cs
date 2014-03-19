using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{

    #region Fields

	public Transform target;
	public float distanceXToTarget = 1.0f;
	public float distanceYToTarget = 1.0f;
    private float trackSpeed = 1;
	private Transform cameraTransform;
    #endregion

	#region void Start () 
	void Start () 
	{
		cameraTransform = transform;
		

	}
	#endregion

    #region Set Target

    public void SetTarget(Transform t)
    {
        target = t;
    }

    #endregion

	
	float newX = 0.0f;
	float newY = 0.0f;

    #region Track Target
    void LateUpdate()
    {
        if (!target) 
			return;

		if (Mathf.Abs (target.position.x - cameraTransform.position.x ) > distanceXToTarget)
			newX = target.position.x;
		if (Mathf.Abs (cameraTransform.position.y - target.position.y) > distanceYToTarget)
			newY = target.position.y;


		cameraTransform.position = Vector3.Lerp (cameraTransform.position, new Vector3 (newX, newY, 0.0f),  Time.deltaTime );
		/*
		if( Vector3.Magnitude( cameraTransform.position - target.position ) > distanceYToTarget )
		{
			cameraTransform.position = Vector3.Lerp( cameraTransform.position, target.position, Time.deltaTime * 2.0f );
		}
       */
	}
    #endregion
}
