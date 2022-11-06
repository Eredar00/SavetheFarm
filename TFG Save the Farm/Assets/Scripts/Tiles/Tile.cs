using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState{
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
        COsecha_Mojado
    }

public class Tile : MonoBehaviour{
    
    [SerializeField] private GameObject cruzRoja, cruzVerde, seleccion;
    [SerializeField] private TileState tipoTile;
    private Sprite bloqueado, tierra_seca, tierra_mojado, arado_seca, arado_mojado, plantado_seca, plantado_mojada;
    private int crecimiento;
    [SerializeField] private BoxCollider2D boxCollider2D;
    
    public int posicionX, posicionY;

    public Tile tileUp, tileDown, tileRight, tileLeft;

    private Planta planta;
    private Cosecha cosecha;

    private void Awake() {
        bloqueado = Resources.Load<Sprite>("Sprites/Tiles/Bloqueado");
        tierra_seca = Resources.Load<Sprite>("Sprites/Tiles/Tierra_seca");
        tierra_mojado = Resources.Load<Sprite>("Sprites/Tiles/Tierra_mojado");
        arado_seca = Resources.Load<Sprite>("Sprites/Tiles/Arado_seca");
        arado_mojado = Resources.Load<Sprite>("Sprites/Tiles/Arado_mojado");
        plantado_seca = Resources.Load<Sprite>("Sprites/Tiles/Plantado_seca");
        plantado_mojada = Resources.Load<Sprite>("Sprites/Tiles/Plantado_mojado");
    }

    private void Start() {
        crecimiento = 0;
        boxCollider2D = GetComponent<BoxCollider2D>();
        planta = GetComponentInChildren<Planta>();
        cosecha = GetComponentInChildren<Cosecha>();
    }
    
    public void getTileSides(){
        tileUp = GridManager.gridManager.GetTileAtPosition(new Vector2(posicionX, posicionY + 1));
        tileDown = GridManager.gridManager.GetTileAtPosition(new Vector2(posicionX, posicionY - 1));
        tileLeft = GridManager.gridManager.GetTileAtPosition(new Vector2(posicionX - 1, posicionY));
        tileRight = GridManager.gridManager.GetTileAtPosition(new Vector2(posicionX + 1, posicionY));
    }

    public void DarPosicion(int x, int y){
        posicionX = x;
        posicionY = y;
    }

    public void PlantarPlanta(){
        planta.CrecerPlanta();
    }

    public void EliminarPlanta(){
        planta.EliminarPlanta();
    }

    public void QuitarCosecha(){
        cosecha.QuitarCosecha();
    }




    public void ChangeTileState(TileState newTileState){
        tipoTile = newTileState;
        
        switch (tipoTile){
            case TileState.Bloqueado:
                ChangeSprite(bloqueado);
                break;
            case TileState.Tierra_Seca:
                ChangeSprite(tierra_seca);
                break;
            case TileState.Tierra_Mojada:
                ChangeSprite(tierra_mojado);
                break;
            case TileState.Arado_Seca:
                ChangeSprite(arado_seca);
                break;
            case TileState.Arado_Mojado:
                ChangeSprite(arado_mojado);
                break;
            case TileState.Plantado_Seca:
                ChangeSprite(plantado_seca);
                break;
            case TileState.Plantado_Mojado:
                ChangeSprite(plantado_mojada);
                break;
            case TileState.Cultivado_Seca:
                ChangeSprite(tierra_seca);
                break;
            case TileState.Cultivado_Mojado:
                ChangeSprite(tierra_mojado);
                break;
            case TileState.Cosecha_Seca:
                ChangeSprite(tierra_seca);
                break;
            case TileState.COsecha_Mojado:
                ChangeSprite(tierra_mojado);
                break;
            default:
                break;
        }  
        
    }

    private void ChangeSprite(Sprite nombre){
        transform.GetComponent<SpriteRenderer>().sprite = nombre;
    }

    public void ActivarCollider(){
        boxCollider2D.enabled = true;
    }

    public void CrecerPlanta(int valorCrecimiento){
        crecimiento = crecimiento + valorCrecimiento;
    }

    public TileState ObtenerTipoTile(){
        return tipoTile;
    }

    public void CambiarHighlight(){
        string resultado = GameManager.gameManager.ComprobarQueHighlightProcede(this, ObtenerTipoTile());
        if(resultado == "Roja"){
            cruzRoja.SetActive(true);
        }else if(resultado == "Negra"){
            cruzVerde.SetActive(true);
        }else if(resultado == "Seleccion"){
            seleccion.SetActive(true);
        }
    }

    public void QuitarHighlight(){
        cruzRoja.SetActive(false);
        cruzVerde.SetActive(false);
        seleccion.SetActive(false);
    }

    // MOUSE ACTIONS
    private void OnMouseEnter(){
        if(GameManager.gameManager.pausa == true || GameManager.gameManager.canvas == true) return;

        GameManager.gameManager.CambiarTileFocused(this);
        ConjuntoCambiarHighlight(this);
    }

    private void OnMouseExit() {
        GameManager.gameManager.CambiarTileFocused(null);
        ConjuntoQuitarHighlight();
    }

    private void OnMouseDown() {
        if(GameManager.gameManager.pausa == true || GameManager.gameManager.canvas == true) return;


        if(GameManager.gameManager.ComprobarNivelAccion() >= 1) GameManager.gameManager.EjecutarAccionSobreCasilla(this); 
        if(GameManager.gameManager.ComprobarNivelAccion() >= 2){
            if(tileRight != null) GameManager.gameManager.EjecutarAccionSobreCasilla(tileRight);
            if(tileLeft != null) GameManager.gameManager.EjecutarAccionSobreCasilla(tileLeft);
        }
        if(GameManager.gameManager.ComprobarNivelAccion() >= 3){
            if(tileUp != null) {
                GameManager.gameManager.EjecutarAccionSobreCasilla(tileUp);
                if(tileUp.tileRight != null) GameManager.gameManager.EjecutarAccionSobreCasilla(tileUp.tileRight);
                if(tileUp.tileLeft != null) GameManager.gameManager.EjecutarAccionSobreCasilla(tileUp.tileLeft);
            }
            if(tileDown != null){
                GameManager.gameManager.EjecutarAccionSobreCasilla(tileDown);
                if(tileDown.tileRight != null) GameManager.gameManager.EjecutarAccionSobreCasilla(tileDown.tileRight);
                if(tileDown.tileLeft != null) GameManager.gameManager.EjecutarAccionSobreCasilla(tileDown.tileLeft);
            }
        }
        

        ConjuntoQuitarHighlight();
        ConjuntoCambiarHighlight(this);

        
    }

    // Funcion para quitar el HighLught del 9x9.
    public void ConjuntoQuitarHighlight(){
        QuitarHighlight();
        if(tileRight != null) tileRight.QuitarHighlight();
        if(tileLeft != null) tileLeft.QuitarHighlight();
        if(tileUp != null) {
            tileUp.QuitarHighlight();
            if(tileUp.tileRight != null) tileUp.tileRight.QuitarHighlight();
            if(tileUp.tileLeft != null) tileUp.tileLeft.QuitarHighlight();
        }
        if(tileDown != null){
            tileDown.QuitarHighlight();
            if(tileDown.tileRight != null) tileDown.tileRight.QuitarHighlight();
            if(tileDown.tileLeft != null) tileDown.tileLeft.QuitarHighlight();
        }
    }

    // Funcion para cambiar el HighLught del 9x9.
    public void ConjuntoCambiarHighlight(Tile tileF){
        if(tileF.ObtenerTipoTile() == TileState.Bloqueado) return;
        if(GameManager.gameManager.ComprobarNivelAccion() >= 1) tileF.CambiarHighlight();
        if(GameManager.gameManager.valorR == true){
            if(GameManager.gameManager.ComprobarNivelAccion() >= 2){
                if(tileF.tileRight != null) tileF.tileRight.CambiarHighlight();
                if(tileF.tileLeft != null) tileF.tileLeft.CambiarHighlight(); }
            if(GameManager.gameManager.ComprobarNivelAccion() >= 3){
                if(tileF.tileUp != null) {
                    tileF.tileUp.CambiarHighlight();
                    if(tileF.tileUp.tileRight != null) tileF.tileUp.tileRight.CambiarHighlight();
                    if(tileF.tileUp.tileLeft != null) tileF.tileUp.tileLeft.CambiarHighlight();
                }
                if(tileF.tileDown != null){
                    tileF.tileDown.CambiarHighlight();
                    if(tileF.tileDown.tileRight != null) tileF.tileDown.tileRight.CambiarHighlight();
                    if(tileF.tileDown.tileLeft != null) tileF.tileDown.tileLeft.CambiarHighlight();
                }
            }
        }else{
            if(GameManager.gameManager.ComprobarNivelAccion() >= 2){
                if(tileF.tileUp != null) tileF.tileUp.CambiarHighlight();
                if(tileF.tileDown != null) tileF.tileDown.CambiarHighlight(); }
            if(GameManager.gameManager.ComprobarNivelAccion() >= 3){
                if(tileF.tileRight != null) {
                    tileF.tileRight.CambiarHighlight();
                    if(tileF.tileRight.tileUp != null) tileF.tileRight.tileUp.CambiarHighlight();
                    if(tileF.tileRight.tileDown != null) tileF.tileRight.tileDown.CambiarHighlight();
                }
                if(tileF.tileLeft != null){
                    tileF.tileLeft.CambiarHighlight();
                    if(tileF.tileLeft.tileUp != null) tileF.tileLeft.tileUp.CambiarHighlight();
                    if(tileF.tileLeft.tileDown != null) tileF.tileLeft.tileDown.CambiarHighlight();
                }
            }
        }


        
    }



}
