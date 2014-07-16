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

<<<<<<< HEAD
	private GridManager gm;
	private PlayerStats ps;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("Map").GetComponent<GridManager>();
		ps = Camera.main.GetComponent<PlayerStats>();
=======
	public GridManager gm;
	public PlayerStats ps;

	// Use this for initialization
	void Start () {
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
		unitGenerateTime = 0;
		numberGenerated = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameState.onPause&&!GameState.onGameOver){
			waveGenerateTime -= Time.deltaTime;
			if(waveGenerateTime<=0){
<<<<<<< HEAD
				generateBehaviour();
=======
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
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
			}
		}
	}

<<<<<<< HEAD
	public virtual void generateBehaviour(){
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

	public virtual void generateEnemy(){
=======
	void generateEnemy(){
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
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
