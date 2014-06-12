using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject target;
	private Vector3 lastPosition;
	private float totalDistance;
	
	private Vector3 direction;
	private float currentDistance;
	private float distancePercentage;

	public bool isParabolic;
	public Buff buff;
	public float damage;
	public float speed;

	// Use this for initialization
	void Start () {
		if(target!=null){
			totalDistance = target.transform.position.x-transform.position.x;
			lastPosition = target.transform.position;
		}
		else
			Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameState.onPause){
			if(target!=null&&target.GetComponent<EnemyStats>().isActive){
				direction = target.transform.position - transform.position;
				lastPosition = target.transform.position;
				if(isParabolic)
					parabolicMovement();
			}
			else
				targetLost();
			direction.Normalize();
			direction *= speed * Time.deltaTime;
			if(isParabolic)
				direction.y+=0.07f*(1f-distancePercentage);
			transform.position += direction;
		}
	}

	private void parabolicMovement(){
		currentDistance = target.transform.position.x-this.transform.position.x;
		distancePercentage = (totalDistance-currentDistance)/totalDistance;
	}

	private void applyBuff(){
		Buff b = target.GetComponent<EnemyStats>().checkBuff(buff.name);
		if(b==null){
			buff = (Buff)Instantiate(buff);
			buff.initialize();
			target.GetComponent<EnemyStats>().addBuff(buff);
			buff.enemy = target.GetComponent<EnemyStats>();
		}
		else
			if(b.time<buff.time)
				b.time = buff.time;
	}	

	private void targetLost(){
		if((transform.position.x-lastPosition.x<0.1f&&transform.position.x-lastPosition.x>-0.1f)&&(transform.position.y-lastPosition.y<0.1f&&transform.position.y-lastPosition.y>-0.1f))
			Destroy(this.gameObject);
		else
			direction = lastPosition - transform.position;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject == target){
			target.GetComponent<EnemyStats>().damageThis(damage);
			if(buff!=null)
				applyBuff();
			Destroy(this.gameObject);
		}
	}
}
