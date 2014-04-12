using UnityEngine;
using System.Collections;
using System.IO;

public class CLevelGenerator : MonoBehaviour
{

    #region fields
    //кол-во тайлов в ширину
    public int mapWidth  = 4;
    //кол-во тайлов в высоту
    public int mapHeight = 4;
	//pixels in unit
	public float pixInUnit = 51.2f;

	//public CBaseLevelGoal goal;
	//путь куда сохранять
	public string pathToSave;
	//имя файла 
	public string levelName;
	//массив объектов уровня
	protected GameObject[]	objects;
	protected string[]		texturesPaths;		//кол-во НЕ ОБЯЗАТЕЛЬНО(вообще навряд ли) равно objects.length
	protected int[]			texturesIndicies; 	//кол-во равно objects.length, хранятся индесы текстур для объектов
	//
	//protected int currentObjIndex = 0;
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
		//CreateTiles (mapWidth, mapHeight, 512, 512);
		//Application.CaptureScreenshot ("sss.png");

	}
    #endregion

	// Update is called once per frame
	#region void Update ()
	void Update ()
	{


	}
    #endregion

	#region public void CreateTiles (...)
	public void CreateTiles (int row, int col, int w, int h )
	{
		string path = "file://c:\\DeveloperStudio\\UnityProjects\\Deathland\\deadland\\Assets\\Sprites\\ground\\sand.png";
		
		//addTexturePath (path);
		Vector2 startPos = new Vector2 (- w * row / 2 / pixInUnit, - h * col / 2 / pixInUnit);
		for(int i = 0; i < row; i++ )
			for( int j = 0; j < col; j++ )
			{
				Vector3 pos = new Vector3 ( 	startPos.x + i * w / pixInUnit +i, 
			          	                 		startPos.y + j * h / pixInUnit +j, 
			       			                    0);
				//Vector3 pos = new Vector3 ( 0, 0, 0);
			//GameObject tile = 
				createSprite (w, h, pos, path, "tile_"+i.ToString()+"x"+j.ToString());
				//addObject(tile);
			}
	/*	WWW www = new WWW(path);
		//yield return www; 
		tile.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f );*/
	}
	#endregion

	#region GameObject createSprite ()
	void/*GameObject*/ createSprite (int w, int h, Vector3 pos, string path, string spriteName )
	{
		
		addTexturePath (path);
		GameObject obj = new GameObject ();
		//obj.layer 	= "ground";
		//obj.tag 	= "ground";
		
		obj.name = spriteName;
		obj.transform.position = pos;
		obj.AddComponent<SpriteRenderer> ();
		Sprite sprite = new Sprite ();
		WWW www = new WWW(path);


		WWW www2 = new WWW(www.url);
		sprite = Sprite.Create (www2.texture, new Rect(0, 0, w, h),new Vector2(0, 0), pixInUnit);

		SpriteRenderer sRenderer = obj.GetComponent<SpriteRenderer> ();
		
		sRenderer.sprite = sprite;
		addObject (obj);
		texturesIndicies [texturesIndicies.Length - 1] = getTexturePathIndex (path);
		//return obj;
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
		if( objects == null ) 
		{
			Debug.Log ("no objects to save");
			return;
		}
		Debug.Log ("saving file : " + pathToSave);
		StreamWriter sw = new StreamWriter (pathToSave);
		Debug.Log ("texture paths saving");
		sw.WriteLine("textures");
		sw.WriteLine( texturesPaths.Length );
		for (int i = 0; i < texturesPaths.Length; i++) 
		{
			//пишем пути текстур всех
			sw.WriteLine(texturesPaths[i]);
		}
		sw.WriteLine("^_^  >___<  =) 8===Э  ( . )( . )  (__.__) no info just a fun");

		Debug.Log ("objects info saving");
		sw.WriteLine ( "objects" );
		sw.WriteLine ( objects.Length );

		for (int i = 0; i < objects.Length; i++) 
		{
			if( objects[i] == null ) Debug.Log(" object["+i+"] is null! WHY??!!!");
			if( objects[i] != null )
			{
				/*данные об объекте*/
				sw.WriteLine(objects[i].name);					//имя объекта
				sw.WriteLine(objects[i].transform.position);	//позиция объекта
				SpriteRenderer sRenderer = objects[i].GetComponent<SpriteRenderer> ();
				sw.WriteLine( sRenderer.sprite.rect.width );	//spriteWidth
				sw.WriteLine( sRenderer.sprite.rect.height );	//spriteHeight
				sw.WriteLine( texturesIndicies[i] );			//indexTexture
				/*данные о коллайдере*/
				/*тип
				 *центер
				 *радиус или размер
				 *триггер ли?
				 * */
				/*данные о */

			}
		}
		sw.Close ();
		
		Debug.Log ("file saved: " + pathToSave);

	}
	#endregion

	// загружаем файл уровня
	#region public void loadFile ()
	public void loadFile ()
	{
		Debug.Log ("loading file : " + pathToSave);
		StreamReader sr = new StreamReader (pathToSave);
		if(sr != null)
		{
			// сначала считываем данные о текстурах
			sr.ReadLine();
			
			Debug.Log ("loading textures paths");
			int localCount = System.Convert.ToInt32( sr.ReadLine() );
			for(int i = 0; i< localCount; i++)
			{
				texturesPaths = null;
				addTexturePath( System.Convert.ToString (sr.ReadLine() ) );
			}
			
			sr.ReadLine(); //съедаем 2  не несущие
			sr.ReadLine(); // информации строки
			localCount = 0;
		    localCount = System.Convert.ToInt32( sr.ReadLine() );
			// считываем данные об объектах
			
			Debug.Log ("loading objects info");
			for(int i = 0; i< localCount; i++)
			{
				string  spriteName = System.Convert.ToString(sr.ReadLine() );//имя объекта
				Vector3 spritePos = stringToVector3( sr.ReadLine() );//позиция;

				int 	spriteWidth  = System.Convert.ToInt32(sr.ReadLine() );//ширина;
				int 	spriteHeight = System.Convert.ToInt32(sr.ReadLine() );//высота;
				int     textureIndex = System.Convert.ToInt32(sr.ReadLine() );//индекс текстуры;;
				string  pathToTexure = getTexturePathFromIndex( textureIndex );
				//GameObject obj = 
					createSprite (spriteWidth,spriteHeight, spritePos, pathToTexure, spriteName);


				//addObject(obj);

			}
			Debug.Log ("file loaded: " + pathToSave);
			return;
		}
		else
			Debug.Log ("ERROR loadFile () : Nothing to read..." + pathToSave );
	}
	#endregion


	#region public  void addObject (...)
	/*public*/ void addObject ( GameObject obj)
	{
		if( objects == null)
		{//если массив пустой
			objects = new GameObject[1];
			texturesIndicies = null;
			texturesIndicies = new int[1];

			objects[0] = obj;
			return;
		}
		//добавляем новый obj
		GameObject[] tempObj = objects;
		//Debug.Log ("tempObj.Length = " + tempObj.Length);
		objects = new GameObject[ tempObj.Length + 1];
		for( int i = 0; i < tempObj.Length; i++ )
			objects[i] = tempObj[i];
		objects [objects.Length - 1] = obj;
		tempObj = null;
		//добавляем новый индекс текстуры
		int[] tempInd = texturesIndicies;
		texturesIndicies = new int[ tempInd.Length + 1];
		for( int i = 0; i < tempInd.Length; i++ )
			texturesIndicies[i] = tempInd[i];

		tempInd = null;
	}
	#endregion

	#region public  void addTexturePath (...)
	/*public*/ void addTexturePath ( string pathToTexture )
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
		string[] tempStr = texturesPaths;
		texturesPaths = new string[ tempStr.Length + 1];
		for( int i = 0; i < tempStr.Length; i++ )
			texturesPaths[i] = tempStr[i];
		texturesPaths[ texturesPaths.Length - 1 ] = pathToTexture;
		tempStr = null;
	}
	#endregion

	#region public  int getTexturePathIndex (...)
	/*public*/ int getTexturePathIndex ( string pathToTexture )
	{
		for( int i = 0; i < texturesPaths.Length; i++ )
		{
			if( texturesPaths[i] == pathToTexture ) return i;
		}
		//если -1, то нет такой текстуры( можно на дефолтный вариант 0 поставить )
		return -1;
		
	}
	#endregion

	#region public  string getTexturePathFromIndex (...)
	/*public*/ string getTexturePathFromIndex ( int textureIndex )
	{
		if( textureIndex >= texturesPaths.Length ) return "Fuck U!";
		if( texturesPaths == null ) return "Fuck U2!";
		return texturesPaths [textureIndex];		
	}
	#endregion
	
	#region public Vector3 stringToVector3 (...)
	/*public*/ Vector3 stringToVector3 ( string src )
	{
		Vector3 result = new Vector3 (0.0f, 0.0f, 0.0f);
		src = src.Substring (1).Remove (src.Length - 2);
		//Debug.Log ("src : " + src );
		char[] sep = new char[]{','};
		string[] values = src.Split( sep );
		result.x = System.Convert.ToSingle( values[0] );
		result.y = System.Convert.ToSingle( values[1] );
		result.z = System.Convert.ToSingle( values[2] );
		
		return result;	
	}
	#endregion

	#region public Void clearLevel ()
	public void clearLevel ()
	{
		/*for( int i = 0; i < objects.Length; i++ )
			Destroy( objects[i] ); //НЕ РАБОТАЕТ О_О
		objects = null;
 		texturesPaths = null;
		texturesIndicies = null;
		*/
	}
	#endregion

	/*
	 * прогоняем все объекты в сцене
	 */
	#region public void sceneAnalizator ()
	public void sceneAnalizator ( string tag )
	{
		objects = GameObject.FindGameObjectsWithTag (tag);
		/*
		 * узнать все используемые текстуры
		 * сделать индексы текстур
		 */


	}
	#endregion
}