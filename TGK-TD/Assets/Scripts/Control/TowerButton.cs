using UnityEngine;
using System.Collections;

public class TowerButton : DraggedButton {
	
	public GameObject instantiable;

	public override void setOcc(){
		occ=0;
	}

	// Update is called once per frame
	void Update () {
		setEnable(instantiable.GetComponent<Tower>().buildCost<=ps.gold);
	}

	void setEnable(bool e){
		isEnabled = e;
		setOpacity();
	}

	public override void buttonEffect(){
		Vector2 checkPos = gridManager.getTileIndex(origin);
		Node n = gridManager.nodes[(int)checkPos.x, (int)checkPos.y];
		if(n.occupier == 0 && (int)gridManager.mapArray[(int)checkPos.x,(int)checkPos.y] == 0){
			instantiable.transform.position = gridManager.getTileCenter(origin);
			n.occupier = 1;
			n.tower = (GameObject)Instantiate(instantiable);
			ps.incGold(-instantiable.GetComponent<Tower>().buildCost);
		}
	}
}
