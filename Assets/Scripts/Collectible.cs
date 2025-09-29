using UnityEngine;

public class Collectible : MonoBehaviour
{

    public enum CollectibleType { NormalFlower, SpecialFlower }
    public CollectibleType type; // Tipo de coleccionable

    public int points = 10; // Puntos que se ganan

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Se suman los puntos
            GameManager.instance.AddScore(type, points);

            // Se destruye la flor recolectada
            Destroy(gameObject);
        }
    }
}