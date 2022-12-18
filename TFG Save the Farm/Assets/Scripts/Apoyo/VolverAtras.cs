using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VolverAtras : MonoBehaviour, IPointerDownHandler{

    [SerializeField] GameObject canvasActual;
    [SerializeField] GameObject canvasAtras;

    public void OnPointerDown(PointerEventData eventData){
        canvasActual.SetActive(false);
        canvasAtras.SetActive(true);
    }
}
