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
    private TipoVegetal _TipoVegetal;
    private int _PuntosCrecimiento = 0;
    private int _PuntosCosechaReiterativa;

    private int _PuntosParaCosecha;
    private int _ProbabilidadSeguirRegada;
    private int _CantidadCosecha;
    private bool _CosechaReiterativa;
    private int _TiempoCosechaReiterativa;

    private void Start() {
        _ImagenesPlanta = ImagenesManager.iMan.GetImagenesPlanta();
        _Casilla = GetComponentInParent<Casilla>();
        _Cosecha = _Casilla.GetComponentInChildren<Cosecha>();
        CalcularEstadoPlanta();
    }

    private void Inicializar(){
        Cultivos cultivo;
        if(_TipoVegetal == TipoVegetal.Tomate){cultivo = Hortalizas.hortalizas.GetCultivoPorPosicion(0);}
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
        transform.GetComponent<SpriteRenderer>().sprite = _ImagenesPlanta[numero];
    }

    private void CalcularEstadoPlanta(){
        if(_PuntosCrecimiento == 0){
            transform.GetComponent<SpriteRenderer>().sprite = _ImagenesPlanta[0];
        }else{
            int nivelCrecimiento = (int)((float)_PuntosCrecimiento / (float)PuntosParaCosecha * 10);
            if(nivelCrecimiento <= 2){
                transform.GetComponent<SpriteRenderer>().sprite = _ImagenesPlanta[1];
            }else  if(nivelCrecimiento > 02 && nivelCrecimiento <= 04 ){
                transform.GetComponent<SpriteRenderer>().sprite = _ImagenesPlanta[2];
            }else  if(nivelCrecimiento > 04 && nivelCrecimiento <= 06 ){
                transform.GetComponent<SpriteRenderer>().sprite = _ImagenesPlanta[3];
            }else  if(nivelCrecimiento > 06 && nivelCrecimiento <= 08 ){
                transform.GetComponent<SpriteRenderer>().sprite = _ImagenesPlanta[4];
            }else  if(nivelCrecimiento > 08){
                transform.GetComponent<SpriteRenderer>().sprite = _ImagenesPlanta[5];
            }
            if(_PuntosCrecimiento == PuntosParaCosecha){
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
        if(_PuntosCrecimiento == _PuntosParaCosecha){
            _PuntosCosechaReiterativa++;
            if(_PuntosCosechaReiterativa == _TiempoCosechaReiterativa){
                _Cosecha.PonerCosecha(_TipoVegetal);
                GetComponentInParent<Casilla>().SetTipoCasilla(TipoCasilla.Cosecha_Seca);
            }
        }else{
            _PuntosCrecimiento++;
            CalcularEstadoPlanta();
        }
    }

    public void EliminarPlanta(){
        _PuntosCrecimiento = 0;
        CalcularEstadoPlanta();
    }

    public void SetTipoVegetal(Cultivos vegetal){
        if(vegetal == null){_TipoVegetal = TipoVegetal.Ninguno;}
        else if(vegetal.Nombre == "Tomate"){_TipoVegetal = TipoVegetal.Tomate; Inicializar();}
        else if(vegetal.Nombre == "Patata"){_TipoVegetal = TipoVegetal.Patata; Inicializar();}
        else if(vegetal.Nombre == "Zanahoria"){_TipoVegetal = TipoVegetal.Zanahoria; Inicializar();}
        else if(vegetal.Nombre == "Naranja"){_TipoVegetal = TipoVegetal.Naranja; Inicializar();}
        else if(vegetal.Nombre == "Arroz"){_TipoVegetal = TipoVegetal.Arroz; Inicializar();}
        else if(vegetal.Nombre == "Trigo"){_TipoVegetal = TipoVegetal.Trigo; Inicializar();}
    }

    public TipoVegetal GetTipoVegetal(){return _TipoVegetal;}

    public int CantidadCosecha { get => _CantidadCosecha; set => _CantidadCosecha = value; }
    public int PuntosParaCosecha { get => _PuntosParaCosecha; set => _PuntosParaCosecha = value; }
    public int ProbabilidadSeguirRegada { get => _ProbabilidadSeguirRegada; set => _ProbabilidadSeguirRegada = value; }
    public bool CosechaReiterativa { get => _CosechaReiterativa; set => _CosechaReiterativa = value; }
    public int TiempoCosechaReiterativa { get => _TiempoCosechaReiterativa; set => _TiempoCosechaReiterativa = value; }
    public int PuntosCosechaReiterativa { get => _PuntosCosechaReiterativa; set => _PuntosCosechaReiterativa = value; }
}
