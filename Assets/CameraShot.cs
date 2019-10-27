using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CameraShot : MonoBehaviour
{
    Texture2D _tex;
    RenderTexture _renderTex;
    void Start()
    {
        _tex = new Texture2D(Screen.currentResolution.width, Screen.currentResolution.height, TextureFormat.RGBA32, false);
        _renderTex = new RenderTexture(_tex.width, _tex.height, 24, RenderTextureFormat.ARGB32);
        if(SystemInfo.supportsAsyncGPUReadback){
            Debug.Log("OK");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            var reqest = AsyncGPUReadback.Request(_renderTex);
            if(reqest.done){
            Unity.Collections.NativeArray<Color32> buffer = reqest.GetData<Color32>();
            _tex.LoadRawTextureData(buffer);
            _tex.Apply();
            }


            Debug.Log("OK");
        }
    }
}
