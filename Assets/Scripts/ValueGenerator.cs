using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        double newWaveLength = 0.6328 * Mathf.Pow(10, -6);
        GSC.waveLengthString = "0.6328 * 10^-6";
        GSC.waveLength = newWaveLength;

        System.Random rnd = new System.Random();
        double perc = rnd.Next(90, 110) / 100d;
        double periodPart = 6.15 * perc;
        double newMeshPeriod = periodPart * Mathf.Pow(10, -6);
        GSC.meshPeriodString = periodPart.ToString() + " * 10^-6";
        GSC.meshPeriod = newMeshPeriod;

        int newI0 = rnd.Next(70, 130);
        GSC.i0 = newI0;
        //GSC.i0String = newI0.ToString();

        Debug.Log(GSC.waveLengthString);
        Debug.Log(GSC.meshPeriodString);
        Debug.Log(GSC.i0);
    }
}
