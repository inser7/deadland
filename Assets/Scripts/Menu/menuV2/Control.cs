using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {


	private AsyncOperation Checker; //Загрузка уровня
	public UISlider  LoadSlider;
	private float loading_progress = 0f;
	private int Round_load;


	private string LeveName;
	private GUIStyle SKIN;
	private bool Menu = true;
	// Use this for initialization
	/*
	void start(){
		LoadSlider.sliderValue = 0f;
	}*/
	void Newgame () {
        //Application.LoadLevel("MainScene.unity.REMOTE");
		//Asop = Application.LoadLevelAsync ("MainScene.unity.REMOTE");
		//Asop.allowSceneActivation = false;
		/*while (!Asop.isDone) 
		{
			LoadSlider.sliderValue =  (int)(	*100f);
			//yield return null;
		} */
		StartCoroutine(DisplayLoadingScreen("MainScene.unity.REMOTE"));
	}

	/*
	void OnGUI(){
		if(Menu){
			if(Input.GetKeyDown ("space")){
				
				Checker=Application.LoadLevelAsync("MainScene.unity.REMOTE");
				
				Checker.allowSceneActivation=false;
				Menu=false;
				
			}
		}
		
		if(!Checker.isDone){
			if(Input.GetButton ("Fire1")){
				Checker.allowSceneActivation=true;
			}
		}
		
		
		if(Checker !=null){
			GUI.Box(new Rect(0, Screen.height-50,Checker.progress*Screen.width*100,40),"");
			
		}
		
		
		
	}
*/
			


	IEnumerator DisplayLoadingScreen(string Level)
	{	
		//LoadSlider.sliderValue = (Round_load);
		AsyncOperation async = Application.LoadLevelAsync(Level);
		while (!async.isDone) {
			//Round_load = (int)(async.progress*100);
			LoadSlider.sliderValue = (async.progress*100f);
			yield return null;
		}
		yield return async;
	}


	// Update is called once per frame
	void Garage () {
		//Asop.allowSceneActivation = true;
        Application.LoadLevel("garage3D");
	}
}
