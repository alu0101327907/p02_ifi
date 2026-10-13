### Ejercicio 1

Crea un personaje, controla su desplazamiento con las teclas WASD o las flechas, el movimiento debe realizarse usando un Rigidbody, pero manteniendo el control total.

```bash
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector3(x * velocidad, rb.linearVelocity.y, z * velocidad);
    }
}
```

Con el Input Manager = OLD

<img width="717" height="422" alt="ej1" src="https://github.com/user-attachments/assets/9c00e99b-2746-4af1-af4a-603cf49fc1aa" />

### Ejercicio 2

Crea varios cubos o esferas con Rigidbody dinámico. Muestra por consola el nombre del objeto con el que colisiona, y cámbiale su color al colisionar.

```bash
using UnityEngine;

public class Colision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("He chocado con: " + collision.gameObject.name);

        GetComponent<Renderer>().material.color = Color.red;
    }
}
```

<img width="1454" height="675" alt="ej2" src="https://github.com/user-attachments/assets/7dd01bb7-fd60-4606-8646-c0a817446bf0" />
