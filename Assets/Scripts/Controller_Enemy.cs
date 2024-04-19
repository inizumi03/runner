using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    // velocidad del enemigo
    public static float enemyVelocity;
    //  Rigidbody del enemigo
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Método llamado en cada frame
    void Update()
    {
        // Agrega una fuerza para mover el enemigo hacia la izquierda con la velocidad especificada
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force);
        // Verifica si el enemigo está fuera de los límites
        OutOfBounds();
    }

    // verificador si el enemigo está fuera de los límite
    public void OutOfBounds()
    {// Si la posición x del enemigo es menor o igual a -15 Destruye el objeto del enemigo
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
