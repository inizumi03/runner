using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Referencia al objeto de la cámara
    public GameObject cam;

    // Longitud del fondo y posición inicial
    private float length, startPos;

    // Efecto de paralaje
    public float parallaxEffect;

    // Variable para indicar si el juego ha terminado
    private bool gameOver = false;

    // Método llamado al inicio
    void Start()
    {
        // Almacena la posición inicial del fondo
        startPos = transform.position.x;

        // Obtiene la longitud del fondo a partir de su componente SpriteRenderer
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Método llamado en cada frame
    void Update()
    {

        // Si el juego ha terminado, detiene el paralaje
        if (!Controller_Hud.gameOver)
        {
          
            transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);

        }

       

        // Si la posición local del fondo en el eje X es menor que -20 (un valor arbitrario)
        if (transform.localPosition.x < -20)
            {
                // Reinicia la posición del fondo al lado opuesto
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z);
            }
        
    }

    
}



