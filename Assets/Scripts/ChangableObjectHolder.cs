using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangableObjectHolder : ObjectHolder
{
    public int minValue = 0;
    public int maxValue = 0;

    public int moveOffset = 1;
    public int currPos = 0;

    private void Update()
    {
        if (heldObject != null && !GSC.isDragging && (GSC.focusTarget == gameObject || GSC.focusTarget == GSC.meshFrame))
        {
            currPos = GSC.benchPosition = (int)heldObject.transform.localPosition.z;
            if (currPos - moveOffset >= minValue && Input.GetKeyDown("left"))
            {
                heldObject.transform.localPosition += new Vector3(0, 0, -moveOffset);
                GSC.benchPosition = currPos - moveOffset;
            }
            else if (currPos + moveOffset <= maxValue && Input.GetKeyDown("right"))
            {
                heldObject.transform.localPosition += new Vector3(0, 0, moveOffset);
                GSC.benchPosition = currPos + moveOffset;
            }
        }
    }
}
