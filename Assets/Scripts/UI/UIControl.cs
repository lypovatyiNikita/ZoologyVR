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

		public Transform AnimalsSortButtonsContent;
		public AnimalSortUIView AnimalSortButtonPref;

		public Transform AnimationsPool;
		public AnimalAnimationUI AnimationUIPref;

		public TextMeshProUGUI DescriptionRef;

		private List<AnimalUIView> _allAnimalButtonsRef;
		private List<AnimalAnimationUI> _allAnimalAnimationsRef;

		public List<AnimalUIView> GetAllAnimalButtons
		{
			get
			{
				if (_allAnimalButtonsRef == null)
				{
					return null;
				}
				return _allAnimalButtonsRef;
			}
		}

		private void Start()
		{
			InitSpawnButtons();
			InitSortButtons();
		}

		private void InitSpawnButtons()
		{
			_allAnimalButtonsRef = new List<AnimalUIView>();
			for (int i = 0; i < AnimalsRef.AllAnimals.Length; i++)
			{
				AnimalUIView newButton = Instantiate(AnimalUIViewPref, AnimalsButtonsContent);
				newButton.Init(AnimalsRef.AllAnimals[i].Icon, AnimalsRef.AllAnimals[i].Name, AnimalsRef.AllAnimals[i].AnimalRef, this);
				_allAnimalButtonsRef.Add(newButton);
			}
		}

		private void InitSortButtons()
		{
			for (int i = 0; i < (int)AnimalType.MAX; i++)
			{
				AnimalSortUIView newButton = Instantiate(AnimalSortButtonPref, AnimalsSortButtonsContent);
				newButton.Init((AnimalType)i, this);
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

			DescriptionRef.text = AnimalsRef.GetCurrentAnimal.Description;
		}
	}
}