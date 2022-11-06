using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SiguienteDia : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image siguienteDia;

    public void OnPointerDown(PointerEventData eventData){
        GameManager.gameManager.ChangeState(GameManager.GameState.CambiarDia);
    }
}
