using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QrCodeScanner : MonoBehaviour
{
    public Game game;
    public GameObject popUp;

    private WebCamTexture Cam;

    public RawImage CamDisplay;

    public Transform camTr;

    public bool canScan;
    public bool isAfterPopUp;

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

        Cam = new WebCamTexture(frontCamName, 500, 500);
        CamDisplay.texture = Cam;
        CamDisplay.gameObject.SetActive(true);
        Cam.Play();

        canScan = true;
        isAfterPopUp = false;
        StartCoroutine(ScanWait());
    }

    public void Scan()
    {
        if (canScan)
        {
            try
            {
                if (!isAfterPopUp)
                {
                    IBarcodeReader barcodeReader = new BarcodeReader();
                    Result result = barcodeReader.Decode(Cam.GetPixels32(), Cam.width, Cam.height);
                    if (result != null)
                    {
                        //QRCodeResult = QrCodeResult.Text;
                        canScan = false;
                        Debug.Log(result.Text);
                        game.CardFunctionLaunching(result.Text);
                        popUp.SetActive(true);
                    }
                    else
                    {
                        //QRCodeResult = "Failed to read QrCode";
                        Debug.Log("Failed");
                    }
                }
                else
                {
                    IBarcodeReader barcodeReader = new BarcodeReader();
                    Result result = null;
                    if (result != null)
                    {
                        //QRCodeResult = QrCodeResult.Text;
                        canScan = false;
                        Debug.Log(result.Text);
                        game.CardFunctionLaunching(result.Text);
                        popUp.SetActive(true);
                    }
                    else
                    {
                        //QRCodeResult = "Failed to read QrCode";
                        Debug.Log("Failed");
                    }
                }
            }
            catch
            {
                //QRCodeResult = "Failed in try";
                Debug.Log("Failed in try");
            }
            StartCoroutine(ScanWait());
        }
    }

    public IEnumerator ScanWait()
    {
        isAfterPopUp = false;
        yield return new WaitForSeconds(2f);
        Scan();
    }
}