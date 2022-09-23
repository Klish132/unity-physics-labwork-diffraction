using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LCDController : MonoBehaviour
{
    public Text multimeterText = null;

    private string nullText;
    private string meshText;

    private bool isInitialized = false;
    private string prevText;
    private int prevAngle = -1;

    void Update()
    {
        if (!isInitialized)
        {
            isInitialized = true;
            nullText = GSC.i0.ToString();
            meshText = (GSC.i0 * 0.1d).ToString("0.00");
        }

        if (GSC.multimeterState == 7)
        {
            multimeterText.enabled = true;
            if (GSC.sourceIsOn)
            {
                if (GSC.benchHolder.heldObject == null && prevText != nullText)
                {
                    multimeterText.text = prevText = nullText;
                    prevAngle = -1;
                }
                else if (GSC.benchHolder.heldObject == GSC.mesh && prevText != meshText)
                {
                    multimeterText.text = prevText = meshText;
                    prevAngle = -1;
                }
                else if (GSC.benchHolder.heldObject == GSC.polaroid && (prevAngle != GSC.polaroidAngle || prevText == "0.00"))
                {
                    double angle = GSC.polaroidAngle;
                    //if (GSC.polaroidAngle < 0)
                    //    angle += 360;
                    angle = angle * System.Math.PI / 180d;
                    double i = System.Math.Round(0.9d * GSC.i0 * System.Math.Cos(angle) * System.Math.Cos(angle), 2);
                    multimeterText.text = prevText = i.ToString("0.00");
                    prevAngle = GSC.polaroidAngle;
                }
            } else
            {
                multimeterText.text = prevText = "0.00";
            }
            
        }
        else
        {
            multimeterText.enabled = false;
            
        }
    }
}
