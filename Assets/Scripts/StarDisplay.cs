using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Shows current stars
/// </summary>
public class StarDisplay : MonoBehaviour
{
    private string results;

    [SerializeField] int stars = 100; //stars
    Text starText; //text to be displayed on GUI
    void Start()
    {

        starText = GetComponent<Text>();
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
    /// <summary>
    /// Add stars and updates display
    /// </summary>
    /// <param name="amount"></param>
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    /// <summary>
    /// Spend stars and update display
    /// </summary>
    /// <param name="amount"></param>
    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }
    /// <summary>
    /// Check if Having enough stars
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

}
