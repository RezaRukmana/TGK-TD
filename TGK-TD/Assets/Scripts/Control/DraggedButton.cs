using UnityEngine;
using System.Collections;

public abstract class DraggedButton : MonoBehaviour {
	
	public GameObject draggable;
	private GameObject draggableInstant;
	public Vector3 origin;
	public float posZ;
	public GridManager gridManager;
	public int occ;
	public bool isEnabled = true;
	public PlayerStats ps;

	// Use this for initialization
	void Start () {
		origin = draggable.transform.position;
		posZ = origin.z;
		setOcc();
	}

	void OnMouseDown(){
		if(isEnabled&&!GameState.onPause){
			draggableInstant = (GameObject)Instantiate(draggable);
			draggableInstant.transform.position = transform.position;
		}
	}

	void OnMouseDrag () {
		if(isEnabled&&!GameState.onPause){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = origin.z;
			draggableInstant.transform.position = pos;
			gridManager.highLight(pos,true, occ);
		}
	}

	void OnMouseUp () {
		if(isEnabled&&!GameState.onPause){
			origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			origin.z = posZ;
			buttonEffect();
			gridManager.highLight(origin,false,occ);
			Destroy(draggableInstant.gameObject);
		}
	}

	public abstract void buttonEffect();
	public abstract void setOcc();

	public void setOpacity(){
		if(!isEnabled)
			renderer.material.color = new Color (1,1,1,0.5f);
		else
			renderer.material.color = new Color (1,1,1,1);
	}
}
