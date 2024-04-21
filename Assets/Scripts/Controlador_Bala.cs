using UnityEngine;

public class Controlador_Bala : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo despu�s del cual se destruir� el objeto

    void Start()
    {
        // Destruye el objeto despu�s de un tiempo especificado
        Destroy(gameObject, destroyTime);
    }

    // Este m�todo se llama cuando la bala colisiona con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colision� tiene el componente Controller_Enemy
        Controller_Enemy enemy = other.GetComponent<Controller_Enemy>();

        // Si el objeto tiene el componente Controller_Enemy, destr�yelo
        if (enemy != null)
        {
            Destroy(other.gameObject); // Destruye el objeto enemigo
            Destroy(gameObject); // Destruye la bala
        }
    }
}
