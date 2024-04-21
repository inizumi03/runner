using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Bala : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo después del cual se destruirá el objeto

    void Start()
    {
        // Destruye el objeto después de un tiempo especificado
        Destroy(gameObject, destroyTime);
    }
}
