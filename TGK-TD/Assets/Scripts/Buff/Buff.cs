using UnityEngine;
using System.Collections;

public abstract class Buff : MonoBehaviour{
	public abstract void applyBuff();
	public float time;
	public EnemyStats enemy;
	
	public abstract void initialize();
<<<<<<< HEAD
=======

	public void destroyThis(){
		Destroy(this.gameObject);
	}
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
}
