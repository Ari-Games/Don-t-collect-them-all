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
                    controller.SetTime(0.9f);
                    GWorld.ChangeState();
                }
                else
                {
                    controller.SetTime(0);
                    GWorld.ChangeState();
                }
            }
        }
    }
}
