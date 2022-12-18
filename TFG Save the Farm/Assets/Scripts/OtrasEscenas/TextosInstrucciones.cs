using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextosInstrucciones : MonoBehaviour{
    
    private string[] _CAT_Text = {
        "INSTRUCCIONS DEL JOC",
        "INTRODUCCIÓ I OBJECTIUS",
        "1. El principal objectiu del joc és poder completar la major quantitat de dies sense arruïnar-te.\n \n2. Per això, disposes d'un total de 6 eines i 6 tipus de cultius diferents, cadascun amb les seves particularitats.\n \n3 En finalitzar els dies 14 i 28 hauràs de tenir prou diners per poder pagar el deute (100$ i 200$ respectivament) Si ho aconsegueixes, guanyaràs el joc En cas contrari, t'aniràs a la fallida i perdràs . A les pàgines següents podràs veure com funciona el joc.", 
        "CASELLES",
        "1. En iniciar el joc, veuràs que hi ha 15 grans blocs de caselles. Cada bloc té un preu, que pots veure en posar el cursor a sobre.",
        "2. El bloc central del tauler, té un cost de 0$. Si hi prems, es desbloquejarà, de forma gratuïta, i tindràs 9 caselles de terra seca.",
        "3. A les caselles de terra, podràs fer ús de les diferents eines.",
        "4. En posar els cursos sobre una casella t'indicarà si pots fer l'acció:",
        "···> Si podeu realitzar l'acció",
        "···> Aquesta acció no es pot realitzar en aquesta casella",
        "···> Et falten PE",

        "PLANTES I COLLITA",
         "1. Les llavors i plantes necessiten aigua per continuar creixent. Si en finalitzar el dia, la casella no està regada, la planta morirà.",
         "2. Cada cultiu té un % de seguir regat l'endemà.",
         "3. Si vols treure una planta o cultiu, pots fer servir la paperera.",
         "4. Quan sigui el moment de collir una casella, apareixerà una imatge del vegetal plantat i podràs collir el cultiu.",
         "5. En collir una casella, si la planta pot produir més collites, es mantindrà, si no és el cas, la planta desapareixerà.",
         "6. Tota la informació i característiques de cada cultiu es troba a la botiga d'hortalisses (tecla 'H').",

         "EINES I PE",
         "1. Disposeu d'un total de 6 eines diferents. Podeu activar-les fent clic a la vostra imatge o prement el número que mostren.",
         "2. Pots veure la descripció, nivell i ús de cada eina a la seva botiga (tecla 'T').",
         "3. La barra verda indicada als Punts d'Energia (PE) disponibles. Realitzar una acció té un cost de PE.",
         "4. Cada dia es restauren els PE al màxim.",

         "BOTIGA D'EINES",
         "1. La botiga d'eines s'obre en prémer la tecla ' T '. \n \n 2. En aquesta botiga, podeu comprar millores per a les eines.",
         "3. La millora de Punts d'Energia (PE) farà que cada vegada que utilitzeu les eines consumiu menys PE.",
         "4. La millora de Casillas farà que puguis fer servir l'eina en més caselles alhora.",
         "5. Per comprar les millores, només has de prémer la imatge del carret de la compra. Si tens $$ suficients, compraràs la millora.",

         "SELECCIÓ DE CASELLES",
         "1. Quan compreu una millora de Caselles d'una eina, podreu utilitzar la tecla ' R ' per canviar les caselles seleccionades. També podeu fer clic a la imatge inferior esquerra del joc:",
         "2. Cada nivell de millora, desbloquejarà més seleccions possibles:",
         "Nivell 1",
         "^ - - - Nivell 2 - - - ^",
         "Nivell 3",
         "Nivell 4",

         "BOTIGA D'HORTALISSES",
         "1. La botiga d'hortalisses s'obre en prémer la tecla 'H'.",
         "2. En aquesta botiga, pots vendre les teves collites i comprar llavors, així com veure les característiques de cada tipus de cultiu.",
         "3. Al primer menú pots veure tots els cultius que existeixen, juntament amb el seu nom i imatge.",
         "4. El nombre en verd indica la quantitat llavors que tens.",
         "5. El nombre en blau indica la quantitat de vegetal que tens.",
         "6. En fer clic a la imatge d'un dels vegetals, accediràs a la botiga d'aquest vegetal on podràs vendre el vegetal, comprar les llavors i veure les característiques de la collita.",

         "SELECCIÓ DE LLAVORS",
         "1. Amb la tecla 'P' podràs canviar el tipus de llavor seleccionada. També pots fer clic a la imatge inferior esquerra del joc:",
         "2. El número situat a la part superior central del requadre indica la quantitat de llavors d'aquest tipus de vegetal que tens.",
         "3. Si tens llavors, quan facis ús de la bossa de llavors, aquesta es plantarà a la casella seleccionada.",
         "4. Si no disposes de llavors, les hauràs de comprar a la botiga d'hortalisses (tecla 'H') o no podràs plantar.",


         "CALENDARI",
         "1. Amb la tecla 'C' podràs obrir el calendari del joc. També pots fer clic a la imatge superior dreta del joc, on apareix el dia.",
         "2. El calendari et permetrà veure quin dia és, així com quants dies queden fins al proper dia que toca pagar el deute.",
         "3. En finalitzar els dies marcats en groc, l'usuari ha de poder pagar el deute (100$ el dia 14 i 200$ el dia 28). En cas contrari, es declara en fallida i perd la partida.",
         "4. Si en acabar el dia 28 l'usuari segueix tenint diners, guanya la partida.",

        "PORTADA",
        "SORTIR"
    };

    private string[] _ESP_Text = {
        "INSTRUCCIONES DEL JUEGO",

        "INTRODUCCIÓN Y OBJETIVOS", 
        "1. El principal objetivo del juego es poder completar la mayor cantidad de días sin arruinarte.\n \n2. Para ello, dispones de un total de 6 herramientas y 6 tipos de cultivos distintos, cada uno con sus particularidades.\n \n3. Al finalizar los días 14 y 28 deberás tener suficiente dinero para poder pagar la deuda (100$ y 200$ respectivamente). Si lo consigues, ganarás el juego. En caso contrario, te irás a la bancarrota y perderás.\n \n4. En las siguientes páginas podrás ver cómo funciona el juego.", 
        
        "CASILLAS",
        "1. Al iniciar el juego, verás que hay 15 grandes bloques de casillas. Cada bloque tiene un precio, que puedes ver al poner el cursor encima.",
        "2. El bloque central del tablero, tiene un coste de 0$. Si pulsas en él, se desbloqueará, de forma gratuïta, y tendrás 9 casillas de tierra seca.",
        "3. En las casillas de tierra, podrás hacer uso de las distintas herramientas.",
        "4. Al poner el cursos sobre una casilla te indicará si puedes realizar la acción:",
        "···> Si puedes realizar la acción",
        "···> Esa acción no se puede realizar en esa casilla",
        "···> Te faltan PE",

        "PLANTAS Y COSECHA",
        "1. Las semillas y plantas necesitan agua para seguir creciendo. Si al finalizar el día, la casilla no está regada, la planta morirá.",
        "2. Cada cultivo tiene un % de seguir regado al día siguiente.",
        "3. Si quieres quitar una planta o cultivo, puedes usar la papelera.",
        "4. Cuando sea el momento de cosechar una casilla, aparecerá una imagen del vegetal plantado y podrás cosechar el cultivo.",
        "5. Al cosechar una casilla, si la planta puede producir más cosechas, se mantendrá, si no es el caso, la planta desaparecerá.",
        "6. Toda la información y características de cada cultivo se encuentra en la tienda de hortalizas (tecla ' H ').",

        "HERRAMIENTAS Y PE",
        "1. Dispones de un total de 6 herramientas distintas. Puedes activarlas haciendo clic en su imagen o pulsando el número que muestran.",
        "2. Puedes ver la descripción, nivel y uso de cada herramienta en su tienda (tecla ' T ' ).",
        "3. La barra verde indicada los Puntos de Energía (PE) disponibles. Realizar una acción tiene un coste de PE.",
        "4. Cada día se restauran los PE al máximo.",

        "TIENDA DE HERRAMIENTAS",
        "1. La tienda de herramientas se abre al pulsar la tecla ' T '. \n \n 2. En esta tienda, puedes comprar mejoras para las herramientas.",
        "3. La mejora de Puntos de Energía (PE) hará que cada vez que uses la herramientas consumas menos PE.",
        "4. La mejora de Casillas hará que puedas usar la herramienta en más casillas a la vez.",
        "5. Para comprar las mejoras, solo debes pulsar en la imagen del carrito de la compra. Si tienes $$ suficientes, comprarás la mejora.",

        "SELECCIÓN DE CASILLAS",
        "1. Al comprar una mejora de Casillas de una herramienta, podrás usar la tecla ' R ' para cambiar las casillas seleccionadas. También puedes hacer clic en la imagen inferior izquierda del juego:",
        "2. Cada nivel de mejora, desbloqueará más selecciones posibles:",
        "Nivel 1",
        "^ - - - Nivel 2 - - - ^",
        "Nivel 3",
        "Nivel 4",

        "TIENDA DE HORTALIZAS",
        "1. La tienda de hortalizas se abre al pulsar la tecla ' H '.",
        "2. En esta tienda, puedes vender tus cosechas y comprar semillas, así com ver las características de cada tipo de cultivo.",
        "3. En el primer menú puedes ver todos los cultivos que existen, junto con su nombre e imagen.",
        "4. El número en verde indica la cantidad semillas que tienes.",
        "5. El número en azul indica la cantidad de vegetal que tienes.",
        "6. Al hacer clic en la imagen de uno de los vegetales, accederás a la tienda de ese vegetal dónde podrás vender el vegetal, comprar sus semillas y ver las características de su cosecha.",

        "SELECCIÓN DE SEMILLAS",
        "1. Con la tecla ' P ' podrás cambiar el tipo de semilla seleccionada. También puedes hacer clic en la imagen inferior izquierda del juego:",
        "2. El número situado en la parte superior central del recuadro indica la cantidad de semillas de ese tipo de vegetal que tienes.",
        "3. Si tienes semillas, cuando hagas uso de la bolsa de semillas, esta se plantará en la casilla seleccionada.",
        "4. Si no dispones de semillas, tendrás que comprarlas en la tienda de hortalizas (tecla ' H ') o no podrás plantar.",


        "CALENDARIO",
        "1. Con la tecla ' C ' podrás abrir el calendario del juego. También puedes hacer clic en la imagen superior derecha del juego, dónde aparece el día. ",
        "2. El calendario te permitirá ver qué día es, así como cuántos días quedan hasta el próximo día que toca pagar la deuda.",
        "3. Al finalizar los días marcados en amarillo, el usuario debe poder pagar la deuda (100$ el día 14 y 200$ el día 28). En caso contrario, se declara en bancarrota y pierde la partida.",
        "4. Si al terminar el día 28  el usuario sigue teniendo dinero, gana la partida.",

        "PORTADA",
        "SALIR"
    };

    private string[] _ENG_Text = {
        "GAME INSTRUCTIONS",
        "INTRODUCTION AND OBJECTIVES",
        "1. The main objective of the game is to be able to complete as many days as possible without going bankrupt.\n \n2. To do this, you have a total of 6 tools and 6 different types of crops, each with its own features.\n \n3 At the end of days 14 and 28 you should have enough money to be able to pay off the debt ($100 and $200 respectively). If you do, you will win the game, otherwise you will go bankrupt and lose.\n \n4 On the following pages you will see how the game works.",
        "TILES",
        "1. When you start the game, you will see that there are 15 large blocks of tiles. Each block has a price, which you can see by hovering over it.",
        "2. The central block of the board has a cost of $0. If you click on it, it will be unlocked, for free, and you will have 9 squares of dry land.",
        "3. On the land squares, you can make use of the different tools.",
        "4. Hover the cursor over a tile to see if you can perform the action:",
        "···> You can perform the action",
        "···> That action cannot be performed on that tile",
        "···> You do not have enough EP", 

        "PLANTS AND HARVEST",
         "1. Seeds and plants need water to continue growing. If at the end of the day, the tile is not watered, the plant will die.",
         "2. Each crop has a % to stay watered the next day.",
         "3. If you want to remove a plant or crop, you can use the trash can.",
         "4. When it is time to harvest a tile, an image of the planted vegetable will appear and you will be able to harvest the crop.",
         "5. When harvesting a tile, if the plant can produce more crops, it will remain, if not, the plant will disappear.",
         "6. All the information and characteristics of each crop can be found in the vegetable store (key 'H').",

         "TOOLS AND EP",
         "1. You have a total of 6 different tools. You can activate them by clicking on their image or by pressing the number they show.",
         "2. You can see the description, level and use of each tool in its shop (key ' T ' ).",
         "3. The green bar indicates the available Energy Points (EP). Performing an action has a cost of EP.",
         "4. Every day the XP is restored to the maximum.",

         "TOOL SHOP",
         "1. The tool shop is opened by pressing the ' T ' key. \n \n 2. In this shop, you can buy upgrades for tools.",
         "3. The Energy Points (EP) upgrade will decrease the EP you need to perform an action with that tool.",
         "4. The tile upgrade will allow you to use the tool on more cells at once.",
         "5. To buy the upgrades, just click on the shopping cart image. If you have enough $$, you will buy the upgrade.",

         "SELECTION OF TILES",
         "1. When purchasing a Tile upgrade, you can use the 'R' key to change the selected Slots. You can also click on the bottom left image of the game:",
         "2. As you advanced to each next level, you unlock more possible selections:",
         "Level 1",
         "^ - - - Level 2 - - - ^",
         "Level 3",
         "Level 4",

         "VEGETABLE SHOP",
         "1. The vegetable shop is opened by pressing the 'H' key.",
         "2. In this shop, you can sell your crops and buy seeds, as well as see the features of each type of crop.",
         "3. In the first menu you can see all the crops that exist, along with their name and image.",
         "4. The number in green indicates the amount of seeds you have.",
         "5. The number in blue indicates the amount of vegetable you have.",
         "6. By clicking on the image of one of the vegetables, you will access the shop of that vegetable where you can sell the vegetable, buy its seeds and see the features of its harvest.",

         "SEED SELECTION",
         "1. With the ' P ' key you can change the type of seed selected. You can also click on the lower left image of the game:",
         "2. The number at the top center of the box indicates the number of seeds of that type of vegetable you have.",
         "3. If you have seeds, when you use the seed bag, it will be planted in the selected space.",
         "4. If you don't have seeds, you'll have to buy them at the vegetable store (key 'H') or you won't be able to plant then.",


         "CALENDAR",
         "1. With the ' C ' key you can open the game calendar. You can also click on the top right image of the game, where the day appears. ",
         "2. The calendar will allow you to see what day it is, as well as how many days are left until the debt is due.",
         "3. At the end of the days marked in yellow, the user must be able to pay the debt ($100 on the 14th and $200 on the 28th). Otherwise, they declare bankruptcy and lose the game.",
         "4. If at the end of the 28th day the user still has money, they win the game.",

        "HOME PAGE",
        "EXIT"
    };
    
    GameObject[] _ObjetosJuego = new GameObject[54];
    private string _Idioma;
    private string[] _Textos;
    
    private void Start() {
        GetTextosIdioma();
        CargarDatos();
        SetTextos();
    }

    private void GetTextosIdioma(){
        _Idioma = EstadoJuego.EdJ.Lang;
        if(_Idioma == "CAT"){_Textos = _CAT_Text;}
        else if(_Idioma == "ESP"){_Textos = _ESP_Text;}
        else if(_Idioma == "ENG"){_Textos = _ENG_Text;}
    }

    private void CargarDatos(){
        Transform pag01, pag02, pag03, pag04, pag05, pag06, pag07, pag08, pag09;
        pag01 = transform.Find("Instrucciones").Find("Pag 1");
        pag02 = transform.Find("Instrucciones").Find("Pag 2");
        pag03 = transform.Find("Instrucciones").Find("Pag 3");
        pag04 = transform.Find("Instrucciones").Find("Pag 4");
        pag05 = transform.Find("Instrucciones").Find("Pag 5");
        pag06 = transform.Find("Instrucciones").Find("Pag 6");
        pag07 = transform.Find("Instrucciones").Find("Pag 7");
        pag08 = transform.Find("Instrucciones").Find("Pag 8");
        pag09 = transform.Find("Instrucciones").Find("Pag 9");

        _ObjetosJuego[0] = transform.Find("Titulo").gameObject;
        _ObjetosJuego[52] = transform.Find("Portada").gameObject;
        _ObjetosJuego[53] = transform.Find("Salir").gameObject;

        _ObjetosJuego[1] = pag01.Find("Titulo").gameObject;
        _ObjetosJuego[2] = pag01.Find("Texto").gameObject;

        _ObjetosJuego[3] = pag02.Find("Titulo").gameObject;
        _ObjetosJuego[4] = pag02.Find("Texto01").gameObject;
        _ObjetosJuego[5] = pag02.Find("Texto02").gameObject;
        _ObjetosJuego[6] = pag02.Find("Texto03").gameObject;
        _ObjetosJuego[7] = pag02.Find("Texto04").gameObject;
        _ObjetosJuego[8] = pag02.Find("Texto05").gameObject;
        _ObjetosJuego[9] = pag02.Find("Texto06").gameObject;
        _ObjetosJuego[10] = pag02.Find("Texto07").gameObject;

        _ObjetosJuego[11] = pag03.Find("Titulo").gameObject;
        _ObjetosJuego[12] = pag03.Find("Texto01").gameObject;
        _ObjetosJuego[13] = pag03.Find("Texto02").gameObject;
        _ObjetosJuego[14] = pag03.Find("Texto03").gameObject;
        _ObjetosJuego[15] = pag03.Find("Texto04").gameObject;
        _ObjetosJuego[16] = pag03.Find("Texto05").gameObject;
        _ObjetosJuego[17] = pag03.Find("Texto06").gameObject;

        _ObjetosJuego[18] = pag04.Find("Titulo").gameObject;
        _ObjetosJuego[19] = pag04.Find("Texto01").gameObject;
        _ObjetosJuego[20] = pag04.Find("Texto02").gameObject;
        _ObjetosJuego[21] = pag04.Find("Texto03").gameObject;
        _ObjetosJuego[22] = pag04.Find("Texto04").gameObject;

        _ObjetosJuego[23] = pag05.Find("Titulo").gameObject;
        _ObjetosJuego[24] = pag05.Find("Texto01").gameObject;
        _ObjetosJuego[25] = pag05.Find("Texto02").gameObject;
        _ObjetosJuego[26] = pag05.Find("Texto03").gameObject;
        _ObjetosJuego[27] = pag05.Find("Texto04").gameObject;

        _ObjetosJuego[28] = pag06.Find("Titulo").gameObject;
        _ObjetosJuego[29] = pag06.Find("Texto01").gameObject;
        _ObjetosJuego[30] = pag06.Find("Texto02").gameObject;
        _ObjetosJuego[31] = pag06.Find("Texto03").gameObject;
        _ObjetosJuego[32] = pag06.Find("Texto04").gameObject;
        _ObjetosJuego[33] = pag06.Find("Texto05").gameObject;
        _ObjetosJuego[34] = pag06.Find("Texto06").gameObject;

        _ObjetosJuego[35] = pag07.Find("Titulo").gameObject;
        _ObjetosJuego[36] = pag07.Find("Texto01").gameObject;
        _ObjetosJuego[37] = pag07.Find("Texto02").gameObject;
        _ObjetosJuego[38] = pag07.Find("Texto03").gameObject;
        _ObjetosJuego[39] = pag07.Find("Texto04").gameObject;
        _ObjetosJuego[40] = pag07.Find("Texto05").gameObject;
        _ObjetosJuego[41] = pag07.Find("Texto06").gameObject;

        _ObjetosJuego[42] = pag08.Find("Titulo").gameObject;
        _ObjetosJuego[43] = pag08.Find("Texto01").gameObject;
        _ObjetosJuego[44] = pag08.Find("Texto02").gameObject;
        _ObjetosJuego[45] = pag08.Find("Texto03").gameObject;
        _ObjetosJuego[46] = pag08.Find("Texto04").gameObject;

        _ObjetosJuego[47] = pag09.Find("Titulo").gameObject;
        _ObjetosJuego[48] = pag09.Find("Texto01").gameObject;
        _ObjetosJuego[49] = pag09.Find("Texto02").gameObject;
        _ObjetosJuego[50] = pag09.Find("Texto03").gameObject;
        _ObjetosJuego[51] = pag09.Find("Texto04").gameObject;
    }

    private void SetTextos(){
        for (int i = 0; i < _ObjetosJuego.Length; i++){
             _ObjetosJuego[i].GetComponentInChildren<Text>().text = _Textos[i];
        }
    }
}
