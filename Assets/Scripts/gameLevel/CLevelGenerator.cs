using UnityEngine;
using System.Collections;
using System.IO;

public class CLevelGenerator : MonoBehaviour
{

    #region fields
    //public GameObject[] tiles;
    //кол-во тайлов в ширину
    public int mapWidth  = 4;
    //кол-во тайлов в высоту
    public int mapHeight = 4;
	//pixels in unit
	public float pixInUnit = 51.2f;

	//путь куда сохранять
	public string pathToSave;
	//имя файла 
	public string levelName;
	//массив объектов уровня
	protected GameObject[]	objects;
    #endregion

	enum ColliderType
	{
		CT_BOX 		= 0,
		CT_CIRCLE 	= 1
	};

	// Use this for initialization
	#region void Start ()
	void Start ()
	{
		if (levelName == "")
			levelName = "levelName.txt";
		if (pathToSave == "")
			pathToSave =/* "level/" + */levelName;
		objects = new GameObject[1];
		CreateTiles (mapWidth, mapHeight, 512 /* mapWidth*/, 512 /* mapHeight*/);
		//Application.CaptureScreenshot ("sss.png");

	}
    #endregion

	// Update is called once per frame
	#region void Update ()
	void Update ()
	{

	}
    #endregion

	#region void CreateTiles (...)
	void CreateTiles (int row, int col, int w, int h )
	{
		string path = "file://c:\\DeveloperStudio\\UnityProjects\\Deathland\\deadland\\Assets\\Sprites\\ground\\sand.png";
		Vector2 startPos = new Vector2 (- w * row / 2 / pixInUnit, - h * col / 2 / pixInUnit);
		for(int i = 0; i < row; i++ )
			for( int j = 0; j < col; j++ )
			{
				Vector3 pos = new Vector3 ( 	startPos.x + i * w / pixInUnit +i, 
			          	                 		startPos.y + j * h / pixInUnit +j, 
			       			                    0);
				//Vector3 pos = new Vector3 ( 0, 0, 0);
				GameObject tile = createSprite (w, h, pos, path);
				objects[0] = tile;
				Instantiate( tile );
			}
	/*	WWW www = new WWW(path);
		//yield return www; 
		tile.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f );*/
	}
	#endregion

	#region GameObject createSprite ()
	GameObject createSprite (int w, int h, Vector3 pos, string path )
	{

		GameObject obj = new GameObject ();
		//obj.layer 	= "ground";
		//obj.tag 	= "ground";
		obj.transform.position = pos;
		obj.AddComponent<SpriteRenderer> ();
		Sprite sprite = new Sprite ();
		WWW www = new WWW(path);

		sprite = Sprite.Create (www.texture, new Rect(0, 0, w, h),new Vector2(0, 0), pixInUnit);
	
		SpriteRenderer sRenderer = obj.GetComponent<SpriteRenderer> ();
		
		sRenderer.sprite = sprite;
		
		return obj;
	}
    #endregion

	#region void addCollider (...)
	void addCollider (GameObject sprite, ColliderType type, Vector3 pos, float w, float h )
	{
		//Collider2D localCollider;
		/*switch( type )
		{
			case ColliderType.CT_BOX:
				BoxCollider2D localCollider = new BoxCollider2D();
				//localCollider.size = new Vector2( w, h );
				//localCollider.center = new Vector2( pos.x, pos.y );
				sprite.collider2D =  localCollider;
				break;
			case ColliderType.CT_CIRCLE:
				CircleCollider2D localCollider = new CircleCollider2D();
				//(CircleCollider2D)localCollider.radius = w;
				//(CircleCollider2D)localCollider.center = new Vector2( pos.x, pos.y );
				sprite.collider2D = localCollider;
				break;
		};
*/
	}
	#endregion

	// 
	#region public  void saveFile ()
	public void saveFile ()
	{
		StreamWriter sw = new StreamWriter (pathToSave);
		for (int i = 0; i < objects.Length; i++) 
		{
			sw.WriteLine("TestSave " + levelName + " " + i );
		}
		sw.Close ();

	}
	#endregion

	// загружаем файл уровня
	#region public void loadFile ()
	public void loadFile ()
	{
		
	}
	#endregion
}
