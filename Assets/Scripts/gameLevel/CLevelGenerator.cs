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
	protected string[]		texturesPaths;		//кол-во НЕ ОБЯЗАТЕЛЬНО(вообще навряд ли) равно objects.length
	protected int[]			texturesIndicies; 	//кол-во равно objects.length, хранятся индесы текстур для объектов
	//
	protected int currentObjIndex = 0;
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
		objects = new GameObject[mapWidth * mapHeight];
		CreateTiles (mapWidth, mapHeight, 512, 512);
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

		addTexturePath (path);
		addTexturePath (path);
		addTexturePath (path);
		Vector2 startPos = new Vector2 (- w * row / 2 / pixInUnit, - h * col / 2 / pixInUnit);
		for(int i = 0; i < row; i++ )
			for( int j = 0; j < col; j++ )
			{
				Vector3 pos = new Vector3 ( 	startPos.x + i * w / pixInUnit +i, 
			          	                 		startPos.y + j * h / pixInUnit +j, 
			       			                    0);
				//Vector3 pos = new Vector3 ( 0, 0, 0);
				GameObject tile = createSprite (w, h, pos, path);
				addObject(tile);
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
		obj.name = "lalalla";
		obj.transform.position = pos;
		obj.AddComponent<SpriteRenderer> ();
		Sprite sprite = new Sprite ();
		WWW www = new WWW(path);

		Debug.Log ("www.url" + www.url);
		WWW www2 = new WWW(www.url);
		sprite = Sprite.Create (www2.texture, new Rect(0, 0, w, h),new Vector2(0, 0), pixInUnit);

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
		sw.WriteLine("textures");
		sw.WriteLine( texturesPaths.Length );
		for (int i = 0; i < texturesPaths.Length; i++) 
		{
			//пишем пути текстур всех
			sw.WriteLine(texturesPaths[i]);
		}
		sw.WriteLine("^_^  >___<  =) 8===Э  ( . )( . )  (__.__)");
		sw.WriteLine ( "objects" );
		sw.WriteLine ( objects.Length );
		for (int i = 0; i < objects.Length; i++) 
		{
			sw.WriteLine(objects[i].name);					//имя объекта
			sw.WriteLine(objects[i].transform.position);	//позиция объекта
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


	#region public  void addObject (...)
	public void addObject ( GameObject obj)
	{
		if( currentObjIndex >= objects.Length )
		{
			Debug.Log("addObject: trying to add out of range, objects.Length = " + objects.Length 
			          + " your  currentObjIndex is " + currentObjIndex + ". This is XYEBO =)");
			return;
		}
		objects [currentObjIndex] = obj;
		currentObjIndex++;
	
	}
	#endregion

	#region public  void addTexturePath (...)
	public void addTexturePath ( string pathToTexture )
	{
		if( texturesPaths == null)
		{//если массив пустой
			texturesPaths = new string[1];
			texturesPaths[0] = pathToTexture;
			return;
		}

		for( int i = 0; i < texturesPaths.Length; i++ )
		{
			//если такой путь до текстуры есть, то уходим
			if( texturesPaths[i] == pathToTexture ) return;

		}
		//добавляем новый путь
		string[/* texturesPaths.Length */] tempStr = texturesPaths;
		texturesPaths = new string[ tempStr.Length + 1];
		texturesPaths = tempStr;
		texturesPaths[ texturesPaths.Length - 1 ] = pathToTexture;
		tempStr = null;
	}
	#endregion

	#region public  void addTexturePath (...)
	public int getTexturePathIndex ( string pathToTexture )
	{
		for( int i = 0; i < texturesPaths.Length; i++ )
		{
			if( texturesPaths[i] == pathToTexture ) return i;
		}
		//если -1, то нет такой текстуры( можно на дефолтный вариант 0 поставить )
		return -1;
		
	}
	#endregion
}