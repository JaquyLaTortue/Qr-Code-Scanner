using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enterprise : MonoBehaviour
{
    // features of the enterprise
    public new string name;
    public string size;
    public int value;
    public bool hasIncrease;
    public float chanceToIncrease;
    public float chanceToDecrease;

    // possibilities of value depending of the enterprise's size
    private List<int> littleValues = new List<int> { 15000, 16000, 17000, 18000, 19000, 20000 };
    private List<int> mediumValues = new List<int> { 21000, 22000, 23000, 24000, 25000, 26000 };
    private List<int> bigValues = new List<int> { 30000, 31000, 32000, 33000, 34000, 35000 };

    void Awake()
    {
        name = gameObject.name;

        // set the value of the enterprise depending of it size
        switch (size)
        {
            case ("little"):
                {
                    value = littleValues[Random.Range(0, littleValues.Count)];
                    break;
                }
            case ("medium"):
                {
                    value = mediumValues[Random.Range(0, mediumValues.Count)];
                    break;
                }
            case ("big"):
                {
                    value = bigValues[Random.Range(0, bigValues.Count)];
                    break;
                }
            default:
                {
                    print($"Choose a valid size for {name}");
                    break;
                }
        }

        // determine the virtual previous evolution
        hasIncrease = Random.Range(0, 2) == 1;
    }
}