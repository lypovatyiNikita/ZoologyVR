using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZoologyVR.Animals;

namespace ZoologyVR.UI
{
    public class AnimalUIView : MonoBehaviour
    {
        public Image IconRef;
        public TextMeshProUGUI TextRef;
		public Animal AnimalRef;

		private UIControl _UIControlRef;

		public void Init(Sprite newSprite, string newText, Animal animalRef, UIControl UIControlRef)
		{
			IconRef.sprite = newSprite;
			TextRef.text = newText;
			AnimalRef = animalRef;
			_UIControlRef = UIControlRef;
		}

		public void SpawnAnimal()
		{
			_UIControlRef.SpawnAnimal(AnimalRef);
		}
	}

	[System.Serializable]
	public struct AnimalUI
	{
		public Sprite Icon;
		public string Name;
		public Animal AnimalRef;
	}
}