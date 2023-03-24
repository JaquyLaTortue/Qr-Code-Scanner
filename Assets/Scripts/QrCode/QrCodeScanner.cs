using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QrCodeScanner : MonoBehaviour
{
    public Game game;

    private WebCamTexture Cam;

    public RawImage CamDisplay;

    public Transform camTr;

    [SerializeField] TextMeshProUGUI textout;

    // Start is called before the first frame update
    void Start()
    {
        game = GetComponentInParent<Game>();

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
        CamDisplay.gameObject.SetActive(true);
        Cam.Play();

        StartCoroutine(Scanwait());
    }

    void scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(Cam.GetPixels32(),Cam.width,Cam.height);
            if (result != null)
            {
                //QRCodeResult = QrCodeResult.Text;
                textout.text = result.Text;
                game.CardFunctionLaunching(result.Text);
            }
            else
            {
                //QRCodeResult = "Failed to read QrCode";
                textout.text = "Failed";
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
