using System;
using UnityEngine;

public class Clock: MonoBehaviour {
	const float degreesPerHour = 30f;
	const float degreesPerMinute = 6f;
	const float degreesPerSecond = 6f;

	public Transform hoursTransform; 
	public Transform minutesTransform; 
	public Transform secondsTransform; 

	public bool continuous;
//	public Transform hoursTransform, minutesTransform, secondsTransform;
//	Also ok

	void Update() {
		if (continuous) {
			UpdateContinuous ();
		} else {
			UpdateDiscrete ();
		}
	}

	void UpdateDiscrete() {
//		Debug.Log (DateTime.Now.Hour);
		DateTime time = DateTime.Now;

//		Multiplied by 30f b/c of the degrees of rotation between the hours
		hoursTransform.localRotation = Quaternion.Euler (0f, time.Hour * degreesPerHour, 0f);

		minutesTransform.localRotation = Quaternion.Euler (0f, time.Minute * degreesPerMinute, 0f);

		secondsTransform.localRotation = Quaternion.Euler (0f, time.Second * degreesPerSecond, 0f);
	}

	void UpdateContinuous() {
		TimeSpan time = DateTime.Now.TimeOfDay;

		hoursTransform.localRotation = Quaternion.Euler (0f, (float)time.TotalHours * degreesPerHour, 0f);

		minutesTransform.localRotation = Quaternion.Euler (0f, (float)time.TotalMinutes * degreesPerMinute, 0f);

		secondsTransform.localRotation = Quaternion.Euler (0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
	}
}