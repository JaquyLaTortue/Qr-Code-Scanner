using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayValues : MonoBehaviour
{
    public Game game;
    public TMP_Text tmp;
    public Enterprise enterprise;

    void Start()
    {
        game = GetComponentInParent<Game>();
        tmp = GetComponentInChildren<TMP_Text>();
        enterprise = GetComponent<Enterprise>();
    }

    void Update()
    {
        tmp.text = ($"Current Value: \n" +
            $" {game.CalculateMarket(enterprise)}");
    }
}