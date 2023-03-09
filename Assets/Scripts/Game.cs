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

    // set the new evolution for each enterprise when the tour is ended
    public void NextTour()
    {
        foreach (Enterprise enterprise in enterprises)
        {
            EvolutionOfTheCurve(enterprise);
        }
    }

    // return the value of an enterprise's market
    public int CalculateMarket(Enterprise enterprise)
    {
        return enterprise.value / 10;
    }

    // set the new evolution of an enterprise depending of it previous evolution
    // If an enterprise has increase during the previous tour, so it has 4 in 6 chance
    // of increase again and 2 in 6 chance of decrease and vice versa if it has decrease
    public void EvolutionOfTheCurve(Enterprise enterprise)
    {
        if (enterprise.hasIncrease == true)
        {
            switch (Random.Range(1, 7))
            {
                case (5):
                    {
                        enterprise.value += decreases[Random.Range(0, decreases.Count - 1)];
                        if (enterprise.value <= 1000)
                        {
                            enterprise.value = 1000;
                        }
                        enterprise.hasIncrease = false;
                        break;
                    }
                case (6):
                    {
                        enterprise.value += decreases[Random.Range(0, decreases.Count - 1)];
                        if (enterprise.value <= 1000)
                        {
                            enterprise.value = 1000;
                        }
                        enterprise.hasIncrease = false;
                        break;
                    }
                default:
                    {
                        enterprise.value += increases[Random.Range(0, increases.Count - 1)];
                        if (enterprise.value >= 50000)
                        {
                            enterprise.value = 50000;
                        }
                        enterprise.hasIncrease = true;
                        break;
                    }
            }
        }
        else
        {
            switch (Random.Range(1, 7))
            {
                case (5):
                    {
                        enterprise.value += increases[Random.Range(0, increases.Count - 1)];
                        if (enterprise.value >= 50000)
                        {
                            enterprise.value = 50000;
                        }
                        enterprise.hasIncrease = true;
                        break;
                    }
                case (6):
                    {
                        enterprise.value += increases[Random.Range(0, increases.Count - 1)];
                        if (enterprise.value >= 50000)
                        {
                            enterprise.value = 50000;
                        }
                        enterprise.hasIncrease = true;
                        break;
                    }
                default:
                    {
                        enterprise.value += decreases[Random.Range(0, decreases.Count - 1)];
                        if (enterprise.value <= 1000)
                        {
                            enterprise.value = 1000;
                        }
                        enterprise.hasIncrease = false;
                        break;
                    }
            }
        }
    }
}