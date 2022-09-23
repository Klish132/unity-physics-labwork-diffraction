using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public GameObject heldObject = null;
    
    public Vector3 defaultHoldingRotation = Vector3.zero;
    public Vector3 defaultHoldingPosition = Vector3.zero;
    public GameObject holdingParent = null;

    public void SetObject(GameObject newObject)
    {
        heldObject = newObject;
        if (holdingParent == null)
        {
            holdingParent = gameObject;
        }
        heldObject.transform.parent = holdingParent.transform;
        heldObject.transform.localPosition = defaultHoldingPosition;
        heldObject.transform.localRotation = Quaternion.Euler(defaultHoldingRotation);
    }
    public void ClearObject()
    {
        heldObject = null;
    }
}
