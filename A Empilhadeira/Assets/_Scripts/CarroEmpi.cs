using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class CarroEmpi : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 30f;

    private float motorInput;
    private float steeringInput;

    private Rigidbody rb;
    [SerializeField]
    private float speedMax;

    public Transform faca;
    public float facamax = 1.5f; // Posição máxima da faca
    public float facamin = 0.5f; // Posição mínima da faca
    public float scrollSpeed = 1f; // Velocidade de movimento da faca com o scroll
    private float currentYPosition;

    public float target;

    private void Start()
    {
        currentYPosition = faca.localPosition.y;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        // Captura o movimento do scroll do mouse
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        

        // Calcula a nova posição Y baseada no input do scroll
        currentYPosition += scrollInput * scrollSpeed;

        // Restringe a posição Y entre facamin e facamax
        currentYPosition = Mathf.Clamp(currentYPosition, facamin, facamax);

        // Debug.Log(faca.localPosition.y);

        // Atualiza a posição da faca
        Vector3 newPosition = faca.localPosition;
        newPosition.y = currentYPosition;
        faca.localPosition = Vector3.Lerp(faca.localPosition, newPosition, target*Time.deltaTime);
        





        // Recebendo inputs do jogador
        motorInput = Input.GetAxis("Vertical"); // Controle para frente e para trás
        steeringInput = Input.GetAxis("Horizontal"); // Controle de direção

        // Atualizando a posição visual das rodas
        UpdateWheelPositions();

        // Controla o movimento
        if (Input.GetAxis("Vertical") != 0)
        {
            ApplyDrive();
        }
        else
        {
            ApplyBreack();
        }
       
        ApplySteering();

        // Debug.Log(rb.velocity.magnitude);

        
    }


    void ApplyDrive()
    {
        if (rb.velocity.magnitude <= speedMax)
        {
            float motor = maxMotorTorque * motorInput;

            // Aplica força nas rodas traseiras para mover a empilhadeira


            rearLeftWheel.brakeTorque = 0f;
            rearRightWheel.brakeTorque = 0f;

            rearLeftWheel.motorTorque = motor;
            rearRightWheel.motorTorque = motor;
        }
        else
        {
            rearLeftWheel.brakeTorque = maxMotorTorque;
            rearRightWheel.brakeTorque = maxMotorTorque;

            rearLeftWheel.motorTorque = 0;
            rearRightWheel.motorTorque = 0;

        }
    }

    void ApplyBreack()
    {
        
       float motor = maxMotorTorque;

        rearLeftWheel.motorTorque = 0;
        rearRightWheel.motorTorque = 0;

        rearLeftWheel.brakeTorque = motor * 0.6f;
        rearRightWheel.brakeTorque = motor * 0.6f;

    }

    void ApplySteering()
    {
        float steering = maxSteeringAngle * -steeringInput;

        // Aplica rotação nas rodas da frente para virar a empilhadeira
        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;
    }

    /// /////////////////////////////////////////////////////////////////////////////////////clone transform mesh

    void UpdateWheelPositions()
    {
        UpdateWheelPosition(frontLeftWheel, frontLeftWheelTransform);
        UpdateWheelPosition(frontRightWheel, frontRightWheelTransform);
        UpdateWheelPosition(rearLeftWheel, rearLeftWheelTransform);
        UpdateWheelPosition(rearRightWheel, rearRightWheelTransform);
    }

    void UpdateWheelPosition(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion quat;
        col.GetWorldPose(out pos, out quat);

        trans.position = pos;
        trans.rotation = quat;
    }
}