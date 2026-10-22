using UnityEngine;

public class CoinWithAudio : MonoBehaviour
{
    public AudioClip sonidoRecogida; // Asignar un clip de "ping" en el inspector

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        if (sonidoRecogida == null)
        {
            // Intentar encontrar un sonido por defecto o usar uno simple
            Debug.LogWarning("No se ha asignado sonido de recogida");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && sonidoRecogida != null)
            {
                audioSource.PlayOneShot(sonidoRecogida);
            }
            Destroy(gameObject);
        }
    }
}