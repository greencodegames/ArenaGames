using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
	Camera mainCamera;
	MaterialPropertyBlock matBlock;
	IEnemy enemy;
	MeshRenderer meshRenderer;
	// Start is called before the first frame update
	void Awake()
	{
		enemy = GetComponentInParent<IEnemy>();
		matBlock = new MaterialPropertyBlock();
		meshRenderer = GetComponent<MeshRenderer>();
	}

	void Start()
	{
		mainCamera = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
		if (enemy.Health < enemy.maxHealth)
		{
			meshRenderer.enabled = true;
			AlignCamera();
			UpdateParams();
		}
		else
			meshRenderer.enabled = false;
	}
	private void UpdateParams()
	{
		meshRenderer.GetPropertyBlock(matBlock);
		matBlock.SetFloat("_Fill", enemy.Health / (float)enemy.maxHealth);
		meshRenderer.SetPropertyBlock(matBlock);
	}
	private void AlignCamera()
	{
		if (mainCamera != null)
		{
			var camXform = mainCamera.transform;
			var forward = transform.position - camXform.position;
			forward.Normalize();
			var up = Vector3.Cross(forward, camXform.right);
			transform.rotation = Quaternion.LookRotation(forward, up);
		}
	}
}
