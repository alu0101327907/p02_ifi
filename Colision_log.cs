using UnityEngine;

public class ColisionLog : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("He chocado con: " + collision.gameObject.name);
    }
}
