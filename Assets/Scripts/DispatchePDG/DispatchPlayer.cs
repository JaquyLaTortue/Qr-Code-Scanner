using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DispatchPlayer : MonoBehaviour
{
    public List<string> pdg = new List<string> { "Jeff Bezos", "Steve Jobs", "Bill Gates", "Elon Musk", "Larry Page", "Mark Zuckerberg" };
    public TMP_Text pdgName;
    public TMP_Text buttonText;

    public GameObject mask;

    public int numberOfPlayer;

    public void ChoosePDG()
    {
        if (numberOfPlayer > 0)
        {
            int randomI = Random.Range(0, pdg.Count);
            string tempName = pdg[randomI];
            pdg.Remove(pdg[randomI]);
            pdgName.text = $"{tempName} !";
            buttonText.text = "Joueur suivant";

            numberOfPlayer--;
            if (numberOfPlayer == 0)
            {
                buttonText.text = "Jouer";
            }
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Two()
    {
        numberOfPlayer = 2;
        mask.SetActive(false);
    }

    public void Three()
    {
        numberOfPlayer = 3;
        mask.SetActive(false);
    }

    public void Four()
    {
        numberOfPlayer = 4;
        mask.SetActive(false);
    }

    public void Back()
    {
        mask.SetActive(true);
        buttonText.text = "Premier joueur";
        pdgName.text = "";
        pdg = new List<string> { "Jeff Bezos", "Steve Jobs", "Bill Gates", "Elon Musk", "Larry Page", "Mark Zuckerberg" };
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
