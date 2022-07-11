using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private float _delayDuration;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.blocksRaycasts = false;
    }

    private void OnDied()
    {
        StartCoroutine(LoadLoseScreen());
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;       
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private IEnumerator LoadLoseScreen()
    {
        yield return new WaitForSeconds(_delayDuration);
        _gameOverGroup.alpha = 1;
        _gameOverGroup.blocksRaycasts = true;
        Time.timeScale = 0;
    }
}
