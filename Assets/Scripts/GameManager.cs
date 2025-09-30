using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Para acceder desde otros scripts

    public Text normalFlowerText;
    public Text specialFlowerText;
    public Text scoreText;
    public Text messageText;

    private int normalFlowerCount = 0;
    private int specialFlowerCount = 0;
    private int score = 0;

    private bool levelCompleted = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void UpdateUI()
    {
        normalFlowerText.text = "Normal Flowers: " + normalFlowerCount;
        specialFlowerText.text = "Special Flowers: " + specialFlowerCount;
        scoreText.text = "Score: " + score;
    }

    public void AddScore(Collectible.CollectibleType type, int points)
    {
        switch (type)
        {
            case Collectible.CollectibleType.NormalFlower:
                normalFlowerCount++;
                break;

            case Collectible.CollectibleType.SpecialFlower:
                specialFlowerCount++;
                Victory();
                break;
        }

        score += points;
        UpdateUI();
    }

    public void Victory()
    {
        if (levelCompleted) return;
        levelCompleted = true;

        if (messageText != null) messageText.text = "¡Ganaste! 🎉";
        Debug.Log("Victory!");
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (levelCompleted) return;
        levelCompleted = true;

        if (messageText != null) messageText.text = "Game Over ☠️";
        Debug.Log("GameOver");
        Time.timeScale = 0f;
    }
}


    