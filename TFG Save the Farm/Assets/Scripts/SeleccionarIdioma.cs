using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionarIdioma : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler
{   
    private Image imagenBoton;
    [SerializeField] private bool disponible;
    [SerializeField] private GameObject textoNoDisponible;


    private void Start() {
        imagenBoton = GetComponent<Image>();
        imagenBoton.color = Color.gray;
    }
    
    public void OnPointerClick(PointerEventData eventData){
         if(disponible == true){
            SceneManager.LoadScene("Portada");
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        RevisarColorBoton();
    }

    public void OnPointerExit(PointerEventData eventData){
        imagenBoton.color = Color.gray;
        textoNoDisponible.SetActive(false);
    }

    private void RevisarColorBoton(){
        if(disponible == true){
            imagenBoton.color = Color.white;
        }else{
            textoNoDisponible.SetActive(true);
        }
    }
}
