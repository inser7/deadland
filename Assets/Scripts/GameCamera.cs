using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{

    #region Fields

    public Transform target;
    private float trackSpeed = 10;

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

        var v = transform.position;
        v.x = target.position.x;
        v.y = target.position.y;

        transform.position = Vector3.MoveTowards(transform.position, v, trackSpeed * Time.deltaTime);
    }
    #endregion
}
