using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int gold;
	public int life;

	public GUIStyle tdStyle = new GUIStyle();
	private Rect rectGold;
	private Rect rectLife;
	public bool isTextOnMiddle;

	// Use this for initialization
	void Start () {
		positionText();
	}
	
	// Update is called once per frame
	void Update () {
		if(life<=0)
			GameState.onGameOver = true;
	}

	public void incGold(int add){
		gold+=add;
	}

	public void decLife(int dec){
		life-=dec;
	}

	void positionText(){
		tdStyle.fontSize = 24;
		rectGold.width = Screen.width*0.3f;
		rectGold.height = Screen.height*0.1f;
		rectLife.width = Screen.width*0.3f;
		rectLife.height = Screen.height*0.1f;
		rectGold.y = rectLife.y+25;
		if(isTextOnMiddle){
			tdStyle.alignment = TextAnchor.MiddleCenter; 
			rectGold.x = (Screen.width*(1-0.3f))/2;
			rectLife.x = (Screen.width*(1-0.3f))/2;
		}
	}

	void OnGUI(){
		GUI.Label(rectLife, "Life : "+life.ToString(), tdStyle);
		GUI.Label(rectGold, "Gold : "+gold.ToString(), tdStyle);
	}
}
