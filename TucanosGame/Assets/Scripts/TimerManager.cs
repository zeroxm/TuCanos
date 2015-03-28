using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour {

	float startTime;
	float currentTime;
	Text text;
	int minutes;
	int seconds;

	
	
	void Awake ()
	{
		startTime = Time.time;
		text = GetComponent <Text> ();
	}

	void Update ()
	{
			currentTime = Time.time - startTime;
			minutes = (int)currentTime/60;
			seconds = (int)currentTime%60;
			text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}

	public void restart(){
		startTime = Time.time;
	}

	public float getCurrentTime(){
		return currentTime;
	}

}
