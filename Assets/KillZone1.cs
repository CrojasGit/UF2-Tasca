using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KillZone1 : MonoBehaviour
{
    public GameManager gameManager;
    
    void Start()
    {
        // Asegura que el collider sea trigger
        Collider col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
        
        // Busca automáticamente el GameManager si no está asignado
        if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.PerderVida();
            }
        }
    }
}
