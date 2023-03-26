using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public QrCodeScanner scanner;
    public TMP_Text result;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ClosePopUp()
    {
        scanner.isAfterPopUp = true;
        scanner.canScan = true;
        scanner.Scan();
        result.text = "";
        gameObject.SetActive(false);
    }
}
