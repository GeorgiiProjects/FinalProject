using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _delayDeath;
    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private ParticleSystem _dieExplosion;

    public event UnityAction Died;
    public event UnityAction Wined;

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {           
            Die();
        }

        if (collision.gameObject.TryGetComponent(out FinishLevel finishLevel))
        {
            Win();
        }
    } 

    public void Die()
    {
        Died?.Invoke();
        _dieSound.Play();
        _dieExplosion.Play();
        StartCoroutine(DelayVanish());
    }

    public void Win()
    {
        Wined?.Invoke();
        _winSound.Play();
        StartCoroutine(DelayVanish());
    }

    private IEnumerator DelayVanish()
    {
        yield return new WaitForSeconds(_delayDeath);
        gameObject.SetActive(false);
    }
}
