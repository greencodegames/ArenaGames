using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orc : IEnemy
{

	public float _Health;
	public float _Speed;
	public float _Damage;
	public float _attackSpeed;
	public GameObject player;

	public NavMeshAgent enemy;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Awake(_Health, _Speed, _Damage, _attackSpeed);
		
	}

	public void Start()
	{
		

	}

	public void Update()
	{
		Move(player,enemy);
		Death();
	}
}
