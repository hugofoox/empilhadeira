using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alternarCamera : MonoBehaviour
{
    public Camera[] _cameras;
    public int _id = 0;

    void Start()
    {
        _cameras = GameObject.FindObjectsOfType<Camera>();
        for (int i = 0; i < _cameras.Length; i++)
        {
            if(_cameras[i].CompareTag("MainCamera"))
            {
                _cameras[i].enabled = true;
                _id = i;
            }
            else
            {
                _cameras[i].enabled = false;
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _id++;
        }
        if (_id >= _cameras.Length)
        {
            _id = 0;
        }

        for (int i = 0; i < _cameras.Length; i++)
        {
            if (i == _id)
            {
                _cameras[i].enabled = true;
            }
            else
            {
                _cameras[i].enabled = false;
            }
        }

    }
}
