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
        [SerializeField] private GameObject endPanel = null;
        [SerializeField] private AudioClip gotoOur;
        [SerializeField] private AudioClip gotoOther;


        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                endPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }

        public void Continue()
        {
            endPanel.SetActive(false);
            Time.timeScale = 1;
        }
        public void Change()
        {
            if (!GWorld.IsOurWorld())
            {
                GetComponent<AudioSource>().PlayOneShot(gotoOther);
                Instantiate(explosion, pointCreate.position, Quaternion.identity);
                StartCoroutine(ChangeToOther());
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(gotoOur);
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
