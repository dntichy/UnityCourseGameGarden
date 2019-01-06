using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawning Defenders to screen
/// </summary>
public class DefenderSpawner : MonoBehaviour
{
    Defender defender; //what to spawn
    /// <summary>
    /// On clicked in area
    /// </summary>
    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }


    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        //if have enough stars => spawn, spend
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);

        }
    }
    /// <summary>
    /// Returns rounded position of click area
    /// </summary>
    /// <returns></returns>
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }
    /// <summary>
    /// Rounds position of click
    /// </summary>
    /// <param name="rawWorldPos"></param>
    /// <returns></returns>
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }
    /// <summary>
    /// Spawns defender at possition 
    /// </summary>
    /// <param name="roundedWorldPos"></param>
    private void SpawnDefender(Vector2 roundedWorldPos)
    {
        Defender newDefender = Instantiate(defender, roundedWorldPos, Quaternion.identity) as Defender;
    }
}
