using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class ImagePicker : MonoBehaviour
{
    public Image imageToChange;

    // M�todo para solicitar permiso de lectura de almacenamiento externo en Android
    IEnumerator RequestStoragePermission()
    {
        // Solicitar permiso de lectura de almacenamiento externo en Android
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);

            // Esperar hasta que se conceda o deniegue el permiso
            while (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            {
                yield return null;
            }
        }
    }

    // M�todo para abrir la galer�a y seleccionar una imagen
    public void PickImageFromGallery()
    {
        StartCoroutine(OpenGallery());
    }

    IEnumerator OpenGallery()
    {
        // Solicitar permiso de lectura de almacenamiento externo en Android
        yield return StartCoroutine(RequestStoragePermission());

        // Abrir la galer�a
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // Cargar la imagen seleccionada como Sprite
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

                // Cambiar el Sprite de la imagen por el nuevo Sprite cargado desde la galer�a
                imageToChange.sprite = sprite;
            }
        }, "Seleccionar imagen", "image/*");

        // Manejar casos en los que se niega el permiso de la galer�a
        if (permission == NativeGallery.Permission.Denied)
        {
            Debug.Log("Permiso de la galer�a denegado");
        }
        else if (permission == NativeGallery.Permission.ShouldAsk)
        {
            Debug.Log("Permiso de la galer�a denegado de forma permanente por el usuario");
        }
    }
}
