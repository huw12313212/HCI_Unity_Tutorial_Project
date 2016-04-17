using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class PlaneController : MonoBehaviour {

	public TapGesture planeTapListener;
	public HowieController howie;
	public TransformGesture transformListener;

	// Use this for initialization
	void Start () 
	{
		transformListener.Transformed += (object sender, System.EventArgs e) => 
		{
			Vector3 posDelta = transformListener.LocalDeltaPosition;
			posDelta.z = 0;

			this.transform.position += posDelta;
			this.transform.localScale *= transformListener.DeltaScale;
		 	this.transform.eulerAngles += new Vector3(0,-transformListener.DeltaRotation,0);
		};


		planeTapListener.Tapped += (object sender, System.EventArgs e) => 
		{
			TouchScript.Hit.TouchHit hitResult =  new TouchScript.Hit.TouchHit();
			planeTapListener.GetTargetHitResult(planeTapListener.ScreenPosition,out hitResult);
			howie.MoveTo(hitResult.Point.x,hitResult.Point.z);
		};
	}

}
