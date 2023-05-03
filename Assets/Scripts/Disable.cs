using UnityEngine;

public class Disable : MonoBehaviour
{
    public void DisableThis()
    {
        this.gameObject.SetActive(false);
    }
}
