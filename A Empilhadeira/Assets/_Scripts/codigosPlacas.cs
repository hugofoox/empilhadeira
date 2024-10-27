using HighlightPlus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class codigosPlacas : MonoBehaviour
{
    float randomLetra;
    string _letra;
    float _numero;
    [Multiline(3)]
    public string _codigo;
    TextMeshProUGUI _txtCodigo;

    void Start()
    {
        _txtCodigo = transform.Find("Placa").Find("Canvas").Find("Text (TMP)").GetComponent<TextMeshProUGUI>();

        randomLetra = Random.Range(0, 5);
        switch (randomLetra)
        {
            case 0:
                _letra = "A";
                break;
            case 1:
                _letra = "B";
                break;
            case 2:
                _letra = "C";
                break;
            case 3:
                _letra = "D";
                break;
            case 4:
                _letra = "E";
                break;
        }
        _numero = Random.Range(100, 1000);

        _codigo = "CODE\n#" + _letra + _numero;

        _txtCodigo.text = _codigo;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            GetComponent<HighlightEffect>().enabled = true;
            transform.Find("LocalSeta").transform.Find("setas").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            GetComponent<HighlightEffect>().enabled = false;
            transform.Find("LocalSeta").transform.Find("setas").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
