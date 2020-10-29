using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeStateWorld : MonoBehaviour
{
    [SerializeField] private GameObject globalLight;
    public bool isOurWorld = true;
    public List<GameObject> Trees;

    private void Start()
    {
    }

    private void Change()
    {
        foreach (var tree in Trees)
        {
            SpriteRenderer[] comps = tree.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer comp in comps)
                comp.enabled = isOurWorld;
            tree.GetComponent<SpriteRenderer>().enabled = true;
        }
            
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            if (isOurWorld)
            {
                isOurWorld = false;
                globalLight.GetComponent<LightColorController>().SetTime(0.9f);
            }
            else
            {
                isOurWorld = true;
                globalLight.GetComponent<LightColorController>().SetTime(0);
            }
            Change();
        }
    }
}
