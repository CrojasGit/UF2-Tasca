using UnityEngine;

public class CoinDetector_Tag : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Detecta por tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moneda recogida por tag");
            Destroy(gameObject);
        }
    }
}