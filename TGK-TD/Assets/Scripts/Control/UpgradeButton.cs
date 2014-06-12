using UnityEngine;
using System.Collections;

public class UpgradeButton : DraggedButton {

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
			if(n.tower.GetComponent<Tower>().towerUpgrade!=null&&n.tower.GetComponent<Tower>().buildCost<=ps.gold){
				Destroy(n.tower.gameObject);
				n.tower.GetComponent<Tower>().towerUpgrade.transform.position = n.tower.transform.position;
				n.tower = (GameObject)Instantiate(n.tower.GetComponent<Tower>().towerUpgrade);
				ps.incGold(-n.tower.GetComponent<Tower>().buildCost);
			}
		}
	}
}
