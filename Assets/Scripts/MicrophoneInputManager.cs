using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInputManager : MonoBehaviour
{
	AudioSource recording;

	private void Start()
	{
		foreach (var device in Microphone.devices)
		{
			Debug.Log("device: " + device);
		}
	}

	private void Update()
	{
		
	}
}
