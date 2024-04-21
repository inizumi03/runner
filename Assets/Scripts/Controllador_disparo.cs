using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controllador_disparo : MonoBehaviour
{
    public GameObject BalaInicio; // Punto de inicio de donde la bala saldrá
    public GameObject BalaPrefab; // Prefab de la bala
    public float BalaVelocidad; // Velocidad de la bala

    public int numBalasDisparadas = 0; // Contador de balas disparadas
    public int maxBalas = 3; // Número máximo de balas que puede disparar el jugador antes de detenerse
    public float intervaloDisparo = 2f; // Intervalo entre disparos

    private bool puedeDisparar = true; // Indica si el jugador puede disparar
    private WaitForSeconds esperaDisparo; // Tiempo de espera antes de permitir otro disparo

    void Start()
    {
        esperaDisparo = new WaitForSeconds(intervaloDisparo);
    }

    void Update()
    {
        if (puedeDisparar && Input.GetButtonDown("Fire1") && numBalasDisparadas < maxBalas)
        {
            Disparar();
            numBalasDisparadas++;

            if (numBalasDisparadas >= maxBalas)
            {
                // Detener temporalmente los disparos
                StartCoroutine(EsperarDisparo());
            }
        }
    }

    void Disparar()
    {
        // Instanciar la balaPrefab en la posición de BalaInicio
        GameObject BalaTemporal = Instantiate(BalaPrefab, BalaInicio.transform.position, BalaInicio.transform.rotation) as GameObject;

        // Obtener Rigidbody para agregar fuerza
        Rigidbody rb = BalaTemporal.GetComponent<Rigidbody>();

        // Agregar la fuerza a la bala
        rb.AddForce(transform.forward * BalaVelocidad);

        // Destruir la bala después de un tiempo
        Destroy(BalaTemporal, 5.0f);
    }

    IEnumerator EsperarDisparo()
    {
        puedeDisparar = false;
        yield return esperaDisparo;
        numBalasDisparadas = 0;
        puedeDisparar = true;
    }
}



