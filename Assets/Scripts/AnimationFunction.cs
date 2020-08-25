using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFunction : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	public bool disableOnce;

	public  void   PlaySound(AudioClip whichSound)
	{
		if (!disableOnce)
		{
			menuButtonController.audioSource.PlayOneShot(whichSound);
		}
		else
		{
			disableOnce = false;
		}
	}
}
