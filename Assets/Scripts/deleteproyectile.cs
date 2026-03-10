using UnityEngine;

public class deleteproyectile : MonoBehaviour
{
    [SerializeField] string groundTag = "Suelo";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            Destroy(gameObject);
        }
    }
}