using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpQuit : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
