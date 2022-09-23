using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATUS
{
    Hidden,
    Shown
}

public class LaserObject : MonoBehaviour
{
    protected MeshRenderer meshRenderer;
    protected float currAlpha = 1f;
    protected STATUS status = STATUS.Shown;
    protected STATUS prevStatus = STATUS.Shown;
    protected void Hide()
    {
        prevStatus = status;
        status = STATUS.Hidden;
        this.SetAlpha(0f);
    }
    protected void Unhide()
    {
        prevStatus = status;
        status = STATUS.Shown;
        this.SetAlpha(1f);
    }

    private void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.material.color = new Color(1, 1, 1, 1);
    }
    public void SetAlpha(float alpha)
    {
        currAlpha = alpha;
        meshRenderer.material.color = new Color(1, 1, 1, currAlpha);
    }
}
