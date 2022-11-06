using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CerrarCanvas : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler{
    
    [SerializeField] GameObject canvasParaCerrar;
    private Sprite boton_01, boton_02;


    private void Start() {
        boton_01 = Resources.Load<Sprite>("Sprites/Botones/BotonCerrar_01");
        boton_02 = Resources.Load<Sprite>("Sprites/Botones/BotonCerrar_02");
    }

    public void OnPointerDown(PointerEventData eventData){
        canvasParaCerrar.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = boton_02;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = boton_01;
    }
}
