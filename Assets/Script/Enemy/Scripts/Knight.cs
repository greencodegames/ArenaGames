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

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Awake(_Health,_Speed,_Damage,_attackSpeed);
	}

	public void Start()
	{
		
	}

	public void Update()
	{
		
		Move(player);
		Death();		
	}
}
