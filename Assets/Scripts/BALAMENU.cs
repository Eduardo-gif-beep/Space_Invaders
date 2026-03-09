using UnityEngine;

public class ProjectileForMenu : MonoBehaviour
{
    [SerializeField] private string targetTag = "Mari"; // Tag del objetivo que puede cargar escenas
    [SerializeField] private float lifetime = 5f; // Tiempo de vida por si no golpea nada
    
    private void Start()
    {
        // Destruir el proyectil después de un tiempo si no golpea nada
        Destroy(gameObject, lifetime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other.gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }
    
    void HandleCollision(GameObject other)
    {
        // Si es el botón (Mari) - NO destruir el proyectil para que ButtonBouncy pueda detectarlo
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Proyectil golpeó a Mari - El botón cargará la escena");
            
            // Opcional: Hacer que el proyectil se "pegue" o desaparezca visualmente
            // Por ejemplo, desactivar el collider y el renderer
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
            
            return;
        }
        
        // Si choca con cualquier otra cosa (paredes, decoración, etc.)
        Debug.Log("Proyectil chocó con: " + other.name + " cambio de scene");
      
    }
}