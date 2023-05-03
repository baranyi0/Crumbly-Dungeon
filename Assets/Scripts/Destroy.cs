using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject stuff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(stuff, 2);
        }
    }
}
