using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class GrabTexture : MonoBehaviour
{

    private float RTTSliderValue = .3f;
    public bool ShowRTT = false;
    private float AspectRatio;
    private Vector2 Scale;
    public Camera MainCamera;
    public LayerMask Layer = -1;
    public RenderTextureFormat TextureFormat = RenderTextureFormat.ARGBFloat;
    [SerializeField]
    [Range(1, 4)]
    int Downsampling = 1;
    private Vector2 PreviousTextureSize = new Vector2(1, 1);
    private Vector2 RTT_size = new Vector2(128, 128);
    private GameObject secondaryCamera;
    public RenderTexture _SceneColor;

    void Start()
    {

    }
    void CameraSetup()
    {
        MainCamera = Camera.main;
        secondaryCamera = GameObject.Find("Secondary Camera");
        if (!secondaryCamera)
        {
            secondaryCamera = new GameObject("Secondary Camera");
            secondaryCamera.AddComponent<Camera>();
        }
        secondaryCamera.GetComponent<Camera>().renderingPath = RenderingPath.DeferredLighting;
        secondaryCamera.GetComponent<Camera>().hdr = MainCamera.hdr;
        secondaryCamera.GetComponent<Camera>().enabled = false;
		secondaryCamera.GetComponent<Camera>().cullingMask = ~(1 << LayerMask.NameToLayer("TransparentFX"));
        //secondaryCamera.hideFlags = HideFlags.HideAndDontSave;              
    }

    void OnEnable()
    {
        CameraSetup();
    }

    void OnWillRenderObject()
    {
        RTT_size.x = (int)Screen.width / Downsampling;
        RTT_size.y = (int)Screen.height / Downsampling;

        if (!_SceneColor || PreviousTextureSize != RTT_size)
        {
            if (_SceneColor)
                DestroyImmediate(_SceneColor);
            _SceneColor = new RenderTexture((int)RTT_size.x, (int)RTT_size.y, 0, TextureFormat);
            _SceneColor.name = "SceneColor";
            _SceneColor.isPowerOfTwo = true;
            _SceneColor.hideFlags = HideFlags.HideAndDontSave;
            PreviousTextureSize = RTT_size;
        }

        if (MainCamera)
        {
            secondaryCamera.GetComponent<Camera>().clearFlags = MainCamera.clearFlags;
            secondaryCamera.GetComponent<Camera>().transform.rotation = MainCamera.transform.rotation;
            secondaryCamera.GetComponent<Camera>().transform.position = MainCamera.transform.position;
            secondaryCamera.GetComponent<Camera>().fieldOfView = MainCamera.fieldOfView;
            //secondaryCamera.GetComponent<Camera>().cullingMask = Layer;
            secondaryCamera.GetComponent<Camera>().targetTexture = _SceneColor;
            
            secondaryCamera.GetComponent<Camera>().Render();
            
            GetComponent<Renderer>().sharedMaterial.SetTexture("_R", _SceneColor);
            GetComponent<Renderer>().sharedMaterial.SetTexture("_G", _SceneColor);
            GetComponent<Renderer>().sharedMaterial.SetTexture("_B", _SceneColor);
             
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        DestroyImmediate(secondaryCamera);
        if (_SceneColor)
        {
            DestroyImmediate(_SceneColor);
            _SceneColor = null;
        }
    }
    void OnGUI()
    {

        int HPos = 10;
        int Vpos = 100;
     
        if (_SceneColor)
        {
            AspectRatio = RTT_size.x / RTT_size.y;

            Scale.x = Screen.width * RTTSliderValue;
            Scale.y = Screen.height * RTTSliderValue;

           

            if (ShowRTT)
            {
                GUI.DrawTexture(new Rect(HPos, Vpos, Scale.x, Scale.y), _SceneColor, ScaleMode.StretchToFill, false, AspectRatio);
               
                RTTSliderValue = GUI.HorizontalSlider(new Rect(10, 80, 100, 30), RTTSliderValue, 0, .5f);

            }

        }
    }
}
