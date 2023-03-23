using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Enterprise[] enterprises;

    // Lists of the potential increases or decreases
    public List<int> increases = new() { 500, 1000, 2000, 3000, 4000, 5000 };
    public List<int> decreases = new() { -500, -1000, -2000, -3000, -4000, -5000 };

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
    }
    
    public void Percentage(Enterprise enterprise)
    {
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
    }
}