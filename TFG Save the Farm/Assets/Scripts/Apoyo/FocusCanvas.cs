using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FocusCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData){
        GameManager.gameManager.canvas = true;
    }

    public void OnPointerExit(PointerEventData eventData){
        GameManager.gameManager.canvas = false;
    }


}
