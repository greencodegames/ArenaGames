using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider HealthSlider;
    
	public float Health;
	public float speedMove;
	public float damage;
	public float attackSpeed;

	public float Strength;
	public float Agility;
	public float Intelligence;

	private float timeBtwAttack;
	public float attackRange;

	public Transform attackPos;
	public LayerMask whatIsEnemy;
	public Collider2D[] enemiesToDamage;
	public Text goldText;
	public int gold = 0;
	private Rigidbody _rb;

	public Slider slider;

	private Vector3 moveVector;

	private CharacterController ch_controller;
	private Animator ch_animator;

	public List<Item> itemList;
    void Start()
    {
		timeBtwAttack = attackSpeed;
		ch_controller = GetComponent<CharacterController>();
		ch_animator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody>();
		goldText.text = "Gold: " + gold;
		slider.value = slider.maxValue = Health;
    }

	void Update()
	{
		Attack();
		CharacterMove();
		MouseView();
	}
	
	public void CharacterMove()
	{

		if (Input.GetKeyDown(KeyCode.F))
		{
			Debug.Log("1123");
			moveVector = Vector3.zero;
			ch_animator.SetBool("isRifting", true);
		}
		ch_animator.SetBool("isRifting", false);

			moveVector = Vector3.zero;
			moveVector.x = Input.GetAxis("Horizontal") * speedMove;
			moveVector.z = Input.GetAxis("Vertical") * speedMove;

			if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
			{
				//ch_animator.SetBool("isRunning", true);
				Vector3 dir = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
				transform.rotation = Quaternion.LookRotation(dir);
			}
		
			ch_controller.Move(moveVector * Time.deltaTime);

			//if(moveVector.magnitude == 0)
				//ch_animator.SetBool("isRunning", false);
	}

	public void TakeDamage(float lDamage)
	{
		Health -= lDamage;
		slider.value -= lDamage;

		if (Health <= 0f)
		{
			GameObject[] listOfEnemy = GameObject.FindGameObjectsWithTag("Enemy");

			Destroy(gameObject);
		}
    }

	public void MouseView()
	{
		Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		Vector3 moveVelocity = moveInput * speedMove;

		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;

		if(groundPlane.Raycast(cameraRay, out rayLength))
		{
			Vector3 pointToLook = cameraRay.GetPoint(rayLength);
			Debug.DrawRay(transform.position,pointToLook,Color.blue);
			transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}
	}

	public void Attack()
	{
		
		if(timeBtwAttack <= 0)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				Debug.Log(timeBtwAttack + "Attack");
				enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRange, attackRange), 0, whatIsEnemy);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					Debug.Log("Enemies to Damage: " + enemiesToDamage[i].transform.parent.name);
					enemiesToDamage[i].GetComponentInParent<IEnemy>().TakeDamage(damage);
				}
				timeBtwAttack = attackSpeed;
			}
		}
		else
		{
			timeBtwAttack -= Time.deltaTime;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRange,attackRange,1));
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Gold")
		{
			Destroy(other.gameObject);
			gold++;
			goldText.text = "Gold: " + gold;
		}
	}

}
