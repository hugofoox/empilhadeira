using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class fotoProjeto : MonoBehaviour
{
    string _nome;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _nome = Random.Range(0, 1000) + "-foto.png";
            ScreenCapture.CaptureScreenshot(_nome);
            Debug.Log("Foto salva: "+ _nome);

        }        
    }
}
