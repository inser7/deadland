﻿using UnityEngine;

public class ZombieWalk : MonoBehaviour
{

    #region Fields

    public float moveSpeed;
    public float turnSpeed;
    public Transform target;

    private Transform myTransform;
    private GameObject zombie;
    private Vector3 moveDirection, PlayerMove;
	private MonsterBehaviour ZombBehaviour;
	//private Rigidbody2D rigidbdy;

    #endregion

    #region Start
   
    void Start()
    {
        #region Commented-out
        //	GameObject go = GameObject.FindGameObjectWithTag("Player");

        //	target = go.transform;

        //	Debug.Log(target);
        #endregion
		ZombBehaviour = gameObject.GetComponent<MonsterBehaviour> ();
        moveDirection = Vector3.up;
		myTransform = this.transform;
    }

    #endregion

    #region Commented-out
    /*	
        // Update is called once per frame
        void Update () {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            Debug.Log(distance);
	
            Debug.DrawLine(target.position, myTransform.position, Color.red);
            //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
            //myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            //animation.Play("walk");
            //zombie = GameObject.FindGameObjectWithTag("zombie");
            //transform.Rotate(0, Time.deltaTime, 1, Space.World);
            //transform.position = Vector2(0, 10);
            //zombie.transform.position = Vector3(0, 10, 0);

                transform.Rotate(-1.0f, 0.0f, 0.0f);  // does nothing, just a bad guess

        }
        */
    #endregion

    #region Update

    void Update()
    {

	if (ZombBehaviour.GetLive ()) {
						var currentPosition = transform.position;
						var go = GameObject.FindGameObjectWithTag ("Player");

						#region Commented-out
						//Debug.Log(target.position);
						// 2
						/* 
         if( Input.GetButton("Fire1") ) {
            // 3
            Vector3 moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            // 4
            Vector3 PlcurrentPosition = go.transform.position;
		
		 
            PlayerMove = moveToward - PlcurrentPosition;

            PlayerMove.z = 0; 
            PlayerMove.Normalize();
            Vector3 Pltarget = PlayerMove * 5 + PlcurrentPosition;
            go.transform.position = Vector3.Lerp( PlcurrentPosition, Pltarget, Time.deltaTime );
        }
          */
						#endregion

						moveDirection = go.transform.position - currentPosition;
						moveDirection.z = 0;
						moveDirection.Normalize ();

						var playerTarget = moveDirection * moveSpeed + currentPosition;
//        Debug.Log(playerTarget);
						transform.position = Vector3.Lerp (currentPosition, playerTarget, Time.deltaTime);

						var targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;

						transform.rotation = Quaternion.Slerp (transform.rotation,
            Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);
				} 
		else {

			Destroy (myTransform.rigidbody2D);
				
		}
    }

    #endregion

}
