using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Assets.Scripts
{
    public class ChangeStateWorld : MonoBehaviour
    {
        [SerializeField] private LightColorController controller = null;
        [SerializeField] private GameObject explosion = null;
        [SerializeField] private GameObject ourExplosion = null;
        [SerializeField] private Transform pointCreate = null;
        [SerializeField] private GameObject battlePanel = null;
        [SerializeField] private PlayerController player= null;

        public void Change()
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

        IEnumerator ChangeToOther()
        {
            player.enabled = false;   
            yield return new WaitForSeconds(6.0f);
            controller.SetTime(0.9f);
            GWorld.ChangeState();
            battlePanel.SetActive(true);
            player.enabled = true;
        }

        IEnumerator ChangeToOur()
        {
            player.enabled = false;
            yield return new WaitForSeconds(6.0f);
            controller.SetTime(0);
            GWorld.ChangeState();
            battlePanel.SetActive(false);
            player.enabled = true;
        }
    }
}
