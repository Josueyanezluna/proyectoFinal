using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangueScene : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void IniciarSesion()
    {
        SceneManager.LoadScene(1);
    }
    public void CrearCuenta()
    {
        SceneManager.LoadScene(2);
    }
    public void MenuAppJuego()
    {
        SceneManager.LoadScene(3);
    }
    public void Juego()
    {
        SceneManager.LoadScene(4);
    }
    public void Tienda()
    {
        SceneManager.LoadScene(5);
    }
    public void Usuario()
    {
        SceneManager.LoadScene(6);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void cambioEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
