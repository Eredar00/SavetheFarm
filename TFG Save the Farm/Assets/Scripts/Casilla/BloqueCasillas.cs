using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloqueCasillas : MonoBehaviour
{
    private Vector2 _Posicion;
    private float _Precio;
    private Text _TextoPrecio;
    private GameObject _ObjetoCandado;

    private void Start() {
        _TextoPrecio = transform.GetComponentInChildren<Text>();
        _ObjetoCandado = transform.Find("Candado").gameObject;
        _TextoPrecio.text = _Precio.ToString()+ " $";
    }

    private void OnMouseEnter() {
        if(GameManager.gameManager.pausa == true) return;
        if(GameManager.gameManager.canvas == true){OnMouseExit(); return;}
        
        if(Dinero.dinero.ObtenerDinero() >= _Precio){
            _ObjetoCandado.GetComponent<SpriteRenderer>().color = Color.green;
        }else{
            _ObjetoCandado.GetComponent<SpriteRenderer>().color = Color.red;
        }       
        _TextoPrecio.enabled = true;
    }
    
    private void OnMouseExit() {
        _ObjetoCandado.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
        _TextoPrecio.enabled = false;
    }
    
    private void OnMouseDown() {
        if(GameManager.gameManager.pausa == true || GameManager.gameManager.canvas == true) return;
        if(Dinero.dinero.ObtenerDinero() >= _Precio){
            Dinero.dinero.VariarDinero(-_Precio);
            ConvertirCasillas();
            Destroy(this.gameObject);
        }
    }

    public void SetPrecio(float nuevoPrecio){
        _Precio = nuevoPrecio;
    }

    public void SetPosicion(int x, int y){
        _Posicion = new Vector2(x, y);
    }

    private void ConvertirCasillas(){
        Casilla casillaCentral = GridManager.gridManager.GetTileAtPosition(_Posicion);

        casillaCentral.SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Abajo().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Izquierda().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Derecha().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Arriba().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Abajo().GetCasilla_Izquierda().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Abajo().GetCasilla_Derecha().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Arriba().GetCasilla_Izquierda().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.GetCasilla_Arriba().GetCasilla_Derecha().SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casillaCentral.ActivarCollider();
        casillaCentral.GetCasilla_Abajo().ActivarCollider();
        casillaCentral.GetCasilla_Izquierda().ActivarCollider();
        casillaCentral.GetCasilla_Derecha().ActivarCollider();
        casillaCentral.GetCasilla_Arriba().ActivarCollider();
        casillaCentral.GetCasilla_Abajo().GetCasilla_Izquierda().ActivarCollider();
        casillaCentral.GetCasilla_Abajo().GetCasilla_Derecha().ActivarCollider();
        casillaCentral.GetCasilla_Arriba().GetCasilla_Izquierda().ActivarCollider();
        casillaCentral.GetCasilla_Arriba().GetCasilla_Derecha().ActivarCollider();
    }
}
