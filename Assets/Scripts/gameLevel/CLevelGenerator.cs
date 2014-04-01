using UnityEngine;
using System.Collections;

public class CLevelGenerator : MonoBehaviour
{

    #region fields
    //public GameObject[] tiles;
    //кол-во тайлов в ширину
    public int mapWidth  = 4;
    //кол-во тайлов в высоту
    public int mapHeight = 4;
    #endregion

//(new GameObject("AutoFade")).AddComponent<AutoFade>();
	// Use this for initialization
	#region void Start ()
	void Start ()
    {
		//tiles = new GameObject[1];
		CreateTiles (mapWidth, mapHeight, 512 /* mapWidth*/, 512 /** mapHeight*/);

	}
    #endregion

	// Update is called once per frame
	#region void Update ()
	void Update ()
	{

	}
    #endregion

	#region void CreateTile ()
	void/*GameObject*/ CreateTiles (int row, int col, int w, int h )
	{
		GameObject tile = new GameObject ();
		//tile.AddComponent<Transform> ();
		//tile.transform.position = new Vector3( transform.position.x + w*row, transform.position.y +  h*col, transform.position.z);
		tile.AddComponent<SpriteRenderer> ();
		Sprite sprite = new Sprite ();
		string path = "file://c:\\DeveloperStudio\\UnityProjects\\Deathland\\deadland\\Assets\\Sprites\\ground\\sand.png";
		WWW www = new WWW(path);
		//yield return www; 
		//www.texture.
		sprite = Sprite.Create (www.texture, new Rect(0, 0, w, h),new Vector2(0, 0), 512.0f);
		//tile.transform.localScale = new Vector3 (5.0f, 5.0f, 1.0f );
		//tile.transform.localScale = new Vector3 (3.0f, 3.0f, 1.0f );
		tile.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f );
		SpriteRenderer sRenderer = tile.GetComponent<SpriteRenderer> ();

		sRenderer.sprite = sprite;

		//создаем тайлы
		Vector2 startPos = new Vector2 (/*row */ w / ( 2.0f * tile.transform.localScale.x) ,

		                                /*col */ h / ( 2.0f * tile.transform.localScale.y) );
		Debug.Log("startPos " + ( -w / 2.0f ) );
		//Quaternion newRot = Quaternion.Euler (0.0f, 0.0f, 45.0f);
		//for( int i = 0; i < row; i++ )
			//for( int j = 0; j < col; j++ )
			{
			//	tile.name =  "Tile_" + i.ToString() +"x"+j.ToString();
			/*	Vector3 newPos = new Vector3( 	-startPos.x +  w + w * i,
			                            		-startPos.y +  h + h * j, 
			                             		0.0f );
*/
			//Vector3 newPos = new Vector3( 	-startPos.x/* +  w + /w * i*/,
			    //                         -startPos.y/* +  h + h * j*/, 
			      //                       0.0f );

				Vector3 newPos = new Vector3( 	-20.0f,
				                             	-20.0f, 
			                             		 0.0f );
			tile.transform.position = newPos;
			//tile.transform.position = new Vector3( tile.transform.position.x,// - 30.0f,
			//                                      tile.transform.position.y,
			  //                                    tile.transform.position.z);
			Instantiate( tile, tile.transform.position, tile.transform.rotation );
				Debug.Log(tile.name + newPos);
			}

		//return tile;
	}
	#endregion

	#region GameObject createObject ()
	GameObject createObject (int w, int h, Vector3 pos, string path )
	{
		GameObject obj = new GameObject ();
		obj.transform.position = pos;
		obj.AddComponent<SpriteRenderer> ();
		Sprite sprite = new Sprite ();
		WWW www = new WWW(path);

		sprite = Sprite.Create (www.texture, new Rect(-w / 2.0f, 0, w, h),new Vector2(0, 0));
	
		SpriteRenderer sRenderer = obj.GetComponent<SpriteRenderer> ();
		
		sRenderer.sprite = sprite;
		
		return obj;
	}
	#endregion
}
