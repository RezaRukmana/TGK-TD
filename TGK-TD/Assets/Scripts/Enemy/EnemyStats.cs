﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyStats : MonoBehaviour {
public List<Buff> appliedBuffs = new List<Buff>();
	public float maxHP;
	private float HP;
	public float damageAmplifier;
	public bool isActive = true;
	public GameObject hpBar;
	private Vector3 hpBarFullScale;

	public PlayerStats ps;
	public int goldLoot;
	public int lifeDecrease;

	// Use this for initialization
	void Start () {
		HP = maxHP;
		hpBarFullScale = hpBar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameState.onPause){
			hpBar.transform.localScale = new Vector3(hpBarFullScale.x*HP/maxHP,hpBarFullScale.y,1);
			for(int i=0;i<appliedBuffs.Count;i++){
				appliedBuffs[i].applyBuff();
			}
			if(HP<0){
<<<<<<< HEAD
				onDeath();
=======
				ps.incGold(goldLoot);
				Destroy(gameObject);
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
			}
		}
	}

	public void addBuff(Buff b){
		appliedBuffs.Add(b);
	}
<<<<<<< HEAD

	public virtual void onDeath(){
		ps.incGold(goldLoot);
		for(int i=0;i<appliedBuffs.Count;i++){
			Destroy(appliedBuffs[i].gameObject);
		}
		Destroy(gameObject);
	}
=======
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
	
	public void removeBuff(string s){
		for(int i=0;i<appliedBuffs.Count;i++){
			if(appliedBuffs[i].name.Equals(s)){
<<<<<<< HEAD
=======
				appliedBuffs[i].destroyThis();
>>>>>>> 62b5ea3004f9fc53052ba8854540ff0c30e3dd0d
				appliedBuffs.RemoveAt(i);
				return;
			}
		}
	}

	public Buff checkBuff(string s){
		for(int i=0;i<appliedBuffs.Count;i++){
			if(appliedBuffs[i].name.Equals(s))
				return appliedBuffs[i];
		}
		return null;
	}

	public void damageThis(float damage){
		this.HP -= damageAmplifier*damage;
	}

	public void addDamageAmplifier(float da){
		this.damageAmplifier += da;
		if(damageAmplifier>2.5f)
			damageAmplifier = 2.5f;
		else if(damageAmplifier<0.5f)
			damageAmplifier = 0.5f;
	}


	public float getHP(){
		return HP;
	}

}
