using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Slideshow : MonoBehaviour
{
	public GameObject[] slides;
	public float changeTime = 10.0f;
	private int currentSlide = 0;
	private float timeSinceLast = 1.0f;

	void Start()
	{
		for (int i = 0; i < slides.Length; i++)
			slides[i].SetActive(false);

		slides[currentSlide].SetActive(true);

		currentSlide++;
	}
	
	void Update()
	{
		if(timeSinceLast > changeTime && currentSlide < slides.Length)
		{
			for (int i = 0; i < slides.Length; i++)
				slides[i].SetActive(false);
			
			slides[currentSlide].SetActive(true);

			Debug.Log("Slide Change");
			timeSinceLast = 0.0f;
			currentSlide++;
		}
		// comment out this section if you don't want the slide show to loop
		// -----------------------
		if(currentSlide == slides.Length)
		{
			currentSlide = 0;
		}
		// ------------------------
		timeSinceLast += Time.deltaTime;
	}
}