using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    // Lista de objetos de enemigos que pueden ser instanciados
    public List<GameObject> enemies;
    // Posición de instanciación de los enemigos
    public GameObject instantiatePos;
    // Tiempo de espera entre instanciaciones de enemigos
    public float respawningTimer;
    // Tiempo transcurrido
    private float time = 0;

    void Start()
    {
        // Se establece la velocidad inicial de los enemigos
        Controller_Enemy.enemyVelocity = 1;
    }

    void Update()
    {
        // Llama a los métodos para instanciar enemigos y cambiar la velocidad de los enemigos
        SpawnEnemies();
        ChangeVelocity();
    }

    // Método privado para cambiar la velocidad de los enemigos de forma suave
    private void ChangeVelocity()
    {
        // Incrementa el tiempo transcurrido Calcula la nueva velocidad de los enemigos utilizando una interpolación suave entre dos valores
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 10f, time / 45f);
    }

    private void SpawnEnemies()
    {
        // Reduce el temporizador de espera entre instanciaciones de enemigos
        respawningTimer -= Time.deltaTime;

        // Si el temporizador llega a cero o menos Instancia un enemigo aleatorio en la posición de instanciación especificada
        if (respawningTimer <= 0)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
            // Establece un nuevo valor aleatorio para el temporizador de espera
            respawningTimer = UnityEngine.Random.Range(2, 6);
        }
    }
}
