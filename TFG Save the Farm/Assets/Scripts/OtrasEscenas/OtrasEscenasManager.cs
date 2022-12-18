using UnityEngine;
using UnityEngine.SceneManagement;

public class OtrasEscenasManager : MonoBehaviour{

    public void Portada(){
        SceneManager.LoadScene("Portada");
    }

    public void Creditos(){
        SceneManager.LoadScene("Creditos");
    }

    public void Salir(){
        Application.Quit();
    }
}
