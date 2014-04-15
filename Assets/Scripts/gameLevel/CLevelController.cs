using UnityEngine;
using System.Collections;

/**
 * скрипт управление уровнем
 * 
 * инициализиация
 * проверка цели уровня
 * завершение
 */ 

[ExecuteInEditMode]
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
		stepForAmbLight = 1 / ((startOrthoSize - workOrthoSize) / stepForOrthoSize );
		//Debug.Log ("Level goal is " + thisLevelGoal.ToString ());
		//Debug.Log ("stepForAmbLightis " + stepForAmbLight );
		Time.timeScale = 0.0f;

	}
	#endregion

	// Update is called once per frame
	
	#region void Update ()
	void Update ()
	{
		levelStart();
			
		if( thisLevelGoal.isComplete() ) 
		{
			
			globalVars.isGameActive = false;
			if( levelComplete() ) Application.LoadLevel("2dmenuV2");
		}

		if( Input.GetKeyDown( KeyCode.Escape ) ) 
		{
			globalVars.isGameActive = !globalVars.isGameActive;
			Debug.Log("globalVars.isGameActive = " + globalVars.isGameActive.ToString() );
		}
	}
	#endregion

	#region void startLevel ()
	void levelStart ()
	{
		if( isLevelStarted ) return;
		//isLevelStarted = fa;
		//Debug.Log ("RenderSettings.ambientLight = " + RenderSettings.ambientLight);
		thisCamera.orthographicSize -= stepForOrthoSize;
		//Mathf.Lerp (thisCamera.orthographicSize, workOrthoSize, stepForOrthoSize);
		/*RenderSettings.ambientLight = Color.Lerp (RenderSettings.ambientLight, 
		                                          new Color (1.0f, 1.0f, 1.0f), 
		                                          stepForAmbLight );
*/
		RenderSettings.ambientLight += new Color (stepForAmbLight, stepForAmbLight, stepForAmbLight, 0.0f);
		/*if( Time.timeScale < 1.0f )
			Time.timeScale += stepForAmbLight;
		else
			Time.timeScale = 1.0f;
		*/
		Time.timeScale = (Time.timeScale < 1.0f) ? Time.timeScale + stepForAmbLight : 1.0f;
		bgMusic.pitch = Time.timeScale;
		//Debug.Log ("Time.timeScale = " +  Time.timeScale + " stepForAmbLight " + stepForAmbLight);
		//if( RenderSettings.ambientLight != new Color (1.0f, 1.0f, 1.0f) ) isLevelStarted = false;
		//Time.timeScale = Mathf.Lerp (Time.timeScale, Input.GetKey (KeyCode.LeftShift) ? 0.2f : 1.0f, 0.25f);
		if( thisCamera.orthographicSize < workOrthoSize ) 
		{
			thisCamera.orthographicSize = workOrthoSize;
			globalVars.isGameActive = true;
			isLevelStarted = true;
		}

	}
	#endregion

	#region void startLevel ()
	bool levelComplete ()
	{
		thisCamera.orthographicSize += stepForOrthoSize / 2f;
		
		RenderSettings.ambientLight -= new Color (stepForAmbLight, stepForAmbLight, stepForAmbLight, 0.0f);
		Time.timeScale = (Time.timeScale >  stepForAmbLight) ? Time.timeScale - stepForAmbLight : 0.0f ;
		bgMusic.pitch = Time.timeScale;
		//Debug.Log ("Time.timeScale = " +  Time.timeScale + " stepForAmbLight " + stepForAmbLight);
	
		return (thisCamera.orthographicSize >= startOrthoSize);
		
	}
	#endregion
}
