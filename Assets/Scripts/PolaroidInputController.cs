using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidInputController : MonoBehaviour
{
    public GameObject rotator = null;

    public int rotationAngle = 5;

    public int minValue = 0;
    public int maxValue = 0;

    private int currAngle = 0;

    // Update is called once per frame
    void Update()
    {
        if (GSC.focusTarget == GSC.polaroidFrame)
        {
            /*
            if (Input.GetKeyDown("left"))
            {
                if (currAngle - rotationAngle >= -360)
                {
                    currAngle += -rotationAngle;
                    rotator.transform.localRotation *= Quaternion.Euler(0, rotationAngle, 0);
                    GSC.polaroidAngle = currAngle;
                }
            }
            else if (Input.GetKeyDown("right"))
            {
                if (currAngle + rotationAngle <= 360)
                {
                    currAngle += rotationAngle;
                    rotator.transform.localRotation *= Quaternion.Euler(0, -rotationAngle, 0);
                    GSC.polaroidAngle = currAngle;
                }
            }
            */
            if (Input.GetKeyDown("left"))
            {
                currAngle = (currAngle - rotationAngle) % 360;
                if (currAngle < 0)
                    currAngle += 360;
                rotator.transform.localRotation *= Quaternion.Euler(0, rotationAngle, 0);
                GSC.polaroidAngle = currAngle;
            }
            else if (Input.GetKeyDown("right"))
            {
                
                currAngle = (currAngle + rotationAngle) % 360;
                if (currAngle < 0)
                    currAngle += 360;
                rotator.transform.localRotation *= Quaternion.Euler(0, -rotationAngle, 0);
                GSC.polaroidAngle = currAngle;
            }
        }
    }
}
