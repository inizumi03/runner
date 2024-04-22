using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        GetInput(); // Llama a la función para detectar la entrada del usuario
    }

    private void GetInput()
    {
        // Verifica si se presiona la tecla R
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1; // Restablece la escala de tiempo a 1 (tiempo normal)
            SceneManager.LoadScene(1); // Carga la escena con el índice 1 (generalmente la primera escena del juego)
        }
    }
}
