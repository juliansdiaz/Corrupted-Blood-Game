using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    private Transform target;
    public float speed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // Mover al enemigo hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Calcular la dirección hacia el jugador
        Vector2 direction = (target.position - transform.position).normalized;

        // Calcular el ángulo en grados (ajustado para top-down)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar la rotación SOLO en el eje Z
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
