using UnityEngine;
using System.Collections;

public class CubeControl : MonoBehaviour 
{
	Transform myTransform;
	float speed = 10;

	void Start () 
	{
		myTransform = this.GetComponent<Transform> ();
		//Debug.Log ("Hello Start");
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

		if (Input.GetMouseButtonDown (0)) 
		{
			Debug.Log ("Mouse Clicked on:"+Input.mousePosition);
		}
	}


}
