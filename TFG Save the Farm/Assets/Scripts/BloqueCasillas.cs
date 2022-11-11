using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloqueCasillas : MonoBehaviour
{
    [SerializeField] private Vector2 posicion;
    [SerializeField] private float precio;
    [SerializeField] private Text textoPrecio;
    [SerializeField] private GameObject candado;

    private void Start() {
        textoPrecio.text = precio.ToString()+ " $";
    }

    private void OnMouseEnter() {
        if(GameManager.gameManager.pausa == true) return;
        if(GameManager.gameManager.canvas == true){OnMouseExit(); return;}
        
        if(Dinero.dinero.ObtenerDinero() >= precio){
            candado.GetComponent<SpriteRenderer>().color = Color.green;
        }else{
            candado.GetComponent<SpriteRenderer>().color = Color.red;
        }       
        textoPrecio.enabled = true;
    }
    
    private void OnMouseExit() {
        candado.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
        textoPrecio.enabled = false;
    }
    
    private void OnMouseDown() {
        if(GameManager.gameManager.pausa == true || GameManager.gameManager.canvas == true) return;
        if(Dinero.dinero.ObtenerDinero() >= precio){
            Dinero.dinero.VariarDinero(-precio);
            ConvertirCasillas();
            Destroy(this.gameObject);
        }
        
    }

    public void PonerPrecio(float nuevoPrecio){
        precio = nuevoPrecio;
    }

    public void DarPosicion(int x, int y){
        posicion = new Vector2(x, y);
    }

    private void ConvertirCasillas(){
        Tile casillaCentral = GridManager.gridManager.GetTileAtPosition(posicion);

        casillaCentral.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileDown.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileLeft.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileRight.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileUp.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileDown.tileLeft.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileDown.tileRight.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileUp.tileLeft.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.tileUp.tileRight.ChangeTileState(TileState.Tierra_Seca);
        casillaCentral.ActivarCollider();
        casillaCentral.tileDown.ActivarCollider();
        casillaCentral.tileLeft.ActivarCollider();
        casillaCentral.tileRight.ActivarCollider();
        casillaCentral.tileUp.ActivarCollider();
        casillaCentral.tileDown.tileLeft.ActivarCollider();
        casillaCentral.tileDown.tileRight.ActivarCollider();
        casillaCentral.tileUp.tileLeft.ActivarCollider();
        casillaCentral.tileUp.tileRight.ActivarCollider();
    }
}
