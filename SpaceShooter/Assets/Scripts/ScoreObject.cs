using UnityEngine;

public class ScoreObject : MonoBehaviour
{

    [SerializeField] private int score = 0;

    void OnDestroy()
    {
        if (GameObject.Find("UIManager") != null)
        {
            GameObject.Find("UIManager").GetComponent<UIManager>().AddScore(score);
        }
    }
}
