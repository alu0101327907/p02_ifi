using UnityEngine;

public class Colision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("He chocado con: " + collision.gameObject.name);

        GetComponent<Renderer>().material.color = Color.red;
    }
}
