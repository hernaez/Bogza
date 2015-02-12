using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	List<GameObject> screenList;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnMenuButtonPressed(string menu)
	{

		foreach ( GameObject screen in screenList)
		{
			if (screen.name != menu)
				screen.SetActive(false);
			else
				screen.SetActive(true);
		}


	}
}
