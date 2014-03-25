using UnityEngine;
using System.Collections;

public class CBaseWeapon : MonoBehaviour
{
    #region Fields

		// объект пули для выстрела
		public GameObject bullet;
		//будет ли оружие поворачиваться за мышкой?
		public bool fixedAngle = true;
		//основное или альтернативное
		public bool isAlternative = false;


		//объект для звука выстрела/удара
		public GameObject gunshot;

    #endregion

	// Use this for initialization
	#region void Start ()
	void Start ()
	{

	}
    #endregion

	// Update is called once per frame
	#region void Update ()
	void Update ()
	{

	}
	#endregion
}
