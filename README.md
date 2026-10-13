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

### Ejercicio 3

Crea una zona (por ejemplo, un cubo grande con Is Trigger = true). Al entrar, cambia el color del personaje o activa un efecto que cambie la luz. Al salir, revierte el cambio. Añade otra zona que aumente una variable daño.

```bash
using UnityEngine;

public class ZonaColor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
```

```bash
using UnityEngine;

public class ZonaDaño : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();

            if (jugador != null)
            {
                jugador.salud -= 10;

                Debug.Log("Salud actual: " + jugador.salud);
            }
        }
    }
}
```

```bash
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int salud = 100;
}
```

<img width="1461" height="808" alt="ej3" src="https://github.com/user-attachments/assets/2df872a1-839d-4f15-9a1c-972f912dc075" />

### Ejercicio 4

Crea tres tipos de objetos en capas distintas: jugador, enemigos, recolectables. Configura la Layer Collision Matrix (Project Settings > Physics). Haz que los enemigos solo colisionen con el jugador, y que los recolectables solo sean detectados por triggers.



