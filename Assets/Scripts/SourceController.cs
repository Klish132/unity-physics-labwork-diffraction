using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceController : MonoBehaviour
{
    public Light pointerLight = null;
    public Light sourceLight = null;
    public GameObject onLamp = null;
    public GameObject offLamp = null;

    private bool prevSourceState = false;

    void Update()
    {
        if (prevSourceState != GSC.sourceIsOn)
        {
            if (GSC.sourceIsOn)
            {
                pointerLight.enabled = true;
                sourceLight.enabled = true;
                onLamp.SetActive(true);
                offLamp.SetActive(false);
            }
            else
            {
                pointerLight.enabled = false;
                sourceLight.enabled = false;
                onLamp.SetActive(false);
                offLamp.SetActive(true);
            }
            prevSourceState = GSC.sourceIsOn;
        }
    }
}
