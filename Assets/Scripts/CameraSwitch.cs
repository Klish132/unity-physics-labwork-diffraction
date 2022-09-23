using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera = null;
    public Camera rulerCamera = null;

    private Vector3 lastMousePosition;

    public void SwitchToRulerCamera()
    {
        mainCamera.enabled = false;
        rulerCamera.enabled = true;
        GSC.isOnRuler = true;
    }

    public void SwitchToMainCamera()
    {
        rulerCamera.enabled = false;
        mainCamera.enabled = true;
        GSC.isOnRuler = false;
    }

    private void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        Vector3 delta = Input.mousePosition - lastMousePosition;
        if (delta == Vector3.zero && GSC.focusTarget == GSC.bench)
        {
            SwitchToRulerCamera();
            Debug.Log(GSC.isOnRuler);
        }
    }
}
