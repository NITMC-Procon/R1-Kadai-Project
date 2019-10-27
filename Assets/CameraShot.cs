using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CameraShot : MonoBehaviour
{
    Texture2D _tex;
    RenderTexture _renderTex;
    private Camera cam;
    [SerializeField] private GameObject Manager;
    private GameScene SceneManager;
    private Text Text_Popup;
    void Start()
    {
        SceneManager = Manager.GetComponent<GameScene>();
        Text_Popup = Manager.GetComponent<Manager>().Text_Popup.GetComponent<Text>();
        cam = this.GetComponent<Camera>();
        cam.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            cam.Render();
        }
    }
    public void CamShot()
    {
        StartCoroutine("Wait");
        GameScene.Mode = "IIZK";
        Text_Popup.text = "You Are an IIZK!!";
        cam.Render();
        StartCoroutine("End");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.IIZK();
    }
}
