using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QrCodeScanner : MonoBehaviour
{
    private WebCamTexture Cam;

    public RawImage CamDisplay;
    public Image Background;

    public Transform camTr;

    string QRCodeResult;

    [SerializeField] TextMeshProUGUI textout;

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

        StartCoroutine(Scanwait());

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

    void scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(Cam.GetPixels32(),Cam.width,Cam.height);
            if (result != null)
            {
                //QRCodeResult = result.Text;
                textout.text = result.Text;
            }
            else
            {
                //QRCodeResult = "Failed to read QrCode";
                textout.text = "Failed to read QrCode";
            }
        }
        catch
        {
            //QRCodeResult = "Failed in try";
            textout.text = "Failed in try";

        }
        StartCoroutine(Scanwait());
    }



    public IEnumerator Scanwait()
    {
        yield return new WaitForSeconds(2f);
        scan();
    }
}
