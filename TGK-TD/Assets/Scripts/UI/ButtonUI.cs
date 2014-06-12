using UnityEngine;
using System.Collections;

public abstract class ButtonUI : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		retainPosition();
	}
	
	public abstract void retainPosition();
}
