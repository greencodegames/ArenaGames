using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider HealthSlider;
    public float Health;
	public float speedMove;

	private Vector3 moveVector;

	private CharacterController ch_controller;
	//private Animator ch_animator;
	private MobileController mController;
    void Start()
    {
		ch_controller = GetComponent<CharacterController>();
		//ch_animator = GetComponent<Animator>();
		mController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

	void Update()
	{
		CharacterMove();
		MouseView();
	}
	
	public void CharacterMove()
	{
		moveVector = Vector3.zero;
		moveVector.x = mController.Horizontal() * speedMove;
		moveVector.z = mController.Vertical() * speedMove;

		if(Vector3.Angle(Vector3.forward,moveVector)>1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
		{
			Vector3 dir = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
			transform.rotation = Quaternion.LookRotation(dir);
		}

		ch_controller.Move(moveVector * Time.deltaTime);
	}

    public void TakeDamage(float lDamage)
    {
        Health -= lDamage;
        HealthSlider.value -= lDamage;
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

}
