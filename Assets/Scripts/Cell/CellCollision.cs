using UnityEngine;

public class CellCollision : MonoBehaviour
{
    public GameObject explosionEffect; // Efecto de partículas al destruirse

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Instancia el efecto de partículas
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            // Destruye el objeto "Cell"
            Destroy(gameObject);
        }
    }
}