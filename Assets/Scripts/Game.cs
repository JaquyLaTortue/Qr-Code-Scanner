using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour
{
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
                    break;
                }
            case ("RandomIncrease"):
                {
                    Increase(enterprises[Random.Range(0, enterprises.Length + 1)]); 
                    break;
                }
            case ("RandomDecrease"):
                {
                    Decrease(enterprises[Random.Range(0, enterprises.Length + 1)]);
                    break;
                }
            case ("AppleIncrease"):
                {
                    Enterprise apple = GameObject.FindGameObjectWithTag("Apple").GetComponent<Enterprise>();
                    Increase(apple);
                    break;
                }
            case ("AppleDecrease"):
                {
                    Enterprise apple = GameObject.FindGameObjectWithTag("Apple").GetComponent<Enterprise>();
                    Decrease(apple);
                    break;
                }
            case ("MicrosoftIncrease"):
                {
                    Enterprise microsoft = GameObject.FindGameObjectWithTag("Microsoft").GetComponent<Enterprise>();
                    Increase(microsoft);
                    break;
                }
            case ("MicrosoftDecrease"):
                {
                    Enterprise microsoft = GameObject.FindGameObjectWithTag("Microsoft").GetComponent<Enterprise>();
                    Decrease(microsoft);
                    break;
                }
            case ("MetaIncrease"):
                {
                    Enterprise meta = GameObject.FindGameObjectWithTag("Meta").GetComponent<Enterprise>();
                    Increase(meta);
                    break;
                }
            case ("MetaDecrease"):
                {
                    Enterprise meta = GameObject.FindGameObjectWithTag("Meta").GetComponent<Enterprise>();
                    Decrease(meta);
                    break;
                }
            case ("AmazonIncrease"):
                {
                    Enterprise amazon = GameObject.FindGameObjectWithTag("Amazon").GetComponent<Enterprise>();
                    Increase(amazon);
                    break;
                }
            case ("AmazonDecrease"):
                {
                    Enterprise amazon = GameObject.FindGameObjectWithTag("Amazon").GetComponent<Enterprise>();
                    Decrease(amazon);
                    break;
                }
            case ("TeslaIncrease"):
                {
                    Enterprise tesla = GameObject.FindGameObjectWithTag("Tesla").GetComponent<Enterprise>();
                    Increase(tesla);
                    break;
                }
            case ("TeslaDecrease"):
                {
                    Enterprise tesla = GameObject.FindGameObjectWithTag("Tesla").GetComponent<Enterprise>();
                    Decrease(tesla);
                    break;
                }
            case ("GoogleIncrease"):
                {
                    Enterprise google = GameObject.FindGameObjectWithTag("Google").GetComponent<Enterprise>();
                    Increase(google);
                    break;
                }
            case ("GoogleDecrease"):
                {
                    Enterprise google = GameObject.FindGameObjectWithTag("Google").GetComponent<Enterprise>();
                    Decrease(google);
                    break;
                }
            default:
                {
                    Debug.Log("QR code non valide");
                    break;
                }
        }
    }
}