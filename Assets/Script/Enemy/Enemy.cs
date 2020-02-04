using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private EnemyData data;
	[SerializeField] private GameObject player;


	public int[,] text;

	[SerializeField] public List<List<int>> counter;
    public void Init(EnemyData ldata)
    {
        data = ldata;
        GetComponent<MeshFilter>().mesh = data.MainMesh;
        GetComponent<MeshRenderer>().material = data.MaterialE;
        //GetComponent<Animator>().runtimeAnimatorController = data.AnimatorE;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public float Attack //Атака текущего врага
    {
        get { return data.Damage; }
        protected set { }
    }

    public float Speed //Скорость текущего врага
    {
        get { return data.Speed; }
        protected set { }
    }

    public string Name //Имя текущего врага
    {
        get { return data.Name; }
        protected set { }
    }

    public float Health //Здоровье текущего врага
    {
        get { return data.Health; }
        protected set { }
    }

    public static Action<GameObject> OnEnemyDie;

    private void FixedUpdate()
    {
        MoveEnemy();
        EnemyDie();
    }

    private void EnemyDie()
    {
        if(Health <= 0)
        {
            OnEnemyDie(gameObject);
        }
    }

	private void MoveEnemy()
	{
		var Vector = player.transform.position - transform.position;
		if (Vector.magnitude > 1.0f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector), 1);
			transform.position += transform.forward * Speed * Time.fixedDeltaTime;
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			MakeDamage();
		}
	}

	private void MakeDamage()
	{
		//Debug.Log("Получен урон! " + Attack + "\nОт " + gameObject.name);
	}

}
