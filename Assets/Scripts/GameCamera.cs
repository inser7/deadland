﻿using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{

    #region Fields
    public Vector2  topLeftCorner =  new Vector2( -100, 100 );
    public Vector2  bottomRightCorner =  new Vector2( 100, -100 );
	public Transform target;
	public float distanceXToTarget = 0.0f;
	public float distanceYToTarget = 0.0f;
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


	#region Track Target
    void LateUpdate()
    {
        if (!target)
			return;
			//Debug.Log( cameraTransform.position );
		//
		float xD = distanceXToTarget - Mathf.Abs( target.position.x - cameraTransform.position.x );
		float yD = distanceYToTarget - Mathf.Abs (target.position.y - cameraTransform.position.y);
		int signX = target.position.x - cameraTransform.position.x > 0 ? -1 : 1;
		int signY = target.position.y - cameraTransform.position.y > 0 ? -1 : 1;
		//если вышли за границы
		bool isOutOfX = Mathf.Abs (target.position.x - cameraTransform.position.x ) > distanceXToTarget;
		bool isOutOfY = Mathf.Abs (target.position.y - cameraTransform.position.y ) > distanceYToTarget;
		Vector3 newCamPos = cameraTransform.position;

        if( ( topLeftCorner.x <= (newCamPos.x + xD * signX) ) && ( bottomRightCorner.x >= (newCamPos.x + xD * signX) ) )
            if(isOutOfX) newCamPos = new Vector3( newCamPos.x + xD * signX,
                                                 newCamPos.y ,
                                                 newCamPos.z);
        if( ( topLeftCorner.y >= (newCamPos.y + yD * signY) ) && ( bottomRightCorner.y <= (newCamPos.y + yD * signY) ) )
            if(isOutOfY) newCamPos = new Vector3( newCamPos.x ,
                                                 newCamPos.y + yD * signY,
                                                 newCamPos.z);

		if( isOutOfX || isOutOfY )
		{
			cameraTransform.position = Vector3.Lerp( cameraTransform.position, newCamPos, Time.deltaTime * 2.0f );

		}

	}
    #endregion
}
