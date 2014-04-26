using UnityEngine;
using System.Collections;

/**
 * скрипт управление уровнем
 * 
 * инициализиация
 * проверка цели уровня
 * завершение
 */ 

//[RequireComponent (typeof (AudioSource))]
public class CLevelController : MonoBehaviour 
{
	#region fields
	public float startOrthoSize = 100f;
	public float workOrthoSize  = 20f;
	public float stepForOrthoSize = 10f;
	private float stepForAmbLight = 1f;
	private bool isLevelStarted = false;

	private Camera thisCamera;
	private CBaseLevelGoal thisLevelGoal;
	private AudioSource bgMusic;
	private float	startLevelTime;
	private int	timeToGo = 4;
	private UILabel countDown; 

	#endregion
	// Use this for initialization
	
	#region void Start () 
	void Start () 
	{
		thisCamera = GetComponent<Camera> ();
		thisCamera.orthographicSize = startOrthoSize;
		RenderSettings.ambientLight = new Color (0.0f, 0.0f, 0.0f);
		thisLevelGoal = GetComponent<CBaseLevelGoal> ();
		bgMusic = GetComponentInChildren<AudioSource> ();
		//bgMusic.pitch = 0.0f;
		//stepForAmbLight = 1 / ((startOrthoSize - workOrthoSize) / stepForOrthoSize );
		stepForAmbLight = .1f;
		//Debug.Log ("Level goal is " + thisLevelGoal.ToString ());
		//Debug.Log ("stepForAmbLightis " + stepForAmbLight );
		Time.timeScale = 0.0f;
		startLevelTime = Time.time;
		timeToGo = 4;
		countDown = GameObject.Find("cntDwn").GetComponent<UILabel> ();
		isLevelStarted = false;
	}
	#endregion

	// Update is called once per frame
	
	#region void Update ()
	void Update ()
	{
		levelStart();
		
		if( Input.GetKeyDown( KeyCode.Escape ) && isLevelStarted ) 
		{

			globalVars.isGameActive = !globalVars.isGameActive;
			Time.timeScale = globalVars.isGameActive ? 1.0f : 0.0f ;
		}
		if(!globalVars.isGameActive) return;

		if( thisLevelGoal.isComplete() ) 
		{
			globalVars.isGameActive = false;
			if( levelComplete() ) 
			{
				Application.ExternalCall("PostProgress", globalVars.credits);
				Application.LoadLevel("2dmenuV2");
			}
		}
	}
	#endregion

	#region void startLevel ()
	void levelStart ()
	{
		if( isLevelStarted ) return;
		
		//Debug.Log ("levelStart");
		thisCamera.orthographicSize -= stepForOrthoSize;

		RenderSettings.ambientLight = Color.Lerp (RenderSettings.ambientLight, 
		                                          new Color (1.0f, 1.0f, 1.0f), 
		                                          stepForAmbLight );


		//RenderSettings.ambientLight += new Color (stepForAmbLight, stepForAmbLight, stepForAmbLight, 0.0f);

		Time.timeScale = (Time.timeScale < 1.0f) ? Time.timeScale + stepForAmbLight : 1.0f;
		bgMusic.pitch = Time.timeScale;
		//Debug.Log ("Time.timeScale = " +  Time.timeScale + " stepForAmbLight " + stepForAmbLight);
		if( thisCamera.orthographicSize < workOrthoSize ) 
		{
			thisCamera.orthographicSize = workOrthoSize;
		}
		GameObject.Find("Hero").GetComponent<CBaseHero>().startEngine( timeToGo );
		switch(timeToGo)
		{
			case 0:
				isLevelStarted = true;

				countDown.text = "Game Pause";
				var countDwn = GameObject.Find("cntDwn");
				if( countDwn != null ) countDwn.SetActive( false);
				//GameObject.Find("cntDwn").SetActive( false);
				RenderSettings.ambientLight = new Color (1f, 1f, 1f, 1.0f);
				Time.timeScale = 1f;
				break;
			case 1:
				globalVars.isGameActive = true;
				countDown.text = "Go!!!";
				var getReadyLbl = GameObject.Find("StartLevelLabel");
				if( getReadyLbl != null ) getReadyLbl.SetActive( false);
				break;
			case 2:
				countDown.text = "1...";
				break;
			case 3:
				countDown.text = "2...";
				break;
			case 4:
				countDown.text = "3...";
				break;
		};
		
		if( (Time.time - startLevelTime ) >= Time.timeScale )
			//if( timeToGo > 0 )
		{
			timeToGo--;
			startLevelTime = Time.time;
			
		}

	}
	#endregion

	#region bool levelComplete ()
	bool levelComplete ()
	{
		thisCamera.orthographicSize += stepForOrthoSize;// / 2f;
		RenderSettings.ambientLight -= new Color (stepForAmbLight, stepForAmbLight, stepForAmbLight, 0.0f);
		Time.timeScale = (Time.timeScale >  stepForAmbLight) ? Time.timeScale - stepForAmbLight : 0.0f ;
		bgMusic.pitch = Time.timeScale;
		//Debug.Log ("Time.timeScale = " +  Time.timeScale + " stepForAmbLight " + stepForAmbLight);
	
		return (thisCamera.orthographicSize >= startOrthoSize);
		
	}
	#endregion

	#region void OnGUI()
	void OnGUI()
	{
		if(globalVars.isGameActive || !isLevelStarted ) return;
		Time.timeScale = 0.0f;
		Vector2 btnSize = new Vector2 (160, 20);
		Vector2 startPos = new Vector2 (Screen.width / 2  - btnSize.x / 2, 
		                               Screen.height / 3);
		GUI.Box (new Rect (startPos.x - 20, startPos.y - 40, btnSize.x + 40, btnSize.y * 10), "Game Menu F* U!");
		if(GUI.Button(new Rect( startPos.x, startPos.y, btnSize.x, btnSize.y ), "Resume" ) )
		{
			globalVars.isGameActive = true;
			Time.timeScale = 1.0f;
		}

		
		if(GUI.Button(new Rect( startPos.x, startPos.y + btnSize.y * 6, btnSize.x, btnSize.y ), "Main Menu" ) )
		{
			globalVars.isGameActive = true;
			
			Time.timeScale = 1.0f;
			Application.LoadLevel("2dmenuV2");
		}
	}
	#endregion

}
