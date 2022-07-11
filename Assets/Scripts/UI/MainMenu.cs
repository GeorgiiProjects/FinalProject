using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _agavaButton;
    [SerializeField] private Button _youtubeButton;
    [SerializeField] private Button _vkontakteButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _quitButton.onClick.AddListener(OnQuitButtonClick);
        _agavaButton.onClick.AddListener(OnAgavaButtonClick);
        _youtubeButton.onClick.AddListener(OnYoutubeButtonClick);
        _vkontakteButton.onClick.AddListener(OnVkontakteButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _quitButton.onClick.RemoveListener(OnQuitButtonClick);
        _agavaButton.onClick.RemoveListener(OnAgavaButtonClick);
        _youtubeButton.onClick.RemoveListener(OnYoutubeButtonClick);
        _vkontakteButton.onClick.RemoveListener(OnVkontakteButtonClick);
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void OnAgavaButtonClick()
    {
        Application.OpenURL("https://ijunior.ru/");
    }

    private void OnYoutubeButtonClick()
    {
        Application.OpenURL("https://www.youtube.com/c/GamedevelopingRu1");
    }

    private void OnVkontakteButtonClick()
    {
        Application.OpenURL("https://vk.com/holymonkey_sandbox");
    }

    private void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
