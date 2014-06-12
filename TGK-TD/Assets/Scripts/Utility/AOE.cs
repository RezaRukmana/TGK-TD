using UnityEngine;
using System.Collections;

public class AOE : MonoBehaviour {

	private ArrayList enemyDetected;

	// Use this for initialization
	void Start () {
		enemyDetected = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public ArrayList getEnemyDetected(){
		return enemyDetected;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.tag == "Enemy")
		{
			if(!enemyDetected.Contains(other.gameObject))
				enemyDetected.Add(other.gameObject);
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if(other.gameObject.tag == "Enemy")
		{
			if(enemyDetected.Contains(other.gameObject))
				enemyDetected.Remove(other.gameObject);
		}
	}
}
