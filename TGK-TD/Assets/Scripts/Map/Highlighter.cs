using UnityEngine;
using System.Collections;

public class Highlighter : MonoBehaviour {
	public Sprite available;
	public Sprite notAvailable;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setAvailable(bool canBePlace){
		if(canBePlace)
			gameObject.GetComponent<SpriteRenderer>().sprite = available;
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = notAvailable;
	}

	void isHighlighting (bool condition) {
		gameObject.GetComponent<SpriteRenderer>().enabled = condition;
	}
}
