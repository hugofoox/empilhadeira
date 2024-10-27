using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sistemaSetas : MonoBehaviour
{
    Transform _player;

    void Start()
    {
        // PROCURAR O PLAYER NA CENA.
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // FICAR SEMPRE OLHANDO NA DIREÇÃO DO PLAYER.
        transform.LookAt(_player);
    }
}
