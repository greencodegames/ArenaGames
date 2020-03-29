using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orc : IEnemy
{
	private IEnemy orc;
	public Transform goldPosition;
	public GameObject gold;
	public NavMeshAgent enemyMesh;

	public void Start()
	{
		//anim = GetComponent<Animator>();
		enemyMesh = GetComponent<NavMeshAgent>();
		//orc = GetComponent<IEnemy>();
		enemyMesh.speed = Speed;
	}

	public void Update()
	{
		Move(enemyMesh);
		Death(goldPosition, gold);
		//orc.Move(enemyMesh);
		//orc.Death(goldPosition, gold);
	}
}
