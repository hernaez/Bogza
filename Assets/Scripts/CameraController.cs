using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {
		float pinchAmount = 0;
		Quaternion desiredRotation = transform.rotation;
		
		DetectTouchMovement.Calculate();
		
		if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0) { // zoom
			pinchAmount = DetectTouchMovement.pinchDistanceDelta;

			Debug.Log("PINCH " + pinchAmount);
		
		}
		
		if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0) { // rotate
			Vector3 rotationDeg = Vector3.zero;
			rotationDeg.y = -DetectTouchMovement.turnAngleDelta;
			desiredRotation *= Quaternion.Euler(rotationDeg);
		}

		if (Mathf.Abs(DetectTouchMovement.slantAngleDelta) > 0) { // slant
			Vector3 rotationDeg = Vector3.zero;
			rotationDeg.x = -DetectTouchMovement.slantAngleDelta;
			desiredRotation *= Quaternion.Euler(rotationDeg);
		}


		transform.rotation = desiredRotation;
		transform.position += Vector3.forward * pinchAmount;                   


		transform.localPosition = new Vector3(transform.localPosition.x,
			                                  Mathf.Clamp(transform.localPosition.y ,-10f,16f),
		                                      transform.localPosition.z);


	}
		




}
