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
    public float workOrthoSize = 20f;
    public float stepForOrthoSize = 10f;
    private float stepForAmbLight = 1f;
    private bool isLevelStarted = false;

    private Camera thisCamera;
    private CBaseLevelGoal thisLevelGoal;
    private AudioSource bgMusic;
    private float startLevelTime;
    private int timeToGo = 4;
    private UILabel countDown;

    #endregion
    // Use this for initialization

    #region void Start ()
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        thisCamera.orthographicSize = startOrthoSize;
        RenderSettings.ambientLight = new Color(0.0f, 0.0f, 0.0f);
        thisLevelGoal = GetComponent<CBaseLevelGoal>();
        bgMusic = GetComponentInChildren<AudioSource>();
        //bgMusic.pitch = 0.0f;
        stepForAmbLight = 1 / ((startOrthoSize - workOrthoSize) / stepForOrthoSize);
        stepForAmbLight = .01f;
        //Debug.Log ("Level goal is " + thisLevelGoal.ToString ());
        //Debug.Log ("stepForAmbLightis " + stepForAmbLight );
        Time.timeScale = 0.0f;
        startLevelTime = Time.time;

        countDown = GameObject.Find("cntDwn").GetComponent<UILabel>();
    }
    #endregion

    // Update is called once per frame

    #region void Update ()
    void Update()
    {
        levelStart();

        if (thisLevelGoal.isComplete())
        {

            globalVars.isGameActive = false;
            if (levelComplete())
            {
                Application.ExternalCall("PostProgress", globalVars.credits);
                Application.LoadLevel("2dmenuV2");
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            globalVars.isGameActive = !globalVars.isGameActive;
            Debug.Log("globalVars.isGameActive = " + globalVars.isGameActive);
        }
    }
    #endregion

    #region void startLevel ()
    void levelStart()
    {
        if (isLevelStarted) return;

        thisCamera.orthographicSize -= stepForOrthoSize;

        RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight,
                                                  new Color(1.0f, 1.0f, 1.0f),
                                                  stepForAmbLight);


        //RenderSettings.ambientLight += new Color (stepForAmbLight, stepForAmbLight, stepForAmbLight, 0.0f);

        Time.timeScale = (Time.timeScale < 1.0f) ? Time.timeScale + stepForAmbLight : 1.0f;
        bgMusic.pitch = Time.timeScale;
        //Debug.Log ("Time.timeScale = " +  Time.timeScale + " stepForAmbLight " + stepForAmbLight);
        if (thisCamera.orthographicSize < workOrthoSize)
        {
            thisCamera.orthographicSize = workOrthoSize;
        }
        switch (timeToGo)
        {
            case 0:
                globalVars.isGameActive = true;
                isLevelStarted = true;
                GameObject.Find("cntDwn").SetActive(false);
                RenderSettings.ambientLight = new Color(1f, 1f, 1f, 1.0f);
                Time.timeScale = 1f;
                break;
            case 1:
                countDown.text = "Go!!!";
                var getReadyLbl = GameObject.Find("StartLevelLabel");
                if (getReadyLbl != null) getReadyLbl.SetActive(false);
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

        if ((Time.time - startLevelTime) >= Time.timeScale)
        {
            timeToGo--;
            startLevelTime = Time.time;

        }

    }
    #endregion

    #region void startLevel ()
    bool levelComplete()
    {
        thisCamera.orthographicSize += stepForOrthoSize / 2f;

        RenderSettings.ambientLight -= new Color(stepForAmbLight, stepForAmbLight, stepForAmbLight, 0.0f);
        Time.timeScale = (Time.timeScale > stepForAmbLight) ? Time.timeScale - stepForAmbLight : 0.0f;
        bgMusic.pitch = Time.timeScale;
        //Debug.Log ("Time.timeScale = " +  Time.timeScale + " stepForAmbLight " + stepForAmbLight);

        return (thisCamera.orthographicSize >= startOrthoSize);

    }
    #endregion

    #region void OnGUI()
    void OnGUI()
    {
        GUI.TextArea(new Rect(20, 100, 70, 20), "FPS: " + (Mathf.Round(Time.captureFramerate)).ToString());

    }
    #endregion
}
