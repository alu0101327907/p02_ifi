
using UnityEngine;

public class EsferaPersigue : MonoBehaviour
{
    public Transform objetivo;
    public Collider cubo;
    public Material materialNuevo;
    public float velocidad = 2f;

    private bool haLlegado = false;
    private Renderer rendererCubo;

    void Start()
    {
        rendererCubo = cubo.GetComponent<Renderer>();
    }

    void Update()
    {
        if (haLlegado)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            objetivo.position,
            velocidad * Time.deltaTime
        );

        Collider esfera = GetComponent<Collider>();

        if (esfera.bounds.Intersects(cubo.bounds))
        {
            rendererCubo.material = materialNuevo;
            haLlegado = true;

            Debug.Log("¡La esfera ha alcanzado el cubo!");
        }
    }
}
