using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _endGame;
    [SerializeField] private Cat _cat;
    [SerializeField] private CanvasGroup _gameOverGroup;

    private void Start()
    {
        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _cat.Died += OnDied;
        _restartGame.onClick.AddListener(OnRestartButtonClick);
        _endGame.onClick.AddListener(OnEndGameButtonClick);
    }

    private void OnDisable()
    {
        _cat.Died -= OnDied;
        _restartGame.onClick.RemoveListener(OnRestartButtonClick);
        _endGame.onClick.RemoveListener(OnEndGameButtonClick);
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void OnEndGameButtonClick()
    {
        Application.Quit();
    }
}
