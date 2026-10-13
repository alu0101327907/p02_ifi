using UnityEngine;

public class Recolectable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡He detectado a: " + other.name);
    }
}