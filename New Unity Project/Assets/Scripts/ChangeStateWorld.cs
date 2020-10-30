using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Assets.Scripts
{
    public class ChangeStateWorld : MonoBehaviour
    {
        private LightColorController controller = null;
        [SerializeField] private GameObject explosion = null;
        [SerializeField] private GameObject ourExplosion = null;
        [SerializeField] private Transform pointCreate = null;
        private void Awake()
        {
            controller = GetComponent<LightColorController>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && controller != null)
            {
                if (!GWorld.IsOurWorld())
                {
                    Instantiate(explosion, pointCreate.position, Quaternion.identity);
                    StartCoroutine(ChangeToOther());
                }
                else
                {
                    Instantiate(ourExplosion, pointCreate.position, Quaternion.identity);
                    StartCoroutine(ChangeToOur());
                }
            }
        }

        IEnumerator ChangeToOther()
        {
            yield return new WaitForSeconds(6.0f);
            controller.SetTime(0.9f);
            GWorld.ChangeState();
        }

        IEnumerator ChangeToOur()
        {
            yield return new WaitForSeconds(6.0f);
            controller.SetTime(0);
            GWorld.ChangeState();
        }
    }
}
