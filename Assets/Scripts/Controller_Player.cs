using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    // Referencia al componente Rigidbody del jugador
    private Rigidbody rb;
    // Fuerza de salto del jugador
    public float jumpForce = 10;
    // Tamaño inicial del jugador
    private float initialSize;
    // Contador para controlar el tamaño del jugador al agacharse
    private int i = 0;
    // Indica si el jugador está en el suelo
    private bool floored;
    public GameObject sonidoDeSalto;
    // Referencia al script Parallax
    private Parallax parallaxScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Almacena el tamaño inicial del jugador
        initialSize = rb.transform.localScale.y;

        // Obtiene una referencia al script Parallax
        parallaxScript = FindObjectOfType<Parallax>();
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        // Verifica si el jugador desea saltar o agacharse
        Jump();
        Duck();
    }

    private void Jump()
    {
        if (floored)
        {
            // Verifica si el jugador está en el suelo y presiona la tecla de salto (W)
            if (Input.GetKeyDown(KeyCode.W))
            {
                Instantiate(sonidoDeSalto);
                // Aplica una fuerza hacia arriba al jugador para simular el salto
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            // Verifica si el jugador está en el suelo y presiona la tecla para agacharse (S)
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0)
                {
                    // Si es la primera vez que se agacha, reduce a la mitad la escala del jugador en el eje Y
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                // Si el jugador no presiona la tecla de agacharse o deja de hacerlo, restaura su tamaño inicial
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con un enemigo, el jugador es destruido y el juego termina
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
            // Detiene el paralaje
        
        }

        // Si colisiona con el suelo, indica que el jugador está en el suelo
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Si deja de colisionar con el suelo, indica que el jugador no está en el suelo
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }
}


