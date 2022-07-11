using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class WinScreen : MonoBehaviour
{
    [SerializeField] private float _delayNextScene;
    [SerializeField] private Player _player;

    private CanvasGroup _winGroup;

    private void OnEnable()
    {
        _player.Wined += OnWined;
    }

    private void OnDisable()
    {
        _player.Wined -= OnWined;
    }

    private void Start()
    {
        _winGroup = GetComponent<CanvasGroup>();
        _winGroup.alpha = 0;
    }

    private void OnWined()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {   
        _winGroup.alpha = 1;       
        yield return new WaitForSeconds(_delayNextScene);
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
