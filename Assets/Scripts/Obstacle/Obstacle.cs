using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _destroyObstacle;
    [SerializeField] private AudioSource _explosionSound;
    [SerializeField] private ParticleSystem _obstacleExplosion;   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            Destroyer();
        }
    }

    private void Destroyer()
    {
        _explosionSound.Play();
        _obstacleExplosion.Play();
        Destroy(gameObject, _destroyObstacle);
    }
}
