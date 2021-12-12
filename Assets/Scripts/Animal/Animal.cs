using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZoologyVR.Animals
{
	public class Animal : MonoBehaviour
	{
		public Animation AnimationRef;

		public void PlayOtherAnimation(AnimationClip clipRef)
		{
			AnimationRef.Play(clipRef.name);
		}
	}
}