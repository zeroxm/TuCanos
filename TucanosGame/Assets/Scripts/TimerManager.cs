using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour {

	float startTime;
	float currentTime;
	Text text;
	int minutes;
	int seconds;
	bool stoped;
	
	
	void Awake ()
	{
		startTime = Time.time;
		stoped = false;
		text = GetComponent <Text> ();
	}

	void Update ()
	{
		if (stoped)
			return;
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

	public void stop(){
		stoped = true;
	}

}
