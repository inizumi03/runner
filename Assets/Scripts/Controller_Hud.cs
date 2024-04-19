using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{// Variable que controla si el juego ha terminado
    public static bool gameOver = false;
    // Referencias a los textos en la UI
    public Text distanceText;
    public Text gameOverText;
    // almacena la distancia recorrida
    private float distance = 0;

    void Start()
    {
        // Se inicializan las variables y textos en la interfaz de usuario
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Si el juego ha terminado Se detiene el tiempo del juego y Se muestra el texto de "Game Over" junto con la distancia total recorrida
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + distance.ToString();
            gameOverText.gameObject.SetActive(true);
        }
        else
        {// Si el juego no ha terminado, se actualiza la distancia recorrida
            distance += Time.deltaTime;
            distanceText.text = distance.ToString();
        }
    }
}
