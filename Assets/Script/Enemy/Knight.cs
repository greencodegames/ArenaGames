using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knight : IEnemy
{
	public float _Health;
	public float _Speed;
	public float _Damage;
	public float _attackSpeed;
	public GameObject player;

	public Animator anim;

	public NavMeshAgent enemy;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Awake(_Health,_Speed,_Damage,_attackSpeed);
		enemy = GetComponent<NavMeshAgent>();
		enemy.speed = _Speed;
	}

	public void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void Update()
	{
		Move(player,enemy);
		Death();		
	}

	public void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			Attack(player);
		}
	}
}
