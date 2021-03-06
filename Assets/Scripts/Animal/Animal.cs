using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZoologyVR.Animals
{
	public class Animal : MonoBehaviour
	{
		public string Description;
		public AnimalType Type;

		[Space(10)]
		public Animation AnimationRef;
		public AnimationClip[] ClipsRef;

		public void Awake()
		{
			if (AnimationRef == null)
				return;

			for (int i = 0; i < ClipsRef.Length; i++)
			{
				AnimationRef.AddClip(ClipsRef[i], ClipsRef[i].name);
			}
		}

		public void PlayOtherAnimation(int index)
		{
			if (index < 0 || index > ClipsRef.Length - 1)
				return;

			AnimationRef.Play(ClipsRef[index].name);
		}
	}

	public enum AnimalType
	{
		Fish = 0,
		Dinosaur = 1,
		African = 2,
		Bird = 3,
		MAX = 4
	}
}