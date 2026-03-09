using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections; 

public class ButtonSpaceInvaders : MonoBehaviour
{
    [SerializeField] private string targetTag = "Mari"; 
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
 
if (collision.gameObject.CompareTag(targetTag))
        {
             SceneManager.LoadScene("Space_Invaders");
        } 
    }
}