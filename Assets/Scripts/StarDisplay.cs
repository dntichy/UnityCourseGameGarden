using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    private string results;

    [SerializeField] int stars = 100;
    Text starText;
    void Start()
    {

        starText = GetComponent<Text>();
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

}
