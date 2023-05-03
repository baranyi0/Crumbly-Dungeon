using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    // Update is called once per frame
    public void Shake()
    {
        cameraShake.StartCoroutine(cameraShake.Shake(0.11f, 0.7f));
    }
}
