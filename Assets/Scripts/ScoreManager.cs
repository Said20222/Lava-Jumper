using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore;
    [SerializeField] private GameObject _player;
    [SerializeField] private TextMeshProUGUI _scoreText;


    public int CurrentScore {
        get { return _currentScore; }
        set { _currentScore = value; }
    }

    public TextMeshProUGUI ScoreText {
        get => _scoreText;
    }

    void Start()
    {
        _currentScore = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.transform.position.z > _currentScore) {
            _currentScore = (int)_player.transform.position.z;
            UpdateScoreText();
        }
    }

    void UpdateScoreText() {
        _scoreText.text = "Score: " + _currentScore.ToString();
    }

}
