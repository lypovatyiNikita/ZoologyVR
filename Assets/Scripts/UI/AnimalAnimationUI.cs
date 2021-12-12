using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ZoologyVR.Animals;

namespace ZoologyVR.UI
{
	public class AnimalAnimationUI : MonoBehaviour
	{
		public int AnimationID;
		public TextMeshProUGUI TextRef;
		public Animal AnimalRef;

		public void Init(int ID, string name, Animal animalRef)
		{
			AnimationID = ID;
			if (TextRef != null)
				TextRef.text = name;
			AnimalRef = animalRef;
		}

		public void ChangeAnimation()
		{
			if (AnimalRef == null)
				return;

			AnimalRef.PlayOtherAnimation(AnimationID);
		}
	}
}