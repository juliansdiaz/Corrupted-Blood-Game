using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    public GameObject explosionParticlesPrefab;

    private Camera mainCamera;
    private float objectRadius;

    void Start()
    {
        mainCamera = Camera.main;
        objectRadius = GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime);
        }

        LimitPositionToScreen();
    }

    private void LimitPositionToScreen()
    {
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + objectRadius, screenBounds.x - objectRadius);

        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y + objectRadius, screenBounds.y - objectRadius);

        transform.position = new Vector2(clampedX, clampedY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cell"))
        {
            if (explosionParticlesPrefab != null)
            {
                Instantiate(explosionParticlesPrefab, collision.transform.position, Quaternion.identity);
            }

            Destroy(collision.gameObject);

            Debug.Log("Cell ha sido destruida por el enemigo.");
        }
    }
}