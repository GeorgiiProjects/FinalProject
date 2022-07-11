using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _towardSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _boostSpeed;
    [SerializeField] private float _speedUpDuration;
    [SerializeField] private float _xRange;
    [SerializeField] private AudioSource _jumpSound;

    private bool _isOnGround = true;
    private Rigidbody _playerRb;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Position();       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SpeedBooster speedBooster))
        {
            _playerRb.AddForce(0, 0, _forwardSpeed * _boostSpeed);
            SpeedupCooldown();
        }
    }

    private void Move()
    {
        _playerRb.AddForce(0, 0, _forwardSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            _playerRb.AddForce(-_towardSpeed * Time.fixedDeltaTime, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            _playerRb.AddForce(_towardSpeed * Time.fixedDeltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _jumpSound.Play();
        }
    }

    private void Position()
    {       
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xRange, _xRange), transform.position.y, transform.position.z);
    }

    private IEnumerator SpeedupCooldown()
    {
        yield return new WaitForSeconds(_speedUpDuration);
    }
}
