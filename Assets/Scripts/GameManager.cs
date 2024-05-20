using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isPaused;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TextMeshProUGUI _finalScore;
    [SerializeField] private ScoreManager _scoreManager;

    public bool IsPaused {
        get => _isPaused; 
        set => _isPaused = value; 
    }

    public void OnEnable() {
        _playerMovement.OnDeath += EndGame;
    }

    public void OnDisable() {
        _playerMovement.OnDeath -= EndGame;
    }

    public void EndGame() {
        _isPaused = true;
        _finalScore.text = "Final score: " + _scoreManager.CurrentScore.ToString();
        _scoreManager.ScoreText.text = "";
        _gameOverScreen.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }

    public void Exit() {
        SceneManager.LoadScene(0);
    }
}
