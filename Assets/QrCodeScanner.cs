using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QrCodeScanner : MonoBehaviour
{
    public WebCamTexture Cam;
    public RawImage CamDisplay;


    // Start is called before the first frame update
    void Start()
    {
        Cam = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = Cam;
        Cam.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayCam()
    {
        Cam.Play();
    }
}
