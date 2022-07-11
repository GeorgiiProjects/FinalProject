using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioSource _shootSound;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.K))
            Shoot();
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        _shootSound.Play();
    }
}
