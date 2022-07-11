using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    public event UnityAction Coined;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            TakeCoin();
        }
    }

    private void TakeCoin()
    {
        Coined?.Invoke();
    }
}
