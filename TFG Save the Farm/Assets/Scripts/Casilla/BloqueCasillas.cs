using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloqueCasillas : MonoBehaviour{

    public int _ID;
    private Vector2 _Posicion;
    private float _Precio;
    private Text _TextoPrecio;
    private GameObject _ObjetoCandado;
    private SpriteRenderer _SpriteRenderer;

    public int ID { get => _ID; set => _ID = value; }

    private void Awake() {
        _ObjetoCandado = transform.Find("Candado").gameObject;
        _SpriteRenderer = _ObjetoCandado.GetComponent<SpriteRenderer>();
        _TextoPrecio = transform.GetComponentInChildren<Text>();
    }

    private void Start() {
        _TextoPrecio.text = _Precio.ToString()+ " $";
    }

    private void OnMouseEnter() {
        if(GameManager.gameManager.pausa == true) return;
        if(GameManager.gameManager.canvas == true){OnMouseExit(); return;}
        
        if(Dinero.dinero.ObtenerDinero() >= _Precio){
            _SpriteRenderer.color = Color.green;
        }else{
            _SpriteRenderer.color = Color.red;
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
            Destroy(this.gameObject);
            ConvertirCasillas();
            EstadoJuego.EdJ._Bloques[_ID] = true;
        }
    }

    public void SetPrecio(float nuevoPrecio){
        _Precio = nuevoPrecio;
    }

    public void SetPosicion(int x, int y){
        _Posicion = new Vector2(x, y);
    }

    public void QuitarBloquesYaDesbloqueados(){
        Destroy(this.gameObject);

        Casilla casillaCentral = GridManager.gridManager.GetTileAtPosition(_Posicion);
        ActualizarCasillas(casillaCentral);
        ActualizarCasillas(casillaCentral.GetCasilla_Abajo());
        ActualizarCasillas(casillaCentral.GetCasilla_Izquierda());
        ActualizarCasillas(casillaCentral.GetCasilla_Derecha());
        ActualizarCasillas(casillaCentral.GetCasilla_Arriba());
        ActualizarCasillas(casillaCentral.GetCasilla_Abajo().GetCasilla_Izquierda());
        ActualizarCasillas(casillaCentral.GetCasilla_Abajo().GetCasilla_Derecha());
        ActualizarCasillas(casillaCentral.GetCasilla_Arriba().GetCasilla_Izquierda());
        ActualizarCasillas(casillaCentral.GetCasilla_Arriba().GetCasilla_Derecha());

        EstadoJuego.EdJ._Bloques[_ID] = true;
    }

    private void ConvertirCasillas(){
        Casilla casillaCentral = GridManager.gridManager.GetTileAtPosition(_Posicion);

        DesbloquearCasillas(casillaCentral);
        DesbloquearCasillas(casillaCentral.GetCasilla_Abajo());
        DesbloquearCasillas(casillaCentral.GetCasilla_Izquierda());
        DesbloquearCasillas(casillaCentral.GetCasilla_Derecha());
        DesbloquearCasillas(casillaCentral.GetCasilla_Arriba());
        DesbloquearCasillas(casillaCentral.GetCasilla_Abajo().GetCasilla_Izquierda());
        DesbloquearCasillas(casillaCentral.GetCasilla_Abajo().GetCasilla_Derecha());
        DesbloquearCasillas(casillaCentral.GetCasilla_Arriba().GetCasilla_Izquierda());
        DesbloquearCasillas(casillaCentral.GetCasilla_Arriba().GetCasilla_Derecha());
    }

    private void ActualizarCasillas(Casilla casilla){
        casilla.TipoCasilla = TipoCasilla.Tierra_Seca;
        casilla.SetImagenSprite(1);
        casilla.ActivarCollider();
    }

    private void DesbloquearCasillas(Casilla casilla){
        casilla.SetTipoCasilla(TipoCasilla.Tierra_Seca);
        casilla.ActivarCollider();
    }
}
