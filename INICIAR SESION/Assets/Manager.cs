using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public string nombre_usuarioActual;
    public string correo_usuarioActual;
    public string contraseña_usuarioActual;

    public List<string> usuarios = new List<string>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
