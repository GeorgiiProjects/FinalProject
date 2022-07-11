using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float _spinSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime);
    }
}
