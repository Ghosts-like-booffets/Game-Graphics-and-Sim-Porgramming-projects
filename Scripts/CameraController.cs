using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform lookAt; //What to look at
	public Transform mainCamera; //main camera

	[Range(0,30)]
	public float distanceFromPlayer = 10.0f;  //camera distance from player as slider

	public float camX = 0.0f;  //X position of camera
	public float camY = 30.0f; //Y position of camera

	public float minY = 1;	//minimum y position of camera
	public float maxY = 80; //maximum y position of camera

	public float camSensitivity = 100; //Camera sensitivity multiplier
									   //used so large camera values aren't needed

	//Speed Multipliers for camera X and Y movement//
	[Range(0, 10)]
	public float xSpeed = 2.0f;

	[Range(0, 10)]
	public float ySpeed = 5.0f;



	// Start is called before the first frame update
	void Start()
    {
		//Set the lookAt object to the player and find the main camera and gets the transform
		lookAt = GameObject.FindGameObjectWithTag("Player").transform;
		mainCamera = Camera.main.transform; 

		//set the mouse curso to invisible and lock it in the window
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		//clamp the speed value between 1 and 10
		ySpeed = Mathf.Clamp(ySpeed, 1, 10);
		xSpeed = Mathf.Clamp(xSpeed, 1, 10);

		//grab mouse input and multiply it by Speed * sensitivity * time
		camY += Input.GetAxis("Mouse Y") * ySpeed * camSensitivity * Time.deltaTime;
		camX += Input.GetAxis("Mouse X") * xSpeed * camSensitivity * Time.deltaTime;

		camY = Mathf.Clamp(camY, minY, maxY);
	}

	private void LateUpdate()
	{
		//Put distance into vector3
		Vector3 dir = new Vector3(0, 0, -distanceFromPlayer);

		//put x and y values into camera
		Quaternion rotation = Quaternion.Euler(camY, camX, 0);

		mainCamera.position = lookAt.position + rotation * dir;
		mainCamera.transform.LookAt(lookAt);
	}
}
