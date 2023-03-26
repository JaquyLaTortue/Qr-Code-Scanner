using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour
{
    public PopUp textResult;

    public Enterprise[] enterprises;

    // Lists of the potential increases or decreases
    public List<int> increases = new() { 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000 };
    public List<int> decreases = new() { -500, -1000, -1500, -2000, -2500, -3000, -3500, -4000, -4500, -5000 };

    void Start()
    {
        // get all enterprises
        enterprises = GetComponentsInChildren<Enterprise>();

        NextTour();
    }

    public void NextTour()
    {
        // set the new evolution for each enterprise when the tour is ended
        foreach (Enterprise enterprise in enterprises)
        {
            EvolutionOfTheCurve(enterprise);
        }
    }

    public int CalculateMarket(Enterprise enterprise)
    {
        // return the value of an enterprise's market
        return enterprise.value / 10;
    }

    public void EvolutionOfTheCurve(Enterprise enterprise)
    {
        // Set the new value of an enterprise
        if (enterprise.value >= 30000 && enterprise.value <= 40000)
        {
            switch (Dice())
            {
                case (1):
                case (2):
                case (3):
                    {
                        Increase(enterprise);
                        break;
                    }
                default:
                    {
                        Decrease(enterprise);
                        break;
                    }
            }
        }
        else if (enterprise.value >= 40000)
        {
            if (enterprise.hasIncrease)
            {
                switch (Dice())
                {
                    case (1):
                    case (2):
                        {
                            Increase(enterprise);
                            break;
                        }
                    default:
                        {
                            Decrease(enterprise);
                            break;
                        }
                }
            }
            else
            {
                switch (Dice())
                {
                    case (1):
                        {
                            Increase(enterprise);
                            break;
                        }
                    default:
                        {
                            Decrease(enterprise);
                            break;
                        }
                }
            }
        }
        else if (enterprise.value <= 7500)
        {
            if (enterprise.hasIncrease)
            {
                switch (Dice())
                {
                    case (1):
                    case (2):
                        {
                            Decrease(enterprise);
                            break;
                        }
                    default:
                        {
                            Increase(enterprise);
                            break;
                        }
                }
            }
            else
            {
                switch (Dice())
                {
                    case (1):
                        {
                            Decrease(enterprise);
                            break;
                        }
                    default:
                        {
                            Increase(enterprise);
                            break;
                        }
                }
            }
        }
        else
        {
            if (enterprise.hasIncrease)
            {
                switch (Dice())
                {
                    case (1):
                    case (2):
                        {
                            Decrease(enterprise);
                            break;
                        }
                    default:
                        {
                            Increase(enterprise);
                            break;
                        }
                }
            }
            else
            {
                switch (Dice())
                {
                    case (1):
                    case (2):
                        {
                            Increase(enterprise);
                            break;
                        }
                    default:
                        {
                            Decrease(enterprise);
                            break;
                        }
                }
            }
        }
        Percentage(enterprise);
    }

    public void Percentage(Enterprise enterprise)
    {
        if (enterprise.value >= 30000 && enterprise.value <= 40000)
        {
            enterprise.chanceToIncrease = 0.5f;
            enterprise.chanceToDecrease = 0.5f;
        }
        else if (enterprise.value >= 40000)
        {
            if (enterprise.hasIncrease)
            {
                enterprise.chanceToIncrease = 0.33f;
                enterprise.chanceToDecrease = 0.67f;
            }
            else
            {
                enterprise.chanceToIncrease = 0.17f;
                enterprise.chanceToDecrease = 0.83f;
            }
        }
        else if (enterprise.value <= 7500)
        {
            if (enterprise.hasIncrease)
            {
                enterprise.chanceToIncrease = 0.67f;
                enterprise.chanceToDecrease = 0.33f;
            }
            else
            {
                enterprise.chanceToIncrease = 0.83f;
                enterprise.chanceToDecrease = 0.17f;
            }
        }
        else
        {
            if (enterprise.hasIncrease)
            {
                enterprise.chanceToIncrease = 0.67f;
                enterprise.chanceToDecrease = 0.33f;
            }
            else
            {
                enterprise.chanceToIncrease = 0.33f;
                enterprise.chanceToDecrease = 0.67f;
            }
        }
    }

    public int Dice()
    {
        // Simulate a dice
        return Random.Range(1, 7);
    }

    public void Increase(Enterprise enterprise)
    {
        // Icrease the value
        enterprise.value += increases[Random.Range(0, increases.Count - 1)];
        if (enterprise.value >= 50000)
        {
            enterprise.value = 50000;
        }
        enterprise.hasIncrease = true;
        Percentage(enterprise);
    }

    public void Decrease(Enterprise enterprise)
    {
        // Decrease the value
        enterprise.value += decreases[Random.Range(0, decreases.Count - 1)];
        if (enterprise.value <= 1000)
        {
            enterprise.value = 1000;
        }
        enterprise.hasIncrease = false;
        Percentage(enterprise);
    }

    public void Crack()
    {
        foreach (Enterprise enterprise in enterprises)
        {
            enterprise.value -= 10000;
            if (enterprise.value <= 1000)
            {
                enterprise.value = 1000;
            }
            enterprise.hasIncrease = false;
            Percentage(enterprise);
        }
    }

    public void CardFunctionLaunching(string result)
    {
        switch (result)
        {
            case ("CRACK CA DEFOURRAILLE"):
                {
                    Crack();
                    textResult.result.text = "All enterprises decreased 10 000$";
                    break;
                }
            case ("RandomIncrease"):
                {
                    Enterprise randomEnterprise = enterprises[Random.Range(0, enterprises.Length)];
                    Increase(randomEnterprise);
                    textResult.result.text = $"{randomEnterprise} increased";
                    break;
                }
            case ("RandomDecrease"):
                {
                    Enterprise randomEnterprise = enterprises[Random.Range(0, enterprises.Length)];
                    Decrease(randomEnterprise);
                    textResult.result.text = $"{randomEnterprise} decreased";
                    break;
                }
            case ("AppleIncrease"):
                {
                    Enterprise apple = GameObject.FindGameObjectWithTag("Apple").GetComponent<Enterprise>();
                    Increase(apple);
                    textResult.result.text = $"Apple increased";
                    break;
                }
            case ("AppleDecrease"):
                {
                    Enterprise apple = GameObject.FindGameObjectWithTag("Apple").GetComponent<Enterprise>();
                    Decrease(apple);
                    textResult.result.text = $"Apple decreased";
                    break;
                }
            case ("MicrosoftIncrease"):
                {
                    Enterprise microsoft = GameObject.FindGameObjectWithTag("Microsoft").GetComponent<Enterprise>();
                    Increase(microsoft);
                    textResult.result.text = $"Microsoft increased";
                    break;
                }
            case ("MicrosoftDecrease"):
                {
                    Enterprise microsoft = GameObject.FindGameObjectWithTag("Microsoft").GetComponent<Enterprise>();
                    Decrease(microsoft);
                    textResult.result.text = $"Microsoft decreased";
                    break;
                }
            case ("MetaIncrease"):
                {
                    Enterprise meta = GameObject.FindGameObjectWithTag("Meta").GetComponent<Enterprise>();
                    Increase(meta);
                    textResult.result.text = $"Meta increased";
                    break;
                }
            case ("MetaDecrease"):
                {
                    Enterprise meta = GameObject.FindGameObjectWithTag("Meta").GetComponent<Enterprise>();
                    Decrease(meta);
                    textResult.result.text = $"Meta decreased";
                    break;
                }
            case ("AmazonIncrease"):
                {
                    Enterprise amazon = GameObject.FindGameObjectWithTag("Amazon").GetComponent<Enterprise>();
                    Increase(amazon);
                    textResult.result.text = $"Amazon increased";
                    break;
                }
            case ("AmazonDecrease"):
                {
                    Enterprise amazon = GameObject.FindGameObjectWithTag("Amazon").GetComponent<Enterprise>();
                    Decrease(amazon);
                    textResult.result.text = $"Amazon decreased";
                    break;
                }
            case ("TeslaIncrease"):
                {
                    Enterprise tesla = GameObject.FindGameObjectWithTag("Tesla").GetComponent<Enterprise>();
                    Increase(tesla);
                    textResult.result.text = $"Tesla increased";
                    break;
                }
            case ("TeslaDecrease"):
                {
                    Enterprise tesla = GameObject.FindGameObjectWithTag("Tesla").GetComponent<Enterprise>();
                    Decrease(tesla);
                    textResult.result.text = $"Tesla decreased";
                    break;
                }
            case ("GoogleIncrease"):
                {
                    Enterprise google = GameObject.FindGameObjectWithTag("Google").GetComponent<Enterprise>();
                    Increase(google);
                    textResult.result.text = $"Google increased";
                    break;
                }
            case ("GoogleDecrease"):
                {
                    Enterprise google = GameObject.FindGameObjectWithTag("Google").GetComponent<Enterprise>();
                    Decrease(google);
                    textResult.result.text = $"Google decreased";
                    break;
                }
            default:
                {
                    textResult.result.text = "QR code non valide";
                    break;
                }
        }
    }
}