using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public static bool onPause;
	public static bool onGameOver;

	// Use this for initialization
	void Start () {
		onPause = false;
		onGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
