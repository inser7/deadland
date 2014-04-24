using UnityEngine;
using System.Collections;
/***
 * 
 * http://wiki.unity3d.com/index.php?title=FramesPerSecond
 * 
 * */
public class HUDFPS : MonoBehaviour 
{
	
	// Attach this to a GUIText to make a frames/second indicator.
	//
	// It calculates frames/second over each updateInterval,
	// so the display does not keep changing wildly.
	//
	// It is also fairly accurate at very low FPS counts (<10).
	// We do this not by simply counting frames per interval, but
	// by accumulating FPS for each frame. This way we end up with
	// correct overall FPS even if the interval renders something like
	// 5.5 frames.
	
	public  float updateInterval = 0.5F;
	
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	private string format = "FPS";
	void Start()
	{
	/*	if( !guiText )
		{
			Debug.Log("UtilityFramesPerSecond needs a GUIText component!");
			enabled = false;
			return;
		}*/

		timeleft = updateInterval;  
	}
	
	void Update()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 )
		{
			// display two fractional digits (f2 format)
			float fps = accum/frames;
			format = "FPS: " + Mathf.RoundToInt( fps ).ToString();//System.String.Format("FPS {0:F2}",fps);
			//guiText.text = format;
			
			/*if(fps < 30)
				GUI.color = Color.yellow;
			else 
				if(fps < 10)
					GUI.color = Color.red;
			else
				GUI.color = Color.green;
			
			GUI.backgroundColor = new Color (1, 0, 0);*/

			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}
	}

	#region void OnGUI()
	void OnGUI()
	{
		/* это лишь для тестирования
		 * 
		 * */
		GUI.TextArea( new Rect( 20, 100, 70, 20 ), format );
	}
	#endregion
}
	