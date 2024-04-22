using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    // Variable que controla si el juego ha terminado
    public static bool gameOver = false;

    // Referencias a los textos en la UI
    public Text distanceText;
    public Text gameOverText;

    // Almacena la distancia recorrida
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
        // Si el juego ha terminado, se detiene el tiempo del juego y se muestra el texto de "Game Over" junto con la distancia total recorrida
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Puse R Para reintentar \n Total Distance: " + ((int)distance).ToString();
            gameOverText.gameObject.SetActive(true);

            // Detener el sonido de la cámara principal
            StopMainCameraSound();
        }
        else
        {
            // Si el juego no ha terminado, se actualiza la distancia recorrida
            distance += Time.deltaTime;
            distanceText.text = ((int)distance).ToString();
        }
    }

    // Método para detener el sonido de la cámara principal
    private void StopMainCameraSound()
    {
        // Encuentra la cámara principal en la escena
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            // Obtiene el componente AudioSource de la cámara principal y detiene la reproducción del sonido
            AudioSource audioSource = mainCamera.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
}
