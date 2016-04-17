using UnityEngine;
using System.Collections;

public class KillSelf : MonoBehaviour {

	public float KillTime;

	private float Counter = 0;

	// Update is called once per frame
	void Update () {

		Counter += Time.deltaTime;

		if (Counter > KillTime) 
		{
			GameObject.Destroy (this.gameObject);
		}
	
	}
}
