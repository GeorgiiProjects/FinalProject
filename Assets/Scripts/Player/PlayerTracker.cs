using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Transform _followToPlayer;
    
    private Vector3 _deltaPosition;

    private void Start()
    {
        _deltaPosition = transform.position - _followToPlayer.position;
    }

    private void LateUpdate()
    {
        transform.position = _followToPlayer.position + _deltaPosition;
    }
}
