using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private Collider platformCol;
    private Collider playerCol;
    private bool ignoringCollision = false;

    void Start()
    {
        platformCol = GetComponent<Collider>();
        if (platformCol == null)
        {
            platformCol = gameObject.AddComponent<Collider>();
        }
        platformCol.isTrigger = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si el colisionador es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCol = collision.collider;
            // Comprobar si el jugador viene de abajo (normal apunta hacia arriba)
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;
            if (normal.y > 0.5f)
            {
                // Ignorar colisión para que el jugador pase por abajo
                Physics.IgnoreCollision(platformCol, playerCol, true);
                ignoringCollision = true;
                // Reactivar después de un frame pequeño
                Invoke("ReactivarColision", 0.1f);
            }
        }
    }

    void ReactivarColision()
    {
        if (ignoringCollision)
        {
            Physics.IgnoreCollision(platformCol, playerCol, false);
            ignoringCollision = false;
        }
    }

    // Dibujar el collider en el editor para debug
    private void OnDrawGizmos()
    {
        // nothing special
    }
}