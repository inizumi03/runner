using UnityEngine;

public class Controlador_Bala : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo después del cual se destruirá el objeto

    void Start()
    {
        // Destruye el objeto después de un tiempo especificado
        Destroy(gameObject, destroyTime);
    }

    // Este método se llama cuando la bala colisiona con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colisionó tiene el componente Controller_Enemy
        Controller_Enemy enemy = other.GetComponent<Controller_Enemy>();

        // Si el objeto tiene el componente Controller_Enemy, destrúyelo
        if (enemy != null)
        {
            Destroy(other.gameObject); // Destruye el objeto enemigo
            Destroy(gameObject); // Destruye la bala
        }
    }
}
