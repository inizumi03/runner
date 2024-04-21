using UnityEngine;

public class Controllador_Disparo_Enemigo : MonoBehaviour
{
    public GameObject prefabBala; // Prefab de la bala a instanciar
    public Transform puntoDisparo; // Punto de origen del disparo
    public GameObject jugador; // Objeto del jugador
    public float fuerzaDisparo = 10f; // Fuerza del disparo
    public float tiempoEntreDisparos = 15f; // Tiempo entre cada disparo
    public float tiempoDestruccionBala = 3f; // Tiempo de vida de la bala

    private float tiempoUltimoDisparo;

    void Start()
    {
        tiempoUltimoDisparo = Time.time;
    }

    void Update()
    {
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        if (jugador != null)
        {
            // Obtener la posición del jugador
            Vector3 direccionDisparo = (jugador.transform.position - puntoDisparo.position).normalized;

            // Instancia la bala en el punto de disparo
            GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.LookRotation(direccionDisparo));

            // Agrega fuerza a la bala
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direccionDisparo * fuerzaDisparo, ForceMode.Impulse);
            }

            // Destruye la bala después de un tiempo
            Destroy(bala, tiempoDestruccionBala);
        }
        else
        {
            Debug.LogWarning("El jugador no está asignado en el script de disparo del enemigo.");
        }
    }
}