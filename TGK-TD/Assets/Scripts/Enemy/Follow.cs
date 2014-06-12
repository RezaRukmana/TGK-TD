using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public Path path;
	public float speed = 0.5f;
	public bool isLooping = true;
	public bool isStop;
	
	private float curSpeed;
	private int curPathIndex;
	private float pathLength;
	private Vector3 targetPoint;
	
	public Vector3 velocity;

	// Use this for initialization
	void Start () {
		pathLength = path.Length;
		curPathIndex = 0;
		velocity = new Vector3(0,0,0);
		isStop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isStop && !GameState.onPause){
			curSpeed = speed * Time.fixedDeltaTime;
			targetPoint = path.getPoint(curPathIndex);
			if(Vector3.Distance(transform.position, targetPoint) < path.radius) {
				if(curPathIndex < pathLength - 1)
					curPathIndex++;
				else if (isLooping)
					curPathIndex = 0;
				else{
					GetComponent<EnemyStats>().ps.decLife(GetComponent<EnemyStats>().lifeDecrease);
					Destroy(this.gameObject);
				}
			}
			if(curPathIndex >= pathLength)
				return;
			if(curPathIndex >= pathLength-1 && !isLooping)
				velocity = Steer(targetPoint, true);
			else
				velocity = Steer(targetPoint);
			velocity.z = 0;
			transform.position += velocity;
		}
	}

	public Vector3 Steer(Vector3 target, bool isFinalPoint = false) {
		Vector3 desiredVelocity = (target - transform.position);
		desiredVelocity.Normalize();
		desiredVelocity *= curSpeed;
		return desiredVelocity;
	}

	void Stop (bool value) {
		isStop = value;
	}

	public void setCurPathIndex(int i){
		curPathIndex = i;
	}

	public int getCurPathIndex(){
		return curPathIndex;
	}
}
