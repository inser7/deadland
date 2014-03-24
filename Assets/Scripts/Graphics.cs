using UnityEngine;
using System.Collections;

public class Graphics : MonoBehaviour {


    public Rect playerStats; //квадрат статистики игрока
    public Rect playerStatsPlayerMoney; //квадрат зоны отображения денег игрока


    void Awake(){
    //    playerStats = new Rect(10.0f, 10.0f, 150.0f, 100.0f);
      //  playerStatsPlayerMoney = new Rect(playerStats.x + 12.5f, playerStats.y + 30.0f, 125.0f, 25.0f);

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnGUI(){
      //  GUI.Box(playerStats, "Player Stats");
    //    GUI.Label(playerStatsPlayerMoney, "Money: " + globalVars.credits + "$");

    }
}
