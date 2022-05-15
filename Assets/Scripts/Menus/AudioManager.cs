using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public Slider slider;
	[Range(0.0f, 1.0f)]
	[SerializeField]
	public float masterVolume;
	public float defaultVolume;

	void Start()
	{
		defaultVolume = 1f;
		masterVolume = 1f;
		slider.value = masterVolume;
	}
	void Update()
	{
		AudioListener.volume = slider.value;
	}
}
