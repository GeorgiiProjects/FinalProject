using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform _playerCoordinates;
    [SerializeField] private Text _scoreText;

    private const string ZERO_SCORE = "0";

    private void Update()
    {
        _scoreText.text = _playerCoordinates.position.z.ToString(ZERO_SCORE);
    }
}
