using UnityEngine;

public class CoinDetector_Nombre : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Detecta por nombre de objeto
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Moneda recogida por nombre");
            Destroy(gameObject);
        }
    }
}