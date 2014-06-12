using UnityEngine;
using System.Collections;

public class SwipeMap : MonoBehaviour {

	public float dragSpeed;
	public GameObject map;

	private float leftBound;
	private float upperBound;

	// Use this for initialization
	void Start () {
		leftBound = (-map.GetComponent<SpriteRenderer>().bounds.size.x/2)+9f;
		upperBound = (-map.GetComponent<SpriteRenderer>().bounds.size.y/2)+5f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void moveCamera(Vector3 add){
		Vector3.Normalize(add);
		add*=dragSpeed;
		Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x-add.x,leftBound,-leftBound),
		                                             Mathf.Clamp(Camera.main.transform.position.y-add.y,upperBound,-upperBound),
		                                             Camera.main.transform.position.z);
	}

	void OnMouseDrag(){
		moveCamera (new Vector3(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"),0));
	}
}
