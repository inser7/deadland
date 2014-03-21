using UnityEngine;
using System.Collections;

public class CBaseHero : MonoBehaviour 
{
	#region Fields

	//ускорение нитро
	public float nitroSpeed = 5.0f;
	//запас нитро
	public float nitroStock = 30.0f; 
	//текущее кол-вол нитро
	private float currenNitroStock;
	
	//след от гусениц
	public GameObject trail;
	public float trailRate = 0.0f;
	private float timeToCreateTrail = 0.0f;


	//звук мотора
	private AudioSource motorSound;

	#endregion
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
