using UnityEngine;

public class ShakyText : MonoBehaviour
{
	private Vector3 originPosition;
	public float shake_decay = 0.002f;
	public float shake_intensity = .3f;

	private float temp_shake_intensity = 0;

	int i = 0;

	void OnGUI()
	{
		Shake();
	}

    public void ResetPos()
    {
		transform.position = originPosition;
    }

    void Update()
	{

		if (temp_shake_intensity > 0)
		{
			transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
			
			temp_shake_intensity -= shake_decay;
        }
	}

	void Shake()
	{
		originPosition = transform.position;
		temp_shake_intensity = shake_intensity;
		i++;
		if (i >= 200)
		{
			ResetPos();
			i = 0;
		}
	}
}