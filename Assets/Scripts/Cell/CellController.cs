using UnityEngine;

public class CellController : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction;
    private Camera mainCamera;
    private float objectRadius;

    void Start()
    {
        mainCamera = Camera.main;
        objectRadius = GetComponent<CircleCollider2D>().radius;

        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        LimitPositionAndBounce();
    }

    // Método para limitar la posición y rebotar en los bordes
    private void LimitPositionAndBounce()
    {
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if (transform.position.x > screenBounds.x - objectRadius || transform.position.x < -screenBounds.x + objectRadius)
        {
            direction.x *= -1; // Invierte la dirección en X
        }

        // Limita la posición en el eje Y
        if (transform.position.y > screenBounds.y - objectRadius || transform.position.y < -screenBounds.y + objectRadius)
        {
            direction.y *= -1; // Invierte la dirección en Y
        }

        // Aplica la posición limitada
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + objectRadius, screenBounds.x - objectRadius);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y + objectRadius, screenBounds.y - objectRadius);
        transform.position = new Vector2(clampedX, clampedY);
    }
}