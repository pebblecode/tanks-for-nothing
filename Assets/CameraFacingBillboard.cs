using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
	public Camera mainCamera;
	void Start()
	{
		mainCamera = Camera.main;
	}


	void FixedUpdate()
	{
		transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
			mainCamera.transform.rotation * Vector3.up);
	}
}