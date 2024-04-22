using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_controller : MonoBehaviour
{
    public void JugarNivel(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }
    public void Salir()
    {
        Application.Quit();
    }
    
}
