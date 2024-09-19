using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0; // 플레이어 점수
    public GameObject gameOverScreen; // 게임 오버 화면
    public UnityEngine.UI.Text scoreText;  // 점수 표시를 위한 UI 텍스트

    // 점수를 추가하는 메서드입니다 / Method to add score
    [ContextMenu("Add Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    // 게임 오버를 처리하는 메서드입니다 / Method to handle game over
    [ContextMenu("Trigger Game Over")]
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over");
    }

    // 게임을 재시작하는 메서드입니다 / Method to restart the game
    [ContextMenu("Restart Game")]
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
