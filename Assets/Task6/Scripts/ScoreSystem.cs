using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;

    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than 1 ScoreSystem");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        if (amount == 0)
        {
            Debug.LogWarning("You increase the score by 0");
            return;
        }
        if (amount < 0)
        {
            Debug.LogWarning("You are trying to reduce the score");
            return;
        }

        _score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {_score}";
    }
}
