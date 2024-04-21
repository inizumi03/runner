using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Bala : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo despu�s del cual se destruir� el objeto

    void Start()
    {
        // Destruye el objeto despu�s de un tiempo especificado
        Destroy(gameObject, destroyTime);
    }
}
