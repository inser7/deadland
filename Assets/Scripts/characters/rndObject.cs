using UnityEngine;
using System.Collections;
/*
 * рандомизируем объект по параметрам
 * цвет, размер
 * питч, громкость
 * 
 * в разработке
 * 
 * */
public class rndObject : MonoBehaviour {

	#region fields
	public bool isColorRandom = false;
	public Vector4 minColor = new Vector4( 0.0f, 0.0f, 0.0f, 1.0f);
	public Vector4 maxColor = new Vector4( 10.0f, 10.0f, 10.0f, 1.0f);
	
	public bool isScaleRandom = false;
	public Vector2 minMaxScale = new Vector2( 0.0f, 1.0f );
	//public Vector2 maxScale = new Vector2( 1.0f, 1.0f );

	private Transform thisTransform;
	#endregion
	// Use this for initialization
	void Start () 
	{
		thisTransform = GetComponent<Transform> ();

		//для веселья цвет меняем рандомно
		if(isColorRandom)
		{
			var spriteClr = GetComponent<SpriteRenderer> ().color;
			spriteClr.r = Random.Range ( minColor.x, maxColor.x ) / 10.0f;
			spriteClr.g = Random.Range ( minColor.y, maxColor.y ) / 10.0f;
			spriteClr.b = Random.Range ( minColor.z, maxColor.z ) / 10.0f;
			GetComponent<SpriteRenderer> ().color = spriteClr;
		}
		//для веселья цвет меняем рандомно
		if(isColorRandom)
		{
			float XY =  Random.Range ( minMaxScale.x, minMaxScale.y );
			Vector3 spriteScale = new Vector3( XY, XY, 1.0f );
			thisTransform.localScale = spriteScale;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
