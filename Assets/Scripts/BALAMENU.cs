using UnityEngine;

public class ProjectileForMenu : MonoBehaviour
{
    [SerializeField] private string targetTag = "Mari"; 
    [SerializeField] private float lifetime = 2f; 
    
    private void Start()
    {
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
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Proyectil golpeó a Mari - El botón cargará la escena");
            
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            
            
            return;
        }
       
        Debug.Log("Proyectil chocó con: " + other.name + " cambio de scene");
      
    }
}