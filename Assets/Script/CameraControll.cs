using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
	public GameObject TargetPlayer;
	private Vector3 offset;

	void Start()
	{
		offset = transform.position - TargetPlayer.transform.position;
	}

	private void LateUpdate()
	{
		transform.position = TargetPlayer.transform.position + offset;
	}
}
