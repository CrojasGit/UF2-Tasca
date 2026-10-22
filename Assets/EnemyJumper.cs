using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    public float jumpForce = 5f;
    public float horizontalForceRange = 2f;
    private Rigidbody rb;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 3f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Saltar();
            timer = 3f;
        }
    }

    void Saltar()
    {
        // Fuerza vertical hacia arriba (impulse)
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Fuerza horizontal aleatoria
        float horiz = Random.Range(-horizontalForceRange, horizontalForceRange);
        rb.AddForce(new Vector3(horiz, 0, 0), ForceMode.Impulse);
    }
}