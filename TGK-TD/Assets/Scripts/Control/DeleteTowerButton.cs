using UnityEngine;
using System.Collections;

public class DeleteTowerButton : DraggedButton {

	public float sellPrecentage;

	public override void setOcc(){
		occ=1;
	}

	// Update is called once per frame
	void Update () {

	}
	
	public override void buttonEffect(){
		Vector2 checkPos = gridManager.getTileIndex(origin);
		Node n = gridManager.nodes[(int)checkPos.x, (int)checkPos.y];
		if(n.occupier == 1){
			n.occupier = 0;
			ps.incGold((int)(n.tower.GetComponent<Tower>().buildCost*sellPrecentage));
			Destroy(n.tower.gameObject);
		}
	}
}
