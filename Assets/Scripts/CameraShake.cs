using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float dur, float magn)
    {
        Vector3 originalPos = Vector3.zero;

        float elapsed = 0f;

        while(elapsed < dur)
        {
            float x = Random.Range(-0.03f, 0.03f) * magn;
            float y = Random.Range(-0.03f, 0.03f) * magn;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}