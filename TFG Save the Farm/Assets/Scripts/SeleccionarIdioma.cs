using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionarIdioma : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler{

    private Image imagenBoton;
    private string idioma;

    private void Start() {
        imagenBoton = GetComponent<Image>();
        imagenBoton.color = Color.gray;
        idioma = transform.name;
    }
    
    public void OnPointerClick(PointerEventData eventData){
        Opciones.opciones.Idioma = idioma;
        SceneManager.LoadScene("Portada");
    }

    public void OnPointerEnter(PointerEventData eventData){
        imagenBoton.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData){
        imagenBoton.color = Color.gray;
    }

}
