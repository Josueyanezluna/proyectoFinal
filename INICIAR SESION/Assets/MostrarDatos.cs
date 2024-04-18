using UnityEngine;
using TMPro;

public class DisplayInputText : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI displayText;

    // Método para actualizar el texto mostrado cuando se presiona un botón
    public void UpdateDisplayText()
    {
        string textToShow = inputField.text;
        displayText.text = textToShow;

        GestionDeUsuarios usuarios = new GestionDeUsuarios();
        displayText.text = usuarios.campos_inicio.ToString();
    }
}
