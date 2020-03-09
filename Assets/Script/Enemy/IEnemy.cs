using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IEnemy : MonoBehaviour
{
	public float Health;
	public float maxHealth;
	public float Speed;
	public float Damage;
	public float attackSpeed;
	private float timeBtwAttack;
	private GameObject player;
	float distance; 

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
	}

	private void Start()
	{
		maxHealth = Health;
	}

	public void Move(NavMeshAgent enemy)
	{
		float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
		if (distance >= 1.5)
		{
			enemy.enabled = true;
			enemy.destination = player.transform.position;
		}

		if (distance <= 1.5)
		{
			transform.LookAt(player.transform);
			enemy.enabled = false;
		}
	}

	public void Death(Transform tr, GameObject gold)
	{
		int t = Random.Range(1, 5);
		if (Health <= 0)
		{
			for (int i = 0; i < t; i++)
				Instantiate(gold, tr.transform.position, Quaternion.identity);

			Destroy(gameObject);
			Debug.Log("The enemy is dead " + this.name);
		}
	}

	public void Attack()
	{
		if (timeBtwAttack <= 0)
		{
			player.GetComponent<PlayerController>().TakeDamage(Damage);
			Debug.Log(this.Damage + this.attackSpeed);
			timeBtwAttack = attackSpeed;
		}
		else
		{
			timeBtwAttack -= Time.deltaTime;
		}

	}

	public void TakeDamage(float _damage)
	{
		Health -= _damage;
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			Attack();
		}
	}
}
