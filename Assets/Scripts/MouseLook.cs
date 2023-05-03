using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]float lookSensitivity = 5;
    [SerializeField] float smoothTime = 0.1f;
    Quaternion rotation;
    [SerializeField] float movementSpeed;
    public bool running = true;

    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        if (running)
        {
            transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }
        float yRotation = Input.GetAxis("Mouse Y") * lookSensitivity;
        float xRotation = Input.GetAxis("Mouse X") * lookSensitivity;

        rotation = Quaternion.Euler(-yRotation, xRotation, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, smoothTime * Time.deltaTime);
    }
}