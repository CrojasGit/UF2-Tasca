using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int vidasMaximas = 3;
    public int vidasActuales;
    
    public Transform puntoRespawn;
    public string tagJugador = "Player";
    public string tagKillZone = "KillZone";
    
    private GameObject jugador;
    private bool gameOver = false;
    
    void Start()
    {
        vidasActuales = vidasMaximas;
        Time.timeScale = 1f;
        
        // Buscar el jugador al inicio
        jugador = GameObject.FindGameObjectWithTag(tagJugador);
        if (jugador != null)
        {
            puntoRespawn = jugador.transform;
        }
        
        // Configurar detección de KillZone si no hay script específico
        ConfigurarKillZone();
    }
    
    void ConfigurarKillZone()
    {
        // Si no hay un objeto con tag KillZone, buscar uno
        GameObject killZone = GameObject.FindGameObjectWithTag(tagKillZone);
        if (killZone != null)
        {
            KillZone kz = killZone.GetComponent<KillZone>();
            if (kz == null)
            {
                // Agregar el script KillZone si no existe
                kz = killZone.AddComponent<KillZone>();
            }
        }
    }

    void Update()
    {
        if (gameOver) return;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Debug.Log("Juego reanudado");
        }
        else
        {
            Time.timeScale = 0f;
            Debug.Log("Juego pausado");
        }
    }

    // Llamar cuando el jugador cae a la KillZone
    public void PerderVida()
    {
        if (gameOver) return;
        
        vidasActuales--;
        Debug.Log("Vidas restantes: " + vidasActuales);
        
        if (vidasActuales > 0)
        {
            RespawnJugador();
        }
        else
        {
            GameOver();
        }
    }

    void RespawnJugador()
    {
        // Respawn en la posición actual del punto de respawn (sin recargar escena)
        if (jugador != null && puntoRespawn != null)
        {
            jugador.transform.position = puntoRespawn.position;
            jugador.transform.rotation = puntoRespawn.rotation;
            jugador.SetActive(true);
            // Reactivar componentes del jugador
            Rigidbody rb = jugador.GetComponent<Rigidbody>();
            if (rb != null) rb.velocity = Vector3.zero;
        }
        else
        {
            Debug.LogWarning("No se pudo respawn: jugador o puntoRespawn faltantes");
        }
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
        Time.timeScale = 0f;
        // Aquí podríamos cargar una escena de Game Over o mostrar mensaje
    }
}