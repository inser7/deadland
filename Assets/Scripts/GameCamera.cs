using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{

    #region Fields

    public Transform target;
	public float distanceToTarget = 5.0f;
    private float trackSpeed = 10;
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

		if( Vector3.Magnitude( cameraTransform.position - target.position ) > distanceToTarget )
		{
			cameraTransform.position = Vector3.Lerp( cameraTransform.position, target.position, Time.deltaTime * 2.0f );
		}
       /* var v = transform.position;
        v.x = target.position.x;
        v.y = target.position.y;

        transform.position = Vector3.MoveTowards(transform.position, v, trackSpeed * Time.deltaTime);
		*/
	}
    #endregion
}
