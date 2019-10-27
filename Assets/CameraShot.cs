using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CameraShot : MonoBehaviour {
    private Camera cam;
    [SerializeField] private GameObject Manager;
    private GameScene SceneManager;
    private Text Text_Popup;
    bool Shoted = false;
    void Start () {
        SceneManager = Manager.GetComponent<GameScene> ();
        Text_Popup = Manager.GetComponent<Manager> ().Text_Popup.GetComponent<Text> ();
        cam = this.GetComponent<Camera> ();
        cam.enabled = false;
        texture = new Texture2D (cam.targetTexture.width, cam.targetTexture.height, TextureFormat.RGBA32, false);
    }
    AsyncGPUReadbackRequest request;
    private Texture2D texture;
    void FixedUpdate () {
        if (Input.GetKeyDown (KeyCode.S)) {
            CamShot ();
        }
        if (request.hasError) {

        } else if (request.done) {
            Unity.Collections.NativeArray<Color32> buffer = request.GetData<Color32>();
            texture.LoadRawTextureData (buffer);
            texture.Apply();
            byte[] bytes = texture.EncodeToJPG ();
            File.WriteAllBytes ("Assets/Resources/hoge.jpg", bytes);
        }
    }
    public void CamShot () {
        if (Shoted == false) {
            Shoted = true;
            StartCoroutine ("IIZK");
        }
    }
    IEnumerator IIZK () {
        yield return new WaitForSeconds (0.1f);
        GameScene.Mode = "IIZK";
        Text_Popup.text = "You Are an IIZK!!";
        cam.Render ();
        request = AsyncGPUReadback.Request (cam.targetTexture);  
        yield return new WaitForSeconds (2f);
        SceneManager.IIZK ();
    }
}