using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

	[SerializeField] GameObject slantPlane;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update() {
		float pinchAmount = 0;
		Quaternion desiredRotation = transform.rotation;
		Quaternion desiredSlantRotation = slantPlane.transform.rotation;
		
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
			Vector3 rotationSlant = Vector3.zero;
			rotationSlant.x = -DetectTouchMovement.slantAngleDelta;
			desiredSlantRotation *= Quaternion.Euler(rotationSlant);
		}



		transform.rotation = desiredRotation;
		transform.position += Vector3.forward * pinchAmount;                   


		transform.localPosition = new Vector3(transform.localPosition.x,
			                                  Mathf.Clamp(transform.localPosition.y ,-10f,16f),
		                                      transform.localPosition.z);


		slantPlane.transform.rotation = desiredSlantRotation;

		Vector3 rot = slantPlane.transform.localRotation.eulerAngles;
		if (rot.x < 45)
			rot.x = 45;
		if (rot.x > 75)
			rot.x = 75;
		rot.z = 0;
		slantPlane.transform.localRotation = Quaternion.Euler(rot);
	}
		




}
