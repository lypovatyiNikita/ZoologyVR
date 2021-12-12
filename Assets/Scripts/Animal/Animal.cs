using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZoologyVR.Animals
{
	public class Animal : MonoBehaviour
	{
		public Animation AnimationRef;
		public AnimationClip[] ClipsRef;

		public void PlayOtherAnimation(int index)
		{
			if (index < 0 || index > ClipsRef.Length - 1)
				return;

			AnimationRef.clip = ClipsRef[index];
			AnimationRef.Play();
		}
	}
}