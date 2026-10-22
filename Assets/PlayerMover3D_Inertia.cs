using UnityEngine;

public class PlayerMover3D_Inertia : MonoBehaviour
{
    public float velocidad = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 targetVel = new Vector3(h, 0, v) * velocidad;

        rb.velocity = Vector3.Lerp(rb.velocity, targetVel, 0.1f);
    }
}