using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Referencia al GameManager (se asigna en el inspector o se busca automáticamente)
    public GameManager gameManager;
    
    void Start()
    {
        // Asegurarse de que el collider sea trigger para detectar entradas
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
        
        // Si no hay referencia asignada, intentar encontrarla automáticamente
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en la KillZone
        if (other.CompareTag("Player"))
        {
            // Llamar al método de perder vida en el GameManager
            if (gameManager != null)
            {
                gameManager.PerderVida();
            }
            else
            {
                Debug.LogError("GameManager no encontrado - añade un GameManager a la escena");
            }
        }
    }
}