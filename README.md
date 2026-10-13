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

<img width="343" height="439" alt="image" src="https://github.com/user-attachments/assets/cf744c66-691c-4d1a-8020-047586199c9f" />

```bash
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡He detectado a: " + other.name);
    }
}
```

### Ejercicio 5

Crea una escena con distintos materiales físicos (resbaladizo, rugoso, rebote alto). Aplica distintos Physic Materials a objetos. Lanza los objetos con AddForce() al pulsar la tecla X y observa cómo cambian las reacciones.

```bash
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
```

<img width="221" height="197" alt="image" src="https://github.com/user-attachments/assets/8efb8bc8-3d63-46b8-be6f-467870685354" />

<img width="226" height="180" alt="image" src="https://github.com/user-attachments/assets/9e19a25e-d6f9-4c45-8f63-5d59b0a16cea" />

<img width="223" height="190" alt="image" src="https://github.com/user-attachments/assets/6dadfa8f-3e2d-4263-9a33-730378806f99" />

<img width="1080" height="500" alt="ej5" src="https://github.com/user-attachments/assets/a0315ea1-6abd-4aaf-8dff-d5fd216924f3" />

### Ejercicio 6

En la escena debe haber 3 objetos que tengan Collider pero no Rigidbody. Un cubo, una esfera y un cilindro que deben estar alineados. Marcar el cilindro como objetivo a alcanzar por la esfera. El cubo debe hacer de obstáculo entre ambos. Implementar un script que haga que la esfera se dirija al cilindro, cuando la esfera alcance el cubo, este debe cambiar su material.

<img width="450" height="873" alt="image" src="https://github.com/user-attachments/assets/187e740e-cc73-4266-9bcc-9940f1731843" />


```bash

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
```

<img width="1080" height="500" alt="ej6" src="https://github.com/user-attachments/assets/38a49279-cd96-4010-ab2a-88c1e4317d63" />


