using UnityEngine;

public class LanzarObjeto : MonoBehaviour
{
    public float fuerza = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(Vector3.back * fuerza
                + Vector3.up * fuerza, ForceMode.Impulse);
        }
    }
}