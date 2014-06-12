using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlowBuff : Buff{

	public float amplifier;
	private bool isApplied;
	private float initialSpeed;

	public override void initialize(){
		name = "Slow";
		isApplied = false;
	}
	
	public override void applyBuff(){
		buffEffect();
		time -= Time.deltaTime;
		if(time<=0)
			endBuff();
	}
	
	public void buffEffect(){
		if(!isApplied){
			initialSpeed = enemy.GetComponent<Follow>().speed;
			enemy.GetComponent<Follow>().speed *= amplifier;
			isApplied = true;
		}
	}
	
	public void endBuff(){
		enemy.GetComponent<Follow>().speed = initialSpeed;
		enemy.removeBuff(name);
	}
}