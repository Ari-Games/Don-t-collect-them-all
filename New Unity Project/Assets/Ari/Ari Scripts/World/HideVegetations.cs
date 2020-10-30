using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class HideVegetations : MonoBehaviour
    {

        private SpriteRenderer[] vegetations = null;
        private void Start()
        {
            vegetations = GetComponentsInChildren<SpriteRenderer>();
        }
        private void Update()
        {
            if (GWorld.IsOurWorld())
                ChangeToOurWorld();
            else
                ChangeToOtherWorld();

        }

        private void ChangeToOurWorld()
        {
            foreach (var vegetation in vegetations)
                vegetation.enabled = false;
            GetComponent<SpriteRenderer>().enabled = true;
        }

        private void ChangeToOtherWorld()
        {
            foreach (var vegetation in vegetations)
                vegetation.enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;

        }
    }
}