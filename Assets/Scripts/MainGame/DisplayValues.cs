using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayValues : MonoBehaviour
{
    public Game game;
    public TMP_Text value;
    public TMP_Text chanceUp;
    public TMP_Text chanceDown;
    public Enterprise enterprise;

    void Start()
    {
        game = GetComponentInParent<Game>();
        enterprise = GetComponent<Enterprise>();
    }

    void Update()
    {
        value.text = ($"Current Value: \n" +
            $" {game.CalculateMarket(enterprise)}");

        chanceUp.text = ($"{enterprise.chanceToIncrease * 100}% to increase");
        chanceDown.text = ($"{enterprise.chanceToDecrease * 100}% to decrease");
    }
}