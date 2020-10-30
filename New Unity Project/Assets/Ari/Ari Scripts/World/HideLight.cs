using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class HideLight : MonoBehaviour
    {
        [SerializeField] private List<GameObject> lights = new List<GameObject>();
        private void Update()
        {
            if (GWorld.IsOurWorld())
            {
                foreach (var light in lights)
                    light.SetActive(false);
            }
            else
            {
                foreach (var light in lights)
                    light.SetActive(true);
            }
        }
    }
}