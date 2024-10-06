using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMouse : MonoBehaviour
{
    public float rotationSpeed; // Velocidade de rota��o

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
       
        // Captura a movimenta��o do mouse
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Aplica a rota��o ao objeto
        transform.Rotate(Vector3.up, mouseX);
        transform.Rotate(Vector3.right, -mouseY); // Inverte o eixo Y se necess�rio

        // Corrigindo o uso de localEulerAngles
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
    }
}
