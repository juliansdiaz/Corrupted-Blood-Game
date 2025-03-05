using UnityEngine;

public class CellCollision : MonoBehaviour
{
    //Variables
    public GameObject explosionEffect;
    ItemsManager itemsManager;

    void Start()
    {
        itemsManager = FindAnyObjectByType<ItemsManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player collides with cell
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play Particle effect
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                AudioManager.Instance.PlaySFX("Eat Cell");
            }

            // Destroy cell gameObject
            Destroy(gameObject);
            itemsManager.itemCount -= 1; //Update CellsCount
            itemsManager.itemsText.text = "x" + itemsManager.itemCount; //Update Cell UI
            itemsManager.AllItemsCollected();
        }
    }
}