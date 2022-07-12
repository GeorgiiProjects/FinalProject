using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private AudioSource _reboundSound;    
    [SerializeField] private Text _coinText;

    private Object _coinEffect;
    private const string COIN_EFFECT = "Coin effect";

    private void OnEnable()
    {
        _playerWallet.Coined += OnCoined;
    }

    private void OnDisable()
    {
        _playerWallet.Coined -= OnCoined;
    }

    private void Start()
    {
        _coinEffect = Resources.Load(COIN_EFFECT);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            PlayParticle();
            PlaySound();
        }
    }

    private void OnCoined()
    {
        _coins++;
        _coinText.text = _coins.ToString();
    }

    private void PlayParticle()
    {
        var coinEffectRef = (GameObject)Instantiate(_coinEffect);
        coinEffectRef.transform.position = transform.position;
        Destroy(coinEffectRef, _timeToDestroy);
    }

    private void PlaySound()
    {
        _reboundSound.Play();
        Destroy(gameObject, _reboundSound.clip.length);
    }
}
