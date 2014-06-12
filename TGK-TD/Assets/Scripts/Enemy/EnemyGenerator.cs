using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public Follow enemy;
	private float unitGenerateTime;
	public float unitGenerateCooldown;

	private float waveGenerateTime;
	public float waveGenerateCooldown;
	public int numberInWave;
	private int numberGenerated;

	public int increaseNumberPerLevel;

	public GridManager gm;
	public PlayerStats ps;

	// Use this for initialization
	void Start () {
		unitGenerateTime = 0;
		numberGenerated = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameState.onPause&&!GameState.onGameOver){
			waveGenerateTime -= Time.deltaTime;
			if(waveGenerateTime<=0){
				if(numberGenerated<numberInWave){
					unitGenerateTime -= Time.deltaTime;
					if(unitGenerateTime<=0){
						generateEnemy();
						unitGenerateTime = unitGenerateCooldown;
					}
				}
				else{
					numberInWave += increaseNumberPerLevel;
					numberGenerated = 0;
					waveGenerateTime = waveGenerateCooldown;
				}
			}
		}
	}

	void generateEnemy(){
		Follow enemyGenerated = (Follow)Instantiate(enemy);
		enemyGenerated.GetComponent<EnemyStats>().ps = ps;
		int pathNumber = Random.Range(0,gm.startNodes.Length);
		enemyGenerated.path = gm.paths[pathNumber];
		enemyGenerated.transform.position = gm.getTileCenter(gm.startNodes[pathNumber]);
		numberGenerated++;
	}

	void OnTriggerExit2D (Collider2D other) {
		if(other.gameObject.tag != "Enemy")
			Destroy(other.gameObject);
	}
}
