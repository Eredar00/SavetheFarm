using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoCasilla{
        Bloqueado,
        Tierra_Seca,
        Tierra_Mojada,
        Arado_Seca,
        Arado_Mojado,
        Plantado_Seca,
        Plantado_Mojado,
        Cultivado_Seca,
        Cultivado_Mojado,
        Cosecha_Seca,
        Cosecha_Mojado
    }

public class Casilla : MonoBehaviour{
    
    private GameObject _SeleccionIncorrecta, _SeleccionNoPE, _Seleccion;
    [SerializeField] private TipoCasilla _TipoCasilla;
    private Sprite[] _ImagenesCasilla;
    private BoxCollider2D _Collider2D;
    public int _PosX, _PosY;
    public Casilla _Casilla_Arriba, _Casilla_Abajo, _Casilla_Derecha, _Casilla_Izquierda;
    private Planta _Planta;
    private Cosecha _Cosecha;
    
    private void Start() {
        _SeleccionIncorrecta = transform.Find("CruzRoja").gameObject;
        _SeleccionNoPE = transform.Find("CruzNegra").gameObject;
        _Seleccion = transform.Find("Seleccion").gameObject;
        _ImagenesCasilla = ImagenesManager.iMan.GetImagenesCasilla();
        _Collider2D = GetComponent<BoxCollider2D>();
        _Planta = GetComponentInChildren<Planta>();
        _Cosecha = GetComponentInChildren<Cosecha>();
    }
    
    public void SetCasillasLados(){
        SetCasilla_Arriba();
        SetCasilla_Abajo();
        SetCasilla_Izquierda();
        SetCasilla_Derecha();
    }

    public Casilla GetCasilla_Arriba(){return _Casilla_Arriba;}
    public void SetCasilla_Arriba(){_Casilla_Arriba = GridManager.gridManager.GetTileAtPosition(new Vector2(_PosX, _PosY + 1));}

    public Casilla GetCasilla_Abajo(){return _Casilla_Abajo;}
    public void SetCasilla_Abajo(){_Casilla_Abajo = GridManager.gridManager.GetTileAtPosition(new Vector2(_PosX, _PosY - 1));}

    public Casilla GetCasilla_Izquierda(){return _Casilla_Izquierda;}
    public void SetCasilla_Izquierda(){_Casilla_Izquierda = GridManager.gridManager.GetTileAtPosition(new Vector2(_PosX - 1, _PosY));}

    public Casilla GetCasilla_Derecha(){return _Casilla_Derecha;}
    public void SetCasilla_Derecha(){_Casilla_Derecha = GridManager.gridManager.GetTileAtPosition(new Vector2(_PosX + 1, _PosY));}

    public void SetPosicionCasilla(int x, int y){
        _PosX = x;
        _PosY = y;
    }

    private void SetImagenSprite(int numero){ transform.GetComponent<SpriteRenderer>().sprite = _ImagenesCasilla[numero]; }
    
    public void ActivarCollider(){ _Collider2D.enabled = true; }

    public Planta GetPlanta(){ return _Planta; }
    public Cosecha GetCosecha() { return _Cosecha; }
    
    public TipoCasilla GetTipoCasilla(){ return _TipoCasilla; }
    
    public void SetPreTipoCasilla(TipoCasilla Nuevo_TipoCasilla){
        _TipoCasilla = Nuevo_TipoCasilla;
    }
    
    public void SetTipoCasilla(TipoCasilla Nuevo_TipoCasilla){
        _TipoCasilla = Nuevo_TipoCasilla;
        
        switch (_TipoCasilla){
            case TipoCasilla.Bloqueado:
                SetImagenSprite(0);
                break;
            case TipoCasilla.Tierra_Seca:
                SetImagenSprite(1);
                break;
            case TipoCasilla.Tierra_Mojada:
                SetImagenSprite(2);
                break;
            case TipoCasilla.Arado_Seca:
                SetImagenSprite(3);
                break;
            case TipoCasilla.Arado_Mojado:
                SetImagenSprite(4);
                break;
            case TipoCasilla.Plantado_Seca:
                SetImagenSprite(5);
                break;
            case TipoCasilla.Plantado_Mojado:
                SetImagenSprite(6);
                break;
            case TipoCasilla.Cultivado_Seca:
                SetImagenSprite(1);
                break;
            case TipoCasilla.Cultivado_Mojado:
                SetImagenSprite(2);
                break;
            case TipoCasilla.Cosecha_Seca:
                SetImagenSprite(1);
                break;
            case TipoCasilla.Cosecha_Mojado:
                SetImagenSprite(2);
                break;
            default:
                break;
        }  
    }

    public void QuitarFocusCasilla(){
        _SeleccionIncorrecta.SetActive(false);
        _SeleccionNoPE.SetActive(false);
        _Seleccion.SetActive(false);
    }

    public void QuitarTodosLosFocus(){
        QuitarFocusCasilla();
        if(_Casilla_Derecha != null) _Casilla_Derecha.QuitarFocusCasilla();
        if(_Casilla_Izquierda != null) _Casilla_Izquierda.QuitarFocusCasilla();
        if(_Casilla_Arriba != null) {
            _Casilla_Arriba.QuitarFocusCasilla();
            if(_Casilla_Arriba._Casilla_Derecha != null) _Casilla_Arriba._Casilla_Derecha.QuitarFocusCasilla();
            if(_Casilla_Arriba._Casilla_Izquierda != null) _Casilla_Arriba._Casilla_Izquierda.QuitarFocusCasilla();
        }
        if(_Casilla_Abajo != null){
            _Casilla_Abajo.QuitarFocusCasilla();
            if(_Casilla_Abajo._Casilla_Derecha != null) _Casilla_Abajo._Casilla_Derecha.QuitarFocusCasilla();
            if(_Casilla_Abajo._Casilla_Izquierda != null) _Casilla_Abajo._Casilla_Izquierda.QuitarFocusCasilla();
        }
    }

    public void CambiarFocusCasilla(){
        string resultado = GameManager.gameManager.ComprobarQueHighlightProcede(this, GetTipoCasilla());
        if(resultado == "Roja"){
            _SeleccionIncorrecta.SetActive(true);
        }else if(resultado == "Negra"){
            _SeleccionNoPE.SetActive(true);
        }else if(resultado == "Seleccion"){
            _Seleccion.SetActive(true);
        }
    }

    public void CambiarTodosLosFocus(Casilla casillaCentral){

        if(casillaCentral.GetTipoCasilla() == TipoCasilla.Bloqueado) return;

        if(Casillas.casillas.getNumero() == 0) casillaCentral.CambiarFocusCasilla();
        
        if(Casillas.casillas.getNumero() == 1){
            casillaCentral.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Arriba != null) casillaCentral._Casilla_Arriba.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Abajo != null) casillaCentral._Casilla_Abajo.CambiarFocusCasilla();
        }

        if(Casillas.casillas.getNumero() == 2){
            casillaCentral.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Derecha != null) casillaCentral._Casilla_Derecha.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Izquierda != null) casillaCentral._Casilla_Izquierda.CambiarFocusCasilla(); 
        }

        if(Casillas.casillas.getNumero() == 3){
            casillaCentral.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Derecha != null) casillaCentral._Casilla_Derecha.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Izquierda != null) casillaCentral._Casilla_Izquierda.CambiarFocusCasilla(); 
            if(casillaCentral._Casilla_Arriba != null) casillaCentral._Casilla_Arriba.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Abajo != null) casillaCentral._Casilla_Abajo.CambiarFocusCasilla();
        }

        if(Casillas.casillas.getNumero() == 4){
            casillaCentral.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Arriba != null) {
                    casillaCentral._Casilla_Arriba.CambiarFocusCasilla();
                    if(casillaCentral._Casilla_Arriba._Casilla_Derecha != null) casillaCentral._Casilla_Arriba._Casilla_Derecha.CambiarFocusCasilla();
                    if(casillaCentral._Casilla_Arriba._Casilla_Izquierda != null) casillaCentral._Casilla_Arriba._Casilla_Izquierda.CambiarFocusCasilla();
                }
            if(casillaCentral._Casilla_Abajo != null){
                casillaCentral._Casilla_Abajo.CambiarFocusCasilla();
                if(casillaCentral._Casilla_Abajo._Casilla_Derecha != null) casillaCentral._Casilla_Abajo._Casilla_Derecha.CambiarFocusCasilla();
                if(casillaCentral._Casilla_Abajo._Casilla_Izquierda != null) casillaCentral._Casilla_Abajo._Casilla_Izquierda.CambiarFocusCasilla();
            }
            if(casillaCentral._Casilla_Derecha != null) casillaCentral._Casilla_Derecha.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Izquierda != null) casillaCentral._Casilla_Izquierda.CambiarFocusCasilla(); 
        }        
    }

    private void OnMouseEnter(){
        if(GameManager.gameManager.pausa == true || GameManager.gameManager.canvas == true) return;
        GameManager.gameManager.CambiarTileFocused(this);
        CambiarTodosLosFocus(this);
        
        if(GameManager.gameManager.NumeroHerramienta == 6){
            GameManager.gameManager.GetTaller().ActivarLupa(true);
        }

    }

    private void OnMouseExit() {
        GameManager.gameManager.CambiarTileFocused(null);
        GameManager.gameManager.GetTaller().ActivarLupa(false);
        QuitarTodosLosFocus();
    }

    private void OnMouseDown() {
        if(GameManager.gameManager.pausa == true || GameManager.gameManager.canvas == true) return;

        if(Casillas.casillas.getNumero() == 0){GameManager.gameManager.EjecutarAccionSobreCasilla(this);}  

        if(Casillas.casillas.getNumero() == 1){
            GameManager.gameManager.EjecutarAccionSobreCasilla(this);
            if(_Casilla_Arriba != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Arriba);
            if(_Casilla_Abajo != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Abajo);
        } 

        if(Casillas.casillas.getNumero() == 2){
            GameManager.gameManager.EjecutarAccionSobreCasilla(this);
            if(_Casilla_Derecha != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Derecha);
            if(_Casilla_Izquierda != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Izquierda);
        }

        if(Casillas.casillas.getNumero() == 3){
            GameManager.gameManager.EjecutarAccionSobreCasilla(this);
            if(_Casilla_Derecha != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Derecha);
            if(_Casilla_Izquierda != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Izquierda);
            if(_Casilla_Arriba != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Arriba);
            if(_Casilla_Abajo != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Abajo);
        }

        if(Casillas.casillas.getNumero() == 4){
            GameManager.gameManager.EjecutarAccionSobreCasilla(this);
            if(_Casilla_Derecha != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Derecha);
            if(_Casilla_Izquierda != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Izquierda);
             if(_Casilla_Arriba != null) {
                GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Arriba);
                if(_Casilla_Arriba._Casilla_Derecha != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Arriba._Casilla_Derecha);
                if(_Casilla_Arriba._Casilla_Izquierda != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Arriba._Casilla_Izquierda);
            }
            if(_Casilla_Abajo != null){
                GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Abajo);
                if(_Casilla_Abajo._Casilla_Derecha != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Abajo._Casilla_Derecha);
                if(_Casilla_Abajo._Casilla_Izquierda != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Abajo._Casilla_Izquierda);
            }
        }

        QuitarTodosLosFocus();
        CambiarTodosLosFocus(this);
    }

}
