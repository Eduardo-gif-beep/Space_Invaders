using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections; 

public class ButtonBouncy : MonoBehaviour
{
    [SerializeField] private string targetTag = "Mari"; 
   
    
    // Agrega esto temporalmente para debug
void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Colisión detectada con: " + collision.gameObject.name);
    Debug.Log("Tag del objeto: " + collision.gameObject.tag);
    
    if (collision.gameObject.CompareTag(targetTag))
    {
        Debug.Log("¡Tag correcto! Cargando escena...");
        SceneManager.LoadScene("SampleSceneBall");
    } 
}
}