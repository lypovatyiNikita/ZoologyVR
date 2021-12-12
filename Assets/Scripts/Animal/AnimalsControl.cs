using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZoologyVR.Animals
{
    public class AnimalsControl : MonoBehaviour
    {
        public Transform AnimalSpawnRef;

        private Animal _currentAnimal;

        public void ChangeCurrentAnimalAnimation(AnimationClip animationClipRef)
		{
            if (_currentAnimal == null)
                return;

            _currentAnimal.PlayOtherAnimation(animationClipRef);
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