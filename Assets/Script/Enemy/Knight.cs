using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knight : MonoBehaviour
{
	private IEnemy knight;
	public Transform goldPosition;
	public GameObject gold;
	public Animator anim;
	public NavMeshAgent enemyMesh;

	public void Start()
	{
		anim = GetComponent<Animator>();
		enemyMesh = GetComponent<NavMeshAgent>();
		knight = GetComponent<IEnemy>();
		enemyMesh.speed = knight.Speed;
	}

	public void Update()
	{
		knight.Move(enemyMesh);
		knight.Death(goldPosition, gold);
	}
}
