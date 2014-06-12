using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public ArrayList enemyDetected;
	public GameObject projectile;
	private float coolDownCount;
	public float coolDownTime;
	public int buildCost;
	public GameObject towerUpgrade;

	// Use this for initialization
	void Start () {
		enemyDetected = new ArrayList();
		coolDownCount = 0f;
	}

	void Update(){
		if(!GameState.onPause){
			checkTarget();
			coolDownCount += Time.deltaTime;
			if(coolDownCount > coolDownTime)
				coolDownCount = coolDownTime;
			if(enemyDetected.Count > 0 && coolDownCount == coolDownTime) {
				shotBullet(enemyDetected[0] as GameObject);
			}
		}
	}

	public void checkTarget(){
		if(enemyDetected.Count>0&&enemyDetected[0] as GameObject == null)
			enemyDetected.Remove(enemyDetected[0]);
	}

	public void shotBullet(GameObject target){
		GameObject bullet = (GameObject)Instantiate(projectile);
		bullet.transform.position = transform.position;
		bullet.GetComponent<Bullet>().target = target;
		coolDownCount = 0f;
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
