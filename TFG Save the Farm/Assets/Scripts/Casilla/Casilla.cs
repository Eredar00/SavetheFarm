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
    public BoxCollider2D _Collider2D;
    public int _PosX, _PosY;
    public Casilla _Casilla_Arriba, _Casilla_Abajo, _Casilla_Derecha, _Casilla_Izquierda;
    private Planta _Planta;
    private Cosecha _Cosecha;

    public TipoCasilla TipoCasilla { get => _TipoCasilla; set => _TipoCasilla = value; }

    private void Awake() {
        _Collider2D = GetComponent<BoxCollider2D>();
        _Planta = GetComponentInChildren<Planta>();
        _Cosecha = GetComponentInChildren<Cosecha>();
    }

    private void Start() {
        _SeleccionIncorrecta = transform.Find("CruzRoja").gameObject;
        _SeleccionNoPE = transform.Find("CruzNegra").gameObject;
        _Seleccion = transform.Find("Seleccion").gameObject;
       
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

    public void SetImagenSprite(int numero){ 
        transform.GetComponent<SpriteRenderer>().sprite = ImagenesManager.iMan.GetImagenesCasilla()[numero]; 
    }
    
    public void ActivarCollider(){ _Collider2D.enabled = true; }

    public Planta GetPlanta(){ return _Planta; }
    public Cosecha GetCosecha() { return _Cosecha; }
    
    public TipoCasilla GetTipoCasilla(){ return TipoCasilla; }

    public int GetTipoCasillaNumerico(){ 
        switch (TipoCasilla){
            case TipoCasilla.Bloqueado:
                return 0;
            case TipoCasilla.Tierra_Seca:
                return 1;
            case TipoCasilla.Tierra_Mojada:
                return 2;
            case TipoCasilla.Arado_Seca:
                return 3;
            case TipoCasilla.Arado_Mojado:
                return 4;
            case TipoCasilla.Plantado_Seca:
                return 5;
            case TipoCasilla.Plantado_Mojado:
                return 6;
            case TipoCasilla.Cultivado_Seca:
                return 7;
            case TipoCasilla.Cultivado_Mojado:
                return 8;
            case TipoCasilla.Cosecha_Seca:
                return 9;
            case TipoCasilla.Cosecha_Mojado:
                return 10;
            default:
                return 99;
        }
    }

    public void SetTipoPlantaNumerico(int numero){ 
        _Planta.SetTipoVegetalNumerico(numero);
    }

    public void SetTipoCasilla(TipoCasilla Nuevo_TipoCasilla){
        TipoCasilla = Nuevo_TipoCasilla;
        EstadoJuego.EdJ._Casillero[_PosX * 9 + _PosY, 0] =  GetTipoCasillaNumerico();

        switch (TipoCasilla){
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

    public void SetTipoCasillaNumerico(int numero){        
        switch (numero){
            case 0:
                SetTipoCasilla(TipoCasilla.Bloqueado);
                break;
            case 1:
                SetTipoCasilla(TipoCasilla.Tierra_Seca);
                break;
            case 2:
                SetTipoCasilla(TipoCasilla.Tierra_Mojada);
                break;
            case 3:
                SetTipoCasilla(TipoCasilla.Arado_Seca);
                break;
            case 4:
                SetTipoCasilla(TipoCasilla.Arado_Mojado);
                break;
            case 5:
                SetTipoCasilla(TipoCasilla.Plantado_Seca);
                break;
            case 6:
                SetTipoCasilla(TipoCasilla.Plantado_Mojado);
                break;
            case 7:
                SetTipoCasilla(TipoCasilla.Cultivado_Seca);
                break;
            case 8:
                SetTipoCasilla(TipoCasilla.Cultivado_Mojado);
                break;
            case 9:
                SetTipoCasilla(TipoCasilla.Cosecha_Seca);
                break;
            case 10:
                SetTipoCasilla(TipoCasilla.Cosecha_Mojado);
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

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 0) casillaCentral.CambiarFocusCasilla();
        
        if(CasillasHerramienta.casillasHerramienta.getNumero() == 1){
            casillaCentral.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Arriba != null) casillaCentral._Casilla_Arriba.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Abajo != null) casillaCentral._Casilla_Abajo.CambiarFocusCasilla();
        }

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 2){
            casillaCentral.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Derecha != null) casillaCentral._Casilla_Derecha.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Izquierda != null) casillaCentral._Casilla_Izquierda.CambiarFocusCasilla(); 
        }

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 3){
            casillaCentral.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Derecha != null) casillaCentral._Casilla_Derecha.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Izquierda != null) casillaCentral._Casilla_Izquierda.CambiarFocusCasilla(); 
            if(casillaCentral._Casilla_Arriba != null) casillaCentral._Casilla_Arriba.CambiarFocusCasilla();
            if(casillaCentral._Casilla_Abajo != null) casillaCentral._Casilla_Abajo.CambiarFocusCasilla();
        }

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 4){
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

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 0){GameManager.gameManager.EjecutarAccionSobreCasilla(this);}  

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 1){
            GameManager.gameManager.EjecutarAccionSobreCasilla(this);
            if(_Casilla_Arriba != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Arriba);
            if(_Casilla_Abajo != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Abajo);
        } 

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 2){
            GameManager.gameManager.EjecutarAccionSobreCasilla(this);
            if(_Casilla_Derecha != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Derecha);
            if(_Casilla_Izquierda != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Izquierda);
        }

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 3){
            GameManager.gameManager.EjecutarAccionSobreCasilla(this);
            if(_Casilla_Derecha != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Derecha);
            if(_Casilla_Izquierda != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Izquierda);
            if(_Casilla_Arriba != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Arriba);
            if(_Casilla_Abajo != null) GameManager.gameManager.EjecutarAccionSobreCasilla(_Casilla_Abajo);
        }

        if(CasillasHerramienta.casillasHerramienta.getNumero() == 4){
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
