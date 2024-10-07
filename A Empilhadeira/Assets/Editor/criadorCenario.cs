using Packages.Rider.Editor.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class criadorCenario : EditorWindow
{
    float _quantMover = 1.0f;

    GameObject _prefabParede;
    GameObject _prefabPorta;
    GameObject _prefabJanela;
    GameObject _prefabColuna;
    GameObject _prefabEscada;
    GameObject _prefabChao;

    Vector2 scrollPos;

    GUIStyle _textRed;

    bool _scene01 = true;
    bool _scene02 = true;
    bool _scene03 = true;
    bool _scene04 = true;
    bool _scene05 = true;

    [MenuItem("Window/EditorCena")]
    public static void ShowWindows()
    {
        GetWindow<criadorCenario>("Editor");
    }


    private void OnGUI()
    {
        _EstiloTextRed();

        GUILayout.Label("@EDITOR DE CENA (HUGO NASCIMENTO) >>>", EditorStyles.miniLabel);

        if(Selection.gameObjects.Length == 1)
        {
            GUILayout.Label("NOME | " + Selection.gameObjects[0].name, EditorStyles.miniLabel);
            GUILayout.Label("POSIÇÃO | " + Selection.gameObjects[0].transform.position, EditorStyles.miniLabel);
            GUILayout.Label("ROTAÇÃO | " + Selection.gameObjects[0].transform.eulerAngles, EditorStyles.miniLabel);
        }

        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("EIXO PADRÃO (Y)", GUILayout.Height(30.0f)))
        {
            SceneView.lastActiveSceneView.rotation = Quaternion.Euler(90, 0, 0);
        }

        if (GUILayout.Button("EIXO VIEW", GUILayout.Height(30.0f)))
        {
            SceneView.lastActiveSceneView.rotation = Quaternion.Euler(40, -30, 0);
        }

        if (GUILayout.Button("teste", GUILayout.Height(30.0f)))
        {
            Debug.Log(SceneView.lastActiveSceneView.rotation.eulerAngles);
        }
        GUILayout.EndHorizontal();

        GUILayout.Label("GRID (" + _quantMover + ") >>>", _textRed);
        GUILayout.BeginHorizontal("box", GUILayout.Height(20.0f));

        if (GUILayout.Button("-"))
        {
            _quantMover -= 1;
        }
        if (GUILayout.Button("0.001"))
        {
            _quantMover = 0.001f;
        }
        if (GUILayout.Button("0.5"))
        {
            _quantMover = 0.5f;
        }
        if (GUILayout.Button("1"))
        {
            _quantMover = 1;
        }
        if (GUILayout.Button("+"))
        {
            _quantMover += 1;
        }
        GUILayout.EndHorizontal();


        _Mover(); _Girar(); _Açao();


        GUILayout.Label("OBJETOS >>>", _textRed);

        
        GUILayout.BeginHorizontal("box", GUILayout.Height(105.0f));
            scrollPos = GUILayout.BeginScrollView(scrollPos);
                GUILayout.BeginHorizontal("box");
                _pParede(); _pPorta(); _pJanela(); _pColuna(); _pEscada(); _pChao();
                        GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            GUILayout.EndScrollView();
        GUILayout.EndHorizontal();
        
        
    }



    void _pParede()
    {
        // Carregar imagem do prefab
        Texture2D _iconePrefab = AssetPreview.GetAssetPreview(_prefabParede);

        // Criar botão com a imagem do prefab
        if (GUILayout.Button(_iconePrefab, GUILayout.Width(70), GUILayout.Height(70)))
        {
            if (_prefabParede == null)
            {
                Debug.LogError("Prefab não encontrado.");
                return;
            }

            GameObject _obj = Instantiate(_prefabParede);
            if(Selection.objects.Length == 0)
            {
                _obj.transform.position = new Vector3(0, 0, 0);
                _obj.transform.rotation = Quaternion.identity;
            }
            else
            {
                _obj.transform.position =  Selection.objects[0].GetComponent<Transform>().position;
                _obj.transform.rotation =  Selection.objects[0].GetComponent<Transform>().rotation;
            }
            Selection.activeGameObject = _obj;

        }

        // Selecionar o prefab
        _prefabParede = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Cenario/Parede.prefab");
    }

    void _pPorta()
    {
        // Carregar imagem do prefab
        Texture2D _iconePrefab = AssetPreview.GetAssetPreview(_prefabPorta);

        // Selecionar o prefab
        _prefabPorta = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Cenario/Porta.prefab");

        // Criar botão com a imagem do prefab
        if (GUILayout.Button(_iconePrefab, GUILayout.Width(70), GUILayout.Height(70)))
        {
            if (_prefabPorta == null)
            {
                Debug.LogError("Prefab não encontrado.");
                return;
            }

            GameObject _obj = Instantiate(_prefabPorta);
            if (Selection.objects.Length == 0)
            {
                _obj.transform.position = new Vector3(0, 0, 0);
                _obj.transform.rotation = Quaternion.identity;
            }
            else
            {
                _obj.transform.position = Selection.objects[0].GetComponent<Transform>().position;
                _obj.transform.rotation = Selection.objects[0].GetComponent<Transform>().rotation;
            }
            Selection.activeGameObject = _obj;
        }
    }

    void _pJanela()
    {
        // Carregar imagem do prefab
        Texture2D _iconePrefab = AssetPreview.GetAssetPreview(_prefabJanela);

        // Selecionar o prefab
        _prefabJanela = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Cenario/Janela.prefab");

        // Criar botão com a imagem do prefab
        if (GUILayout.Button(_iconePrefab, GUILayout.Width(70), GUILayout.Height(70)))
        {
            if (_prefabJanela == null)
            {
                Debug.LogError("Prefab não encontrado.");
                return;
            }

            GameObject _obj = Instantiate(_prefabJanela);
            if (Selection.objects.Length == 0)
            {
                _obj.transform.position = new Vector3(0, 0, 0);
                _obj.transform.rotation = Quaternion.identity;
            }
            else
            {
                _obj.transform.position = Selection.objects[0].GetComponent<Transform>().position;
                _obj.transform.rotation = Selection.objects[0].GetComponent<Transform>().rotation;
            }
            Selection.activeGameObject = _obj;
        }
    }

    void _pColuna()
    {
        // Carregar imagem do prefab
        Texture2D _iconePrefab = AssetPreview.GetAssetPreview(_prefabColuna);

        // Selecionar o prefab
        _prefabColuna = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/cenario/Coluna.prefab");

        // Criar botão com a imagem do prefab
        if (GUILayout.Button(_iconePrefab, GUILayout.Width(70), GUILayout.Height(70)))
        {
            if (_prefabColuna == null)
            {
                Debug.LogError("Prefab não encontrado.");
                return;
            }

            GameObject _obj = Instantiate(_prefabColuna);
            if (Selection.objects.Length == 0)
            {
                _obj.transform.position = new Vector3(0, 0, 0);
                _obj.transform.rotation = Quaternion.identity;
            }
            else
            {
                _obj.transform.position = Selection.objects[0].GetComponent<Transform>().position;
                _obj.transform.rotation = Selection.objects[0].GetComponent<Transform>().rotation;
            }
            Selection.activeGameObject = _obj;
        }
    }



    void _pEscada()
    {
        // Carregar imagem do prefab
        Texture2D _iconePrefab = AssetPreview.GetAssetPreview(_prefabEscada);

        // Selecionar o prefab
        _prefabEscada = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/cenario/Escada.prefab");

        // Criar botão com a imagem do prefab
        if (GUILayout.Button(_iconePrefab, GUILayout.Width(70), GUILayout.Height(70)))
        {
            if (_prefabEscada == null)
            {
                Debug.LogError("Prefab não encontrado.");
                return;
            }

            GameObject _obj = Instantiate(_prefabEscada);
            if (Selection.objects.Length == 0)
            {
                _obj.transform.position = new Vector3(0, 0, 0);
                _obj.transform.rotation = Quaternion.identity;
            }
            else
            {
                _obj.transform.position = Selection.objects[0].GetComponent<Transform>().position;
                _obj.transform.rotation = Selection.objects[0].GetComponent<Transform>().rotation;
            }
            Selection.activeGameObject = _obj;
        }
    }


    void _pChao()
    {
        // Carregar imagem do prefab
        Texture2D _iconePrefab = AssetPreview.GetAssetPreview(_prefabChao);

        // Selecionar o prefab
        _prefabChao = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/cenario/Chão.prefab");

        // Criar botão com a imagem do prefab
        if (GUILayout.Button(_iconePrefab, GUILayout.Width(70), GUILayout.Height(70)))
        {
            if (_prefabChao == null)
            {
                Debug.LogError("Prefab não encontrado.");
                return;
            }

            GameObject _obj = Instantiate(_prefabChao);
            if (Selection.objects.Length == 0)
            {
                _obj.transform.position = new Vector3(0, 0, 0);
                _obj.transform.rotation = Quaternion.identity;
            }
            else
            {
                _obj.transform.position = Selection.objects[0].GetComponent<Transform>().position;
                _obj.transform.rotation = Selection.objects[0].GetComponent<Transform>().rotation;
            }
            Selection.activeGameObject = _obj;
        }
    }



    void _Mover()
    {
        GUILayout.Label("CONTROLE >>>", _textRed);
        GUILayout.BeginHorizontal("box");

        GUILayout.BeginVertical("box");
        GUILayout.Label("ANDAR:", EditorStyles.boldLabel);
        if (GUILayout.Button("+Y"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.position += new Vector3(0, _quantMover, 0);
            }
        }
        if (GUILayout.Button("-Y"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.position += new Vector3(0, -_quantMover, 0);
            }
        }
        GUILayout.EndVertical();





        GUILayout.BeginVertical("box");
        GUILayout.Label("MODER:", EditorStyles.boldLabel);
        if (GUILayout.Button("+Z"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.position += new Vector3(0, 0, _quantMover);
            }
        }


        GUILayout.BeginHorizontal();
        if (GUILayout.Button("-X"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.position += new Vector3(-_quantMover, 0, 0);
            }
        }
        if (GUILayout.Button("+X"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.position += new Vector3(_quantMover, 0, 0);
            }
        }
        GUILayout.EndHorizontal();





        if (GUILayout.Button("-Z"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.position += new Vector3(0, 0, -_quantMover);
            }
        }
        GUILayout.EndVertical();


        GUILayout.BeginVertical("box");
        GUILayout.Label("ZERO:", EditorStyles.boldLabel);
        if (GUILayout.Button("ZERAR"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.position = new Vector3(0, 0, 0);
            }
        }
        GUILayout.EndVertical();


        GUILayout.EndHorizontal();

    }

    void _Girar()
    {
        GUILayout.Label("GIRAR >>>", _textRed);
        GUILayout.BeginHorizontal("box");

        GUILayout.BeginVertical("box");
        GUILayout.Label("X:", EditorStyles.boldLabel);
        if (GUILayout.Button("-X"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.eulerAngles += new Vector3(-90, 0, 0);
            }
        }
        if (GUILayout.Button("+X"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.eulerAngles += new Vector3(90, 0, 0);
            }
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        GUILayout.Label("Y:", EditorStyles.boldLabel);
        if (GUILayout.Button("-Y"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.eulerAngles += new Vector3(0, -90, 0);
            }
        }
        if (GUILayout.Button("+Y"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.eulerAngles += new Vector3(0, 90, 0);
            }
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        GUILayout.Label("Z:", EditorStyles.boldLabel);
        if (GUILayout.Button("-Z"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.eulerAngles += new Vector3(0, 0, -90);
            }
        }
        if (GUILayout.Button("+Z"))
        {
            foreach (GameObject _obj in Selection.gameObjects)
            {
                _obj.transform.eulerAngles += new Vector3(0, 0, 90);
            }
        }
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();

    }

    void _Açao()
    {
        GUILayout.Label("AÇÃO >>>", _textRed);

        GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("DUPLICAR"))
            {
                foreach (GameObject _obj in Selection.gameObjects)
                {
                    Instantiate(_obj);
                }
            }
            if (GUILayout.Button("DELETAR"))
            {
                foreach (GameObject _obj in Selection.gameObjects)
                {
                    DestroyImmediate(_obj);
                }
            }
        GUILayout.EndHorizontal();



        GUILayout.Label("OCULTAR/APARECER >>>", _textRed);
        
        GUILayout.BeginHorizontal();

            if (GUILayout.Button("A-1"))
            {
                _scene01 = !_scene01;

                foreach (GameObject _obj in GameObject.FindGameObjectsWithTag("Scene"))
                {
                    if(_obj.transform.position.y >= 0 && _obj.transform.position.y < 4)
                    {  
                        if (_scene01)
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = true;
                            if(_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = true;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = false;
                            if (_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = false;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = false;
                            }
                        }  
                    }
                }
            }

            if (GUILayout.Button("A-2"))
            {
                _scene02 = !_scene02;

                foreach (GameObject _obj in GameObject.FindGameObjectsWithTag("Scene"))
                {
                    if (_obj.transform.position.y >= 4 && _obj.transform.position.y < 8)
                    {
                        if (_scene02)
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = true;
                            if (_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = true;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = false;
                            if (_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = false;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = false;
                            }
                        }
                    }
                }
            }

            if (GUILayout.Button("A-3"))
            {
                _scene03 = !_scene03;

                foreach (GameObject _obj in GameObject.FindGameObjectsWithTag("Scene"))
                {
                    if (_obj.transform.position.y >= 8 && _obj.transform.position.y < 12)
                    {
                        if (_scene03)
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = true;
                            if (_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = true;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = false;
                            if (_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = false;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = false;
                            }
                        }
                    }
                }
            }

            if (GUILayout.Button("A-4"))
            {
                _scene04 = !_scene04;

                foreach (GameObject _obj in GameObject.FindGameObjectsWithTag("Scene"))
                {
                    if (_obj.transform.position.y >= 12 && _obj.transform.position.y < 16)
                    {
                        if (_scene04)
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = true;
                            if (_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = true;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = true;
                            }
                        }
                        else
                        {
                            _obj.GetComponent<MeshRenderer>().enabled = false;
                            if (_obj.GetComponent<BoxCollider>() != null)
                            {
                                _obj.GetComponent<BoxCollider>().enabled = false;
                            }
                            if (_obj.GetComponent<MeshCollider>() != null)
                            {
                                _obj.GetComponent<MeshCollider>().enabled = false;
                            }
                        }
                    }
                }
            }

            if (GUILayout.Button("A-5"))
        {
            _scene05 = !_scene05;

            foreach (GameObject _obj in GameObject.FindGameObjectsWithTag("Scene"))
            {
                if (_obj.transform.position.y >= 16 && _obj.transform.position.y < 20)
                {
                    if (_scene05)
                    {
                        _obj.GetComponent<MeshRenderer>().enabled = true;
                        if (_obj.GetComponent<BoxCollider>() != null)
                        {
                            _obj.GetComponent<BoxCollider>().enabled = true;
                        }
                        if (_obj.GetComponent<MeshCollider>() != null)
                        {
                            _obj.GetComponent<MeshCollider>().enabled = true;
                        }
                    }
                    else
                    {
                        _obj.GetComponent<MeshRenderer>().enabled = false;
                        if (_obj.GetComponent<BoxCollider>() != null)
                        {
                            _obj.GetComponent<BoxCollider>().enabled = false;
                        }
                        if (_obj.GetComponent<MeshCollider>() != null)
                        {
                            _obj.GetComponent<MeshCollider>().enabled = false;
                        }
                    }
                }
            }
        }

        GUILayout.EndHorizontal();

    }

    // ESTILO DE COMPONENTES...............................
    void _EstiloTextRed()
    {
        _textRed = new GUIStyle(GUI.skin.label);
        _textRed.normal.textColor = Color.red;
        _textRed.fontStyle = FontStyle.Bold;
    }
}