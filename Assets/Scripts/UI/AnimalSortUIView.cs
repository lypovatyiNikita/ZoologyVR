using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ZoologyVR.Animals;

namespace ZoologyVR.UI 
{
    public class AnimalSortUIView : MonoBehaviour
    {
		public TextMeshProUGUI TextRef;
		public UIControl UIControlRef;

		private AnimalType _sortTypeRef;

		public void Init(AnimalType type, UIControl givedUIControl)
		{
			_sortTypeRef = type;
			TextRef.text = _sortTypeRef.ToString();
			UIControlRef = givedUIControl;
		}

		public void SortByType()
		{
			List<AnimalUIView> allAnimalButtons = UIControlRef.GetAllAnimalButtons;
			for (int i = 0; i < allAnimalButtons.Count; i++)
			{
				if (allAnimalButtons[i].AnimalRef.Type != _sortTypeRef)
					allAnimalButtons[i].gameObject.SetActive(false);
				else
					allAnimalButtons[i].gameObject.SetActive(true);
			}
		}

		public void ResetSort()
		{
			List<AnimalUIView> allAnimalButtons = UIControlRef.GetAllAnimalButtons;
			for (int i = 0; i < allAnimalButtons.Count; i++)
			{
				allAnimalButtons[i].gameObject.SetActive(true);
			}
		}
	}
}