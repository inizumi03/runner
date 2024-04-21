using UnityEngine;

public class Logica_Plataforma : MonoBehaviour
{
    public GameObject[] puntos;

    public float velocidad = 1;

    private int puntosIndex = 0;

    void Update()
    {

        MovePlatform();

        
    }

    void MovePlatform()
    {
        if (Vector3.Distance(transform.position, puntos[puntosIndex].transform.position) <0.1f)
        {
            puntosIndex++;

            if (puntosIndex >= puntos.Length)
           {
                puntosIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, puntos[puntosIndex].transform.position,velocidad*Time.deltaTime);

    }


}

