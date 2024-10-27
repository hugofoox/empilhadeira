using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMouse : MonoBehaviour
{
    public float rotationSpeed; // Velocidade de rotação

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
       
        // Captura a movimentação do mouse
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Aplica a rotação ao objeto
        transform.Rotate(Vector3.up, mouseX);
        transform.Rotate(Vector3.right, -mouseY); // Inverte o eixo Y se necessário

        // Corrigindo o uso de localEulerAngles
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);

        if (transform.localEulerAngles.x < 330 && transform.localEulerAngles.x > 200)
        {
            transform.localEulerAngles = new Vector3(330.0f, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        if (transform.localEulerAngles.x > 50 && transform.localEulerAngles.x < 200)
        {
            transform.localEulerAngles = new Vector3(50.0f, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
