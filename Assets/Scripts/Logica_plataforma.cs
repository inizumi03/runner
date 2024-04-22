using UnityEngine;

public class Logica_Plataforma : MonoBehaviour
{
    public GameObject[] puntos; // Array de puntos de destino
    public float velocidad = 1; // Velocidad de movimiento de la plataforma
    private int puntosIndex = 0; // Índice para rastrear el punto de destino actual

    void Update()
    {
        MovePlatform(); // Llama a la función para mover la plataforma
    }

    void MovePlatform()
    {
        // Comprueba si la plataforma está lo suficientemente cerca del punto de destino actual
        if (Vector3.Distance(transform.position, puntos[puntosIndex].transform.position) < 0.1f)
        {
            puntosIndex++; // Cambia al siguiente punto de destino

            // Si se alcanza el último punto de destino, reinicia el índice para volver al primer punto
            if (puntosIndex >= puntos.Length)
            {
                puntosIndex = 0;
            }
        }

        // Mueve la plataforma suavemente hacia el punto de destino actual
        transform.position = Vector3.MoveTowards(transform.position, puntos[puntosIndex].transform.position, velocidad * Time.deltaTime);
    }
}