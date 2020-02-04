using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour
{
	public float Health { get; set; }
	public float Speed { get; set; }
	public float Damage { get; set; }
	public float attackSpeed { get; set; }
	private float timeBtwAttack;

	protected void Awake(float _Health, float _Speed, float _Damage, float _attackSpeed)
	{
		Health = _Health;
		Speed = _Speed;
		Damage = _Damage;
		attackSpeed = _attackSpeed;
	}
	public void Move(GameObject player)
	{
		if (player)
		{
			var Vector = player.transform.position - transform.position;
			if (Vector.magnitude > 1.0f)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector), 1);
				transform.position += transform.forward * Speed * Time.fixedDeltaTime;
			}
		}
		else
		{

		}
	}

	public void Death()
	{
		if (Health <= 0)
		{
			Destroy(gameObject);
			Debug.Log("The enemy is dead " + this.name);
		}
	}

	public void Attack(GameObject player)
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
}
