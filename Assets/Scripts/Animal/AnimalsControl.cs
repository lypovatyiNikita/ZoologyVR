using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZoologyVR.UI;

namespace ZoologyVR.Animals
{
    public class AnimalsControl : MonoBehaviour
    {
        public Transform AnimalSpawnRef;
        public AnimalUI[] AllAnimals;

        private Animal _currentAnimal;

        public Animal GetCurrentAnimal
		{
			get
			{
                if (_currentAnimal == null)
                    return null;

                return _currentAnimal;
			}
		}

        public void ChangeCurrentAnimalAnimation(int index)
		{
            if (_currentAnimal == null)
                return;

            _currentAnimal.PlayOtherAnimation(index);
		}

        public void SpawnAnimal(Animal animalPref)
		{
            if (animalPref == null)
                return;

            if (_currentAnimal != null)
                Destroy(_currentAnimal.gameObject);

            _currentAnimal = Instantiate(animalPref, AnimalSpawnRef.position, AnimalSpawnRef.rotation, AnimalSpawnRef);
		}
    }
}