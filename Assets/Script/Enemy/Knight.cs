using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : IEnemy
{
	public float _Health;
	public float _Speed;
	public float _Damage;
	public float _attackSpeed;
	public GameObject player;

	public Animator anim;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Awake(_Health,_Speed,_Damage,_attackSpeed);
	}

	public void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void Update()
	{
		Move(player);
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
