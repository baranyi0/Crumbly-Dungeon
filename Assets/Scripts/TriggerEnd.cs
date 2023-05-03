using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    [SerializeField] GameObject whiteFade;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            whiteFade.SetActive(true);
        }
    }
}
