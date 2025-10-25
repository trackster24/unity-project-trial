using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        ScoreManager.instance = this;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    
    public void incrementScore(int scoreIn)
    {
        score += scoreIn;
    }
}
