using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionDeUsuarios : MonoBehaviour
{
    [Header("Campos para registro")]
    public TMP_InputField[] campos_registro;
   
    [Header("Campos Inicio")]
    public TMP_InputField[] campos_inicio;

    [Header("Campos Alertas")]
    public string[] texto_alertas;

    public GameObject panel_Alertas;
    public TMP_Text alerta_Actual;

    public void RegistrarUsuario()
    {
        for (int i = 0; i  < campos_registro.Length; i++)
        {
            //Primer Alerta campos Vacios.
            if (string.IsNullOrEmpty(campos_registro[i].text))
            {
                panel_Alertas.SetActive(true);
                alerta_Actual.text = texto_alertas[0];
            }
            else
            {
                if (Manager.Instance.usuarios.Contains(campos_registro[0].text))
                {
                    panel_Alertas.SetActive(true);
                    alerta_Actual.text = texto_alertas[1];
                }
                else
                {
                    Manager.Instance.usuarios.Add(campos_registro[0].text);
                    Manager.Instance.nombre_usuarioActual = campos_registro[0].text;
                    Manager.Instance.correo_usuarioActual = campos_registro[1].text;
                    Manager.Instance.contraseña_usuarioActual = campos_registro[2].text;

                    ChangueScene changueScene = FindAnyObjectByType<ChangueScene>();
                    changueScene.cambioEscena("Menu_App_Juego");
                }
            }

        }
    }

    public void IniciarSesion()
    {
        for(int i = 0; i < campos_inicio.Length; i++)
        {
            if (string.IsNullOrEmpty(campos_inicio[i].text))
            {
                panel_Alertas.SetActive(true) ;
                alerta_Actual.text = texto_alertas[0];
            }
            else
            {
                if (Manager.Instance.usuarios.Contains(campos_inicio[0].text))
                {
                    Manager.Instance.usuarios.Add(campos_inicio[0].text);
                    Manager.Instance.nombre_usuarioActual = campos_inicio[0].text;
                    Manager.Instance.contraseña_usuarioActual = campos_inicio[1].text;

                    ChangueScene changueScene = FindAnyObjectByType<ChangueScene>();
                    changueScene.cambioEscena("Menu_App_Juego");
                }
                else
                {
                    panel_Alertas.SetActive(true);
                    alerta_Actual.text = texto_alertas[2];

                }
            }
        }
    }
}
