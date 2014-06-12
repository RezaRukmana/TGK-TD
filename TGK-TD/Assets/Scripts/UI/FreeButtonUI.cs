using UnityEngine;
using System.Collections;

public class FreeButtonUI : ButtonUI {

	public Vector2 positionInScreenRatio;

	// Use this for initialization
	void Start () {
	
	}
	
	public override void retainPosition(){
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width*positionInScreenRatio.x,Screen.height*positionInScreenRatio.y,0));
		transform.position = new Vector3(pos.x, pos.y, -1.5f);
	}
}
