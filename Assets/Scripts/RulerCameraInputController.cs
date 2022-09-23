using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerCameraInputController : MonoBehaviour
{
    public GameObject rulerCameraSlide = null;

    public float minPosition = 0;
    public float maxPosition = 100f;

    private Vector3 mouseHeldPosition;

    private void Update()
    {
        if (GSC.isOnRuler && Input.GetMouseButton(1))
        {
            float offset = 0.5f * -Input.GetAxis("Mouse X");
            if (rulerCameraSlide.transform.localPosition.y + offset <= 100f && rulerCameraSlide.transform.localPosition.y + offset >= 0f)
            {
                rulerCameraSlide.transform.localPosition += new Vector3(0, offset, 0);
            }
        }
    }
}
