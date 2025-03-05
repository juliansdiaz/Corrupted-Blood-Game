using UnityEngine;

public class CellCollision : MonoBehaviour
{
    public GameObject explosionEffect; // Efecto de partículas al destruirse
    ItemsManager itemsManager;

    void Start()
    {
        itemsManager = FindAnyObjectByType<ItemsManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Instancia el efecto de partículas
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                AudioManager.Instance.PlaySFX("Eat Cell");
            }

            // Destruye el objeto "Cell"
            Destroy(gameObject);
            itemsManager.itemCount -= 1;
            itemsManager.itemsText.text = "x" + itemsManager.itemCount;
            itemsManager.AllItemsCollected();
        }
    }
}