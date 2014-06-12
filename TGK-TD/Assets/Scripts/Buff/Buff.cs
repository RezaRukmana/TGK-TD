using UnityEngine;
using System.Collections;

public abstract class Buff : MonoBehaviour{
	public abstract void applyBuff();
	public float time;
	public EnemyStats enemy;
	
	public abstract void initialize();

	public void destroyThis(){
		Destroy(this.gameObject);
	}
}
