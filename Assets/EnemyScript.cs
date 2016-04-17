using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Animator myAnimator;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains ("Bullet")) 
		{
			Debug.Log ("Got hit");

			myAnimator.SetBool ("Hit", true);
		}
	}
}
