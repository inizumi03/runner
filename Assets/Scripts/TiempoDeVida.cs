using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoDeVida : MonoBehaviour
{
    public float tiempoDeVida;
    //codigo usado para destruir el objeto que genera el ruido
    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

  
    void Update()
    {
        
    }
}
