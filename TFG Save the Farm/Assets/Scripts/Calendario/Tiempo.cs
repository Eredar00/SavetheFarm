using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tiempo : MonoBehaviour, IPointerDownHandler
{

    private GameObject mes, info_dias;

    private void Start() {
        mes = GameObject.Find("Mes");
        info_dias = GameObject.Find("Info_Dias");
    }

    public void OnPointerDown(PointerEventData eventData){
        // To be Implemented.
        //mes.SetActive(false);
        //info_dias.SetActive(true);
    }
}
