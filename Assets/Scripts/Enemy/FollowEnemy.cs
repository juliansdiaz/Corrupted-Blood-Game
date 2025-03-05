using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    LivesManager livesManager;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        livesManager = FindAnyObjectByType<LivesManager>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Mover al enemigo hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Calcular la direccion hacia el jugador
        Vector2 direction = (target.position - transform.position).normalized;

        // Calcular el angulo en grados (ajustado para top-down)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar la rotacion SOLO en el eje Z
        transform.rotation = Quaternion.Euler(0f, 0f, -angle);
    }

    //Hurt player when collides
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Hitsound");
            livesManager.lives -= 1;
            livesManager.livesText.text = "x"+ livesManager.lives;
        }
    }
}
