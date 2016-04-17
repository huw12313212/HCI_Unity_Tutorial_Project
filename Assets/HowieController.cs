using UnityEngine;
using System.Collections;

public class HowieController : MonoBehaviour 
{
	public Transform myTransform;
	public Rigidbody myRigibody;
	public float speed = 10;
	public float jumpSpeed = 10;

	public GameObject boomPrefab;

	public void Boom()
	{
		GameObject obj = GameObject.Instantiate (boomPrefab);
		obj.transform.position = myTransform.position;
	}

	bool onGround = false;

	void OnCollisionEnter(Collision collision) 
	{
		Boom ();
		onGround = true;
	}

	void OnCollisionExit(Collision collision) 
	{
		onGround = false;
	}


	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			myTransform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			myTransform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && onGround) 
		{
			myRigibody.velocity = new Vector3 (0, jumpSpeed, 0);
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			Debug.Log ("Mouse Clicked on:"+Input.mousePosition);
		}
	}

}
