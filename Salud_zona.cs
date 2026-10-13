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
