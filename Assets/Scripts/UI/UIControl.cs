using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZoologyVR.Animals;

namespace ZoologyVR.UI
{
    public class UIControl : MonoBehaviour
    {
        public AnimalsControl AnimalsRef;

        public Transform AnimalsButtonsContent;
		public AnimalUIView AnimalUIViewPref;

		public Transform AnimationsPool;
		public AnimalAnimationUI AnimationUIPref;

		public TextMeshProUGUI DescrptionRef;

		private List<AnimalUIView> _allAnimalButtonsRef;
		private List<AnimalAnimationUI> _allAnimalAnimationsRef;

		private void Start()
		{
			_allAnimalButtonsRef = new List<AnimalUIView>();
			for (int i = 0; i < AnimalsRef.AllAnimals.Length; i++)
			{
				AnimalUIView newButton = Instantiate(AnimalUIViewPref, AnimalsButtonsContent);
				newButton.Init(AnimalsRef.AllAnimals[i].Icon, AnimalsRef.AllAnimals[i].Name, AnimalsRef.AllAnimals[i].AnimalRef, this);
				_allAnimalButtonsRef.Add(newButton);
			}
		}

		public void SpawnAnimal(Animal newAnimalPref)
		{
			AnimalsRef.SpawnAnimal(newAnimalPref);

			if (_allAnimalAnimationsRef != null)
				for (int i = 0; i < _allAnimalAnimationsRef.Count; i++)
				{
					Destroy(_allAnimalAnimationsRef[i].gameObject);
				}

			_allAnimalAnimationsRef = new List<AnimalAnimationUI>();
			for (int i = 0; i < newAnimalPref.ClipsRef.Length; i++)
			{
				AnimalAnimationUI newAnimationUI = Instantiate(AnimationUIPref, AnimationsPool);
				newAnimationUI.Init(i, AnimalsRef.GetCurrentAnimal.ClipsRef[i].name, AnimalsRef.GetCurrentAnimal);
				_allAnimalAnimationsRef.Add(newAnimationUI);
			}

			DescrptionRef.text = AnimalsRef.GetCurrentAnimal.Description;
		}
	}
}