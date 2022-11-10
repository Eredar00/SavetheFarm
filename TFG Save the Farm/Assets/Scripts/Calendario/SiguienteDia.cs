using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SiguienteDia : MonoBehaviour
{

    public void AvanzarDia(){
        GameManager.gameManager.ChangeState(GameManager.GameState.CambiarDia);
    }

   
        
    
}
