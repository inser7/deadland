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
	public Vector2 scaleRange = new Vector2( 0.0f, 1.0f );
	//public Vector2 maxScale = new Vector2( 1.0f, 1.0f );

	public bool isPitchRandom = false;
	public Vector2 pithcRange = new Vector2( 0.0f, 1.0f );
	public bool isVolumeRandom = false;
	public Vector2 volumeRange = new Vector2( 0.0f, 1.0f );
	private Transform thisTransform;
	private AudioSource thisAudio;
	#endregion
	// Use this for initialization
	#region void Start ()
	void Start () 
	{
		thisTransform 	= GetComponent<Transform> ();
		thisAudio 		= GetComponent<AudioSource> ();
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
			float XY =  Random.Range ( scaleRange.x, scaleRange.y );
			Vector3 spriteScale = new Vector3( XY, XY, 1.0f );
			thisTransform.localScale = spriteScale;
		}

		if( thisAudio )
		{
			if(isPitchRandom)  thisAudio.pitch  = Random.Range ( pithcRange.x,  pithcRange.y  );
			if(isVolumeRandom) thisAudio.volume = Random.Range ( volumeRange.x, volumeRange.y );
		}
	}
	#endregion
	
	// Update is called once per frame
	#region void Update ()
	void Update () 
	{
	
	}
	#endregion
}
