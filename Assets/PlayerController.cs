using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public Transform Camera;
	public Transform PlayerBody;
	public Rigidbody RigidBody;
	public float MouseMovementSpeedX;
	public float MouseMovementSpeedY;
	public float RotateY = 0;
	public float RotateX = 0;
	public float MoveSpeed = 2;

	public GameObject FireBullet;
	public float bulletSpeed;


	void Fire()
	{
		GameObject fireBall = GameObject.Instantiate <GameObject>(FireBullet);

		fireBall.transform.position = Camera.transform.position;
		Rigidbody rigidbody =fireBall.GetComponent<Rigidbody> ();

		rigidbody.velocity = Camera.forward * bulletSpeed;
	}

	void CheckMouseMovement ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Fire ();
		}


		RotateY += Input.GetAxis ("Mouse X") * MouseMovementSpeedX;
		RotateX += -Input.GetAxis ("Mouse Y") * MouseMovementSpeedY;

		if (RotateX < -90)
			RotateX = -90;
		else if (RotateX > 90)
			RotateX = 90;
		
		PlayerBody.transform.localEulerAngles = new Vector3 (0, RotateY, 0);
		Camera.transform.localEulerAngles = new Vector3 (RotateX, 0, 0);
	}

	void CheckKeyboard ()
	{
		if (Input.GetKey (KeyCode.W)) {
			RigidBody.velocity += PlayerBody.forward;
		}
		if (Input.GetKey (KeyCode.S)) {
			RigidBody.velocity += -PlayerBody.forward;
		}
		if (Input.GetKey (KeyCode.D)) {
			RigidBody.velocity += PlayerBody.right;
		}
		if (Input.GetKey (KeyCode.A)) {
			RigidBody.velocity += -PlayerBody.right;
		}
		if (RigidBody.velocity.magnitude > MoveSpeed) {
			RigidBody.velocity = RigidBody.velocity.normalized * MoveSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckMouseMovement ();
		CheckKeyboard ();
	}
}
