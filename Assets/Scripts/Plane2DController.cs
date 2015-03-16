using UnityEngine;
using System.Collections;

public class Plane2DController : MonoBehaviour {

	[SerializeField] DetectTouchMovement detect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update() {
		float pinchAmount = 0;
		
		detect.Calculate();
		
		if (Mathf.Abs(detect.pinchDistanceDelta) > 0) { // zoom
			pinchAmount = detect.pinchDistanceDelta;

			Debug.Log("PINCH " + pinchAmount);



			if (pinchAmount + transform.localScale.x > 0.4f){
			transform.localScale = new Vector3 (transform.localScale.x + pinchAmount,
			                                    transform.localScale.y + pinchAmount,
			                                    transform.localScale.z + pinchAmount);
			}

			transform.localScale = Vector3.ClampMagnitude(transform.localScale,2f);                   

		
		}

	}
			

}
