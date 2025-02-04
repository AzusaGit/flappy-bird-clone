using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject introText;
    public GameObject gameOverText;

    private bool gameStarted = false;

    void Start()
    {
        Time.timeScale = 0;
        introText.SetActive(true);
        gameOverText.SetActive(false);
    }

    void Update()
    {
        if (!gameStarted && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            StartGame();
        }

        if (PlayerController.instance.isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        introText.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
