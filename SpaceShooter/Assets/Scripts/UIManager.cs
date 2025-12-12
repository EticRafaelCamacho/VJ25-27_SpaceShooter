using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] int totalScore = 0;
    [SerializeField] private TextMeshProUGUI displayScore;
    public void AddScore(int amount)
    {
        totalScore += amount;
        displayScore.text = totalScore.ToString();
    }
}
