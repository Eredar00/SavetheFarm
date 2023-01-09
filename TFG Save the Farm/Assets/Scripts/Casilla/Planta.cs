using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TipoVegetal{
        Ninguno,
        Tomate,
        Patata,
        Zanahoria,
        Naranja,
        Arroz,
        Trigo
    }

public class Planta : MonoBehaviour{

    private Sprite[] _ImagenesPlanta;
    private Casilla _Casilla;
    private Cosecha _Cosecha;
    public TipoVegetal _TipoVegetal;
    private SpriteRenderer _SpriteRenderer;
    [SerializeField] private int _PuntosCrecimiento = 0;
    [SerializeField] private int _PuntosCosechaReiterativa;
    [SerializeField] private int _PuntosParaCosecha;
    [SerializeField] private int _ProbabilidadSeguirRegada;
    [SerializeField] private int _CantidadCosecha;
    [SerializeField] private bool _CosechaReiterativa;
    [SerializeField] private int _TiempoCosechaReiterativa;

    private void Awake() {
        _SpriteRenderer = transform.GetComponent<SpriteRenderer>();
        _ImagenesPlanta = ImagenesManager.iMan.GetImagenesPlanta();
        _Casilla = GetComponentInParent<Casilla>();
        _Cosecha = _Casilla.GetComponentInChildren<Cosecha>();
    }

    private void Start() {
        CalcularEstadoPlanta();
    }

    private void Inicializar(){
        Cultivos cultivo;
        if(_TipoVegetal == TipoVegetal.Tomate){cultivo = GameManager.gameManager.GetHortalizas().GetCultivoPorPosicion(0);}
        else if(_TipoVegetal == TipoVegetal.Patata){cultivo = Hortalizas.hortalizas.GetCultivoPorPosicion(1);}
        else if(_TipoVegetal == TipoVegetal.Zanahoria){cultivo = Hortalizas.hortalizas.GetCultivoPorPosicion(2);}
        else if(_TipoVegetal == TipoVegetal.Naranja){cultivo = Hortalizas.hortalizas.GetCultivoPorPosicion(3);}
        else if(_TipoVegetal == TipoVegetal.Arroz){cultivo = Hortalizas.hortalizas.GetCultivoPorPosicion(4);}
        else if(_TipoVegetal == TipoVegetal.Trigo){cultivo = Hortalizas.hortalizas.GetCultivoPorPosicion(5);}
        else{cultivo = null;}

        _PuntosParaCosecha = cultivo.PuntosParaCosecha;
        _ProbabilidadSeguirRegada = cultivo.ProbabilidadSeguirRegada;
        _CantidadCosecha = Random.Range(cultivo.CantidadCosechaMin, cultivo.CantidadCosechaMax);
        _CosechaReiterativa = cultivo.CosechaReiterativa;
        _TiempoCosechaReiterativa  = cultivo.TiempoCosechaReiterativa;
    }

    public void SetImagenSprite(int numero){
        _SpriteRenderer.sprite = _ImagenesPlanta[numero];
    }

    private void CalcularEstadoPlanta(){
        if(PuntosCrecimiento == 0){
            _SpriteRenderer.sprite = _ImagenesPlanta[0];
        }else{
            int nivelCrecimiento = (int)((float)PuntosCrecimiento / (float)PuntosParaCosecha * 10);
            if(nivelCrecimiento <= 2){
                _SpriteRenderer.sprite = _ImagenesPlanta[1];
            }else  if(nivelCrecimiento > 02 && nivelCrecimiento <= 04 ){
                _SpriteRenderer.sprite = _ImagenesPlanta[2];
            }else  if(nivelCrecimiento > 04 && nivelCrecimiento <= 06 ){
                _SpriteRenderer.sprite = _ImagenesPlanta[3];
            }else  if(nivelCrecimiento > 06 && nivelCrecimiento <= 08 ){
                _SpriteRenderer.sprite = _ImagenesPlanta[4];
            }else  if(nivelCrecimiento > 08){
                _SpriteRenderer.sprite = _ImagenesPlanta[5];
            }
            if(PuntosCrecimiento == PuntosParaCosecha){
                _Cosecha.PonerCosecha(_TipoVegetal);
                GetComponentInParent<Casilla>().SetTipoCasilla(TipoCasilla.Cosecha_Seca);
            }
        }
    }

    public bool SigueRegada(){
        float numeroRandom = Random.Range(0,100);
        if(ProbabilidadSeguirRegada >= numeroRandom){
            return true;
        }else{
            return false;
        }
    }

    public void CrecerPlanta(){
        if(PuntosCrecimiento == _PuntosParaCosecha){
            _PuntosCosechaReiterativa++;
            if(_PuntosCosechaReiterativa == _TiempoCosechaReiterativa){
                _Cosecha.PonerCosecha(_TipoVegetal);
                GetComponentInParent<Casilla>().SetTipoCasilla(TipoCasilla.Cosecha_Seca);
            }
        }else{
            PuntosCrecimiento++;
            GuardarDatosPlanta();
            CalcularEstadoPlanta();
        }
    }

    public void EliminarPlanta(){
        PuntosCrecimiento = 0;
        PuntosCosechaReiterativa = 0;
        PuntosParaCosecha = 0;
        ProbabilidadSeguirRegada = 0;
        CantidadCosecha = 0;
        TiempoCosechaReiterativa = 0;
        CosechaReiterativa = false;
        _TipoVegetal = TipoVegetal.Ninguno;

        GuardarDatosPlanta();
        CalcularEstadoPlanta();
    }

    public void SetTipoVegetal(Cultivos vegetal){
        if(vegetal == null){_TipoVegetal = TipoVegetal.Ninguno;}
        else if(vegetal.NombreClave == "Tomate"){_TipoVegetal = TipoVegetal.Tomate; Inicializar();}
        else if(vegetal.NombreClave == "Patata"){_TipoVegetal = TipoVegetal.Patata; Inicializar();}
        else if(vegetal.NombreClave == "Zanahoria"){_TipoVegetal = TipoVegetal.Zanahoria; Inicializar();}
        else if(vegetal.NombreClave == "Naranja"){_TipoVegetal = TipoVegetal.Naranja; Inicializar();}
        else if(vegetal.NombreClave == "Arroz"){_TipoVegetal = TipoVegetal.Arroz; Inicializar();}
        else if(vegetal.NombreClave == "Trigo"){_TipoVegetal = TipoVegetal.Trigo; Inicializar();}

        GuardarDatosPlanta();
    }

    private void GuardarDatosPlanta(){
        EstadoJuego.EdJ._Casillero[_Casilla._PosX * 9 + _Casilla._PosY, 1] = GetTipoVegetalNumerico();
        EstadoJuego.EdJ._Casillero[_Casilla._PosX * 9 + _Casilla._PosY, 2] = PuntosCrecimiento;
        EstadoJuego.EdJ._Casillero[_Casilla._PosX * 9 + _Casilla._PosY, 3] = PuntosCosechaReiterativa;
        EstadoJuego.EdJ._Casillero[_Casilla._PosX * 9 + _Casilla._PosY, 4] = PuntosParaCosecha;
        EstadoJuego.EdJ._Casillero[_Casilla._PosX * 9 + _Casilla._PosY, 5] = ProbabilidadSeguirRegada;
        EstadoJuego.EdJ._Casillero[_Casilla._PosX * 9 + _Casilla._PosY, 6] = CantidadCosecha;
        EstadoJuego.EdJ._Casillero[_Casilla._PosX * 9 + _Casilla._PosY, 7] = TiempoCosechaReiterativa;
    }

    public TipoVegetal GetTipoVegetal(){return _TipoVegetal;}

    public int GetTipoVegetalNumerico(){
        if(_TipoVegetal == TipoVegetal.Tomate){return 1;}
        else if(_TipoVegetal == TipoVegetal.Patata){return 2;}
        else if(_TipoVegetal == TipoVegetal.Zanahoria){return 3;}
        else if(_TipoVegetal == TipoVegetal.Naranja){return 4;}
        else if(_TipoVegetal == TipoVegetal.Arroz){return 5;}
        else if(_TipoVegetal == TipoVegetal.Trigo){return 6;}
        else{ return 0;}
    }

    public void SetCrecimientoNumerico(int numero){
        PuntosCrecimiento = numero;
        CalcularEstadoPlanta();
    }

    public void SetTipoVegetalNumerico(int valor){
        int numero = EstadoJuego.EdJ._Casillero[valor, 1];
        if(numero == 0) {_TipoVegetal = TipoVegetal.Ninguno;}
        else if(numero == 1) {_TipoVegetal = TipoVegetal.Tomate; }
        else if(numero == 2) {_TipoVegetal = TipoVegetal.Patata; }
        else if(numero == 3) {_TipoVegetal = TipoVegetal.Zanahoria; }
        else if(numero == 4) {_TipoVegetal = TipoVegetal.Naranja; }
        else if(numero == 5) {_TipoVegetal = TipoVegetal.Arroz; }
        else if(numero == 6) {_TipoVegetal = TipoVegetal.Trigo; }

        PuntosCrecimiento = EstadoJuego.EdJ._Casillero[valor, 2];
        PuntosCosechaReiterativa = EstadoJuego.EdJ._Casillero[valor, 3];
        PuntosParaCosecha = EstadoJuego.EdJ._Casillero[valor, 4];
        ProbabilidadSeguirRegada = EstadoJuego.EdJ._Casillero[valor, 5];
        CantidadCosecha = EstadoJuego.EdJ._Casillero[valor, 6];
        TiempoCosechaReiterativa = EstadoJuego.EdJ._Casillero[valor, 7];
        if(TiempoCosechaReiterativa > 0){CosechaReiterativa = true;}else{CosechaReiterativa = false;}
    }

    public int CantidadCosecha { get => _CantidadCosecha; set => _CantidadCosecha = value; }
    public int PuntosParaCosecha { get => _PuntosParaCosecha; set => _PuntosParaCosecha = value; }
    public int ProbabilidadSeguirRegada { get => _ProbabilidadSeguirRegada; set => _ProbabilidadSeguirRegada = value; }
    public bool CosechaReiterativa { get => _CosechaReiterativa; set => _CosechaReiterativa = value; }
    public int TiempoCosechaReiterativa { get => _TiempoCosechaReiterativa; set => _TiempoCosechaReiterativa = value; }
    public int PuntosCosechaReiterativa { get => _PuntosCosechaReiterativa; set => _PuntosCosechaReiterativa = value; }
    public int PuntosCrecimiento { get => _PuntosCrecimiento; set => _PuntosCrecimiento = value; }
}
