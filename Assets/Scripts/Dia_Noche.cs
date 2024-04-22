using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia_Noche : MonoBehaviour
{
    public int RotacionScala = 10;
   

    void Update()
    {
        transform.Rotate(RotacionScala * Time.deltaTime, 0, 0);
    }
}
