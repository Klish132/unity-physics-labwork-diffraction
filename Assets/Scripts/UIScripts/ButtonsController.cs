using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public GameObject bench = null;
    private ObjectOfFocus benchScript = null;

    public GameObject zoomoutButton = null;
    public GameObject goBackButton = null;

    // Start is called before the first frame update
    void Start()
    {
        benchScript = bench.GetComponent<ObjectOfFocus>();
    }

    public void FocusOnBench()
    {
        benchScript.Focus();
    }

    // Update is called once per frame
    void Update()
    {
        if (GSC.focusTarget != GSC.bench)
        {
            zoomoutButton.SetActive(true);
        } else
        {
            zoomoutButton.SetActive(false);
        }
        if (GSC.isOnRuler)
        {
            goBackButton.SetActive(true);
        }
        else
        {
            goBackButton.SetActive(false);
        }
    }
}
