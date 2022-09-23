using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLaserObject : LaserObject
{
    public int m = 0;

    private float prevMeshPosition = -1;
    private int prevPolaroidAngle = -1;

    private double locationalConst = 0;

    private bool isInitialized = false;

    private void ChangeStateToMesh(int pos)
    {
        float x = (float)(pos * locationalConst);

        if (x > 8 || x < -8)
            SetAlpha(0f);
        else
        {
            double perc = (100 - (System.Math.Abs(System.Math.Round(x, 2)) / 1d * 10d)) / 100d;
            SetAlpha((float)perc);
        }

        gameObject.transform.localPosition = new Vector3(x, 0, 0);
        prevMeshPosition = pos;
    }

    private void ChangeStateToPolaroid(int angle)
    {
        double perc2 = (100 - (System.Math.Abs(angle / 9d * 10d))) / 100d;
        double perc = System.Math.Abs(System.Math.Cos(angle * System.Math.PI / 180));
        SetAlpha((float)perc);
        prevPolaroidAngle = angle;
    }

    void Update()
    {
        if (!isInitialized)
        {
            isInitialized = true;
            locationalConst = (m * GSC.waveLength / GSC.meshPeriod) / Mathf.Sqrt((float)(1 - (m * GSC.waveLength / GSC.meshPeriod) * (m * GSC.waveLength / GSC.meshPeriod)));
        }

        if (GSC.sourceIsOn)
        {
            if (status == STATUS.Hidden)
                Unhide();
                
            if (GSC.benchHolder.heldObject == GSC.mesh)
            {
                if (prevMeshPosition != GSC.benchPosition || status != prevStatus)
                {
                    //if (isHidden)
                    //    Unhide();
                    this.ChangeStateToMesh(GSC.benchPosition);
                }
            }
            else if (GSC.benchHolder.heldObject == GSC.polaroid)
            {
                if (prevPolaroidAngle != GSC.polaroidAngle || status != prevStatus)
                {
                    if (status == STATUS.Shown)
                    {
                        if (m != 0)
                            Hide();
                        else
                            this.ChangeStateToPolaroid(GSC.polaroidAngle);
                    }
                }
            }
            else
            {
                if (status == STATUS.Shown)
                {
                    if (m != 0)
                        Hide();
                    else
                        Unhide();
                }
                prevMeshPosition = 0;
            }
        }
        else
        {
            if (status == STATUS.Shown)
                Hide();
        }
    }
}
