using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultimeterCursor : MonoBehaviour
{
    //private Vector3 mouseHeldPosition;

    private float mouseReleasedAngle = 0f;
    private float currentAngle = 0f;
    private float mouseHeldAngle;

    public int stateCount = 20;

    private float oneStateAngleValue = 0f;

    // 0 - 19
    private int state = 0;

    void Start()
    {
        oneStateAngleValue = 360 / stateCount;
    }

    private float GetCurrentMouseAngle()
    {
        Vector2 center = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 mouse_pos = Input.mousePosition;
        Vector2 rel = mouse_pos - center;
        float angle = Mathf.Atan2(rel.x, rel.y) * Mathf.Rad2Deg;
        if (angle < 0)
            angle += 360;

        return angle;
    }

    private void OnMouseDown()
    {
        if (GSC.focusTarget == GSC.multimeterBody)
        {
            float currentMouseAngle = GetCurrentMouseAngle();
            mouseHeldAngle = currentMouseAngle;
        }   
    }

    private void OnMouseDrag()
    {
        if (GSC.focusTarget == GSC.multimeterBody)
        {
            float currentMouseAngle = GetCurrentMouseAngle();

            float angleDifference = currentMouseAngle - mouseHeldAngle;
            float newAngle = mouseReleasedAngle + angleDifference;
            if (newAngle > 360)
                newAngle -= 360;
            else if (newAngle < -360)
                newAngle += 360;
            if (newAngle < 0)
                newAngle += 360;

            int angleToState = (int)System.Math.Truncate(newAngle / oneStateAngleValue);
            if (angleToState == stateCount)
                angleToState = 0;

            GSC.multimeterState = state = angleToState;
            currentAngle = oneStateAngleValue * angleToState;

            transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
        }
    }

    private void OnMouseUp()
    {
        if (GSC.focusTarget == GSC.multimeterBody)
            mouseReleasedAngle = currentAngle;
    }

    //private void ChangeState(int stateChange)
    //{
    //    if (stateChange < 0 && state == 0)
    //        GSC.multimeterState = state = 19;
    //    else if (stateChange > 0 && state == 19)
    //        GSC.multimeterState = state = 0;
    //    else
    //        GSC.multimeterState = state += stateChange;
    //    transform.localRotation *= Quaternion.Euler(0, 0, 18 * stateChange);
    //}

    //private void OnMouseDown()
    //{
    //    if (GSC.focusTarget == GSC.multimeterBody)
    //    {
    //        mouseHeldPosition = Input.mousePosition;
    //        GSC.preventRotation = true;
    //    }
    //}

    //private void OnMouseDrag()
    //{
    //    if (GSC.focusTarget == GSC.multimeterBody)
    //    {
    //        if (mouseHeldPosition.x - Input.mousePosition.x > stateChangeDistance)
    //        {
    //            //moved by 1 pos right
    //            mouseHeldPosition = Input.mousePosition;
    //            ChangeState(-1);
    //        }
    //        else if ((mouseHeldPosition.x - Input.mousePosition.x < -stateChangeDistance))
    //        {
    //            //moved by 1 pos left
    //            mouseHeldPosition = Input.mousePosition;
    //            ChangeState(1);
    //        }
    //    }
    //}

    //private void OnMouseUp()
    //{
    //    GSC.preventRotation = false;
    //}
}
