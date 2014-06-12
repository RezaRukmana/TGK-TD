using UnityEngine;
using System.Collections;

public class InventoryButtonUI : ButtonUI {
	
	public int slot;
	public GameObject buttonSlot;

	// Use this for initialization
	void Start () {
		buttonSlot = (GameObject)Instantiate(buttonSlot);
	}
	
	public override void retainPosition(){
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width*0.1f+slot*75,Screen.height*0.1f,0));
		transform.position = new Vector3(pos.x, pos.y, -1.5f);
		buttonSlot.transform.position = transform.position + new Vector3(0,0,0.5f);
	}
}
