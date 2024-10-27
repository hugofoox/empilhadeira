using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class sistema : MonoBehaviour
{
    public GameObject[] _liberado;
    List <GameObject> _reservado = new List<GameObject>();

    public GameObject[] _prefabs;
    public Animator _porta;

    void Start()
    {
        StartCoroutine(enumLiberado(0));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
           StartCoroutine(Chegada());
        }
    }

    IEnumerator Chegada()
    {
        
        Debug.Log("ENCOMENDAS CHEGAND0.");
        StartCoroutine(enumLiberado(0));

        

        if (_liberado.Length > 3)
        {
            Debug.Log("ABRINDO A PORTA.");
            _porta.SetTrigger("Chegada");
            yield return new WaitForSeconds(2);

            Debug.Log("LIBERANDO ENCOMENDAS.");
            // SEPARAR UMA QUANTIDADE ALEATORIA DE TODOS QUE ESTÃO LIBERADO.
            for (int i = 0; i < Random.Range(3, _liberado.Length); i++)
            {
                _reservado.Add(_liberado[i]);
            }

            // ADICIONAR PRODUTOS NOS LOCAIS ESCOLHIDOS.
            foreach (GameObject obj in _reservado)
            {
                Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], obj.transform.position, obj.transform.rotation);
            }

            // LIMPAR AS RESERVAS.
            _reservado.Clear();

            StartCoroutine(enumLiberado(1));

        }
        else if (_liberado.Length < 4 && _liberado.Length > 0)
        {
            Debug.Log("ABRINDO A PORTA.");
            _porta.SetTrigger("Chegada");
            yield return new WaitForSeconds(2);

            Debug.Log("LIBERANDO ENCOMENDAS.");

            for (int i = 0; i < _liberado.Length; i++)
            {
                _reservado.Add(_liberado[i]);
            }

            // ADICIONAR PRODUTOS NOS LOCAIS ESCOLHIDOS.
            foreach (GameObject obj in _reservado)
            {
                Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], obj.transform.position, obj.transform.rotation);
            }

            // LIMPAR AS RESERVAS.
            _reservado.Clear();

            StartCoroutine(enumLiberado(1));
        }
        else
        {
            Debug.Log("NÃO TEM NENHUM ESPAÇO DISPONIVEL.");
        }
    }

    IEnumerator enumLiberado(int i)
    {
        yield return new WaitForSeconds(i);
        // VERIFICAR TODOS OS GAMEOBJECT QUE ESTÃO LIBERADO PARA ADICIONAR MERCADORIA.
        _liberado = GameObject.FindGameObjectsWithTag("Liberado");
    }

}
