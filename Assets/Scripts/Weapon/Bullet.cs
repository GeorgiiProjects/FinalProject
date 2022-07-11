using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyBullet;

    private void Start()
    {
        Destroy(gameObject, _destroyBullet);
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Destroy(gameObject);
        }
    }
}
