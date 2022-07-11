using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private float _destroyCoin;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private AudioSource _reboundSound;    
    [SerializeField] private Text _coinText;

    private void OnEnable()
    {
        _playerWallet.Coined += OnCoined;
    }

    private void OnDisable()
    {
        _playerWallet.Coined -= OnCoined;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Destroy(gameObject, _destroyCoin);
        }
    }

    private void OnCoined()
    {
        _coins++;
        _coinText.text = _coins.ToString();
        _reboundSound.Play();
    }
}
