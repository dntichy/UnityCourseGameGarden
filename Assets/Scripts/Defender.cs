using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defender object with its price
/// </summary>
public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100; // price of defender

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
