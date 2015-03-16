using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

	[SerializeField] DetectTouchMovement detect;
	[SerializeField] GameObject secondPlane;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update() {
		float pinchAmount = 0;
		Quaternion desiredRotation = transform.rotation;
		Quaternion desiredSecondRotation = secondPlane.transform.rotation;
		
		detect.Calculate();
		
		if (Mathf.Abs(detect.pinchDistanceDelta) > 0) { // zoom
			pinchAmount = detect.pinchDistanceDelta;

			Debug.Log("PINCH " + pinchAmount);
			transform.position += Vector3.forward * pinchAmount;                   
			
			
			transform.localPosition = new Vector3(transform.localPosition.x,
			                                      Mathf.Clamp(transform.localPosition.y ,-10f,16f),
			                                      transform.localPosition.z);
		
		}
		else if (Mathf.Abs(detect.turnAngleDelta) > 0) { 
				Vector3 rotationDeg = Vector3.zero;
				rotationDeg.y = -detect.turnAngleDelta;
				desiredSecondRotation *= Quaternion.Euler(rotationDeg);

				secondPlane.transform.rotation = desiredSecondRotation;

		} else if (Mathf.Abs(detect.slantAngleDelta) > 0) { // slant
				Vector3 rotationSlant = Vector3.zero;
				rotationSlant.x = -detect.slantAngleDelta;
				desiredRotation *= Quaternion.Euler(rotationSlant);
				transform.rotation = desiredRotation;


				Vector3 rot = transform.localRotation.eulerAngles;
				if (rot.x < 45)
					rot.x = 45;
				if (rot.x > 75)
					rot.x = 75;
				rot.z = 0;
				rot.y = 0;

				transform.localRotation = Quaternion.Euler(rot);

			}

	}
			

}
