using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using zxing;

public class QrCodeScanner : MonoBehaviour
{
    public WebCamTexture Cam;


    public RawImage CamDisplay;
    public Image Background;

    public Quaternion baseRotation;
    public Transform camTr;

    // Start is called before the first frame update
    void Start()
    {
        string frontCamName = null;
        var webCamDevices = WebCamTexture.devices;
        foreach (var camDevice in webCamDevices)
        {
            if (camDevice.isFrontFacing)
            {
                frontCamName = camDevice.name;
                break;
            }
        }

        Cam = new WebCamTexture(frontCamName, Screen.width, Screen.height);
        CamDisplay.texture = Cam;
        CamDisplay.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);

        baseRotation = camTr.transform.rotation;
        camTr.transform.rotation = baseRotation * Quaternion.AngleAxis(Cam.videoRotationAngle, Vector3.up);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayCam()
    {
        if (!CamDisplay.IsActive())
        {
            CamDisplay.gameObject.SetActive(true);
            Background.gameObject.SetActive(true);
            Cam.Play();
        }
        else
        {
            CamDisplay.gameObject.SetActive(false);
            Background.gameObject.SetActive(false);
            Cam.Stop();
        }
    }
}
