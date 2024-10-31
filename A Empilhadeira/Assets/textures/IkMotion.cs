using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkMotion : MonoBehaviour

{
    public Transform targetTransform;   // Transform que ser� clonado
    public Transform ikTarget;          // Transform de destino do IK

    private void Update()
    {
        if (targetTransform != null && ikTarget != null)
        {
            // Definindo diretamente a posi��o e a rota��o do IK para coincidir com o targetTransform
            ikTarget.position = targetTransform.position;
            ikTarget.rotation = targetTransform.rotation;
        }
    }
}