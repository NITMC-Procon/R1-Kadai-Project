using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    private Camera cam;
    private uint count;
    public RenderTexture RenderStage;
    public RenderTexture RenderIcon;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        count = 0;

        cam.cullingMask = (1 << LayerMask.NameToLayer("Stage"));
        cam.targetTexture = RenderStage;
        cam.Render();
        cam.targetTexture = RenderIcon;
        cam.cullingMask = (1 << LayerMask.NameToLayer("MiniMap"));
    }
}
