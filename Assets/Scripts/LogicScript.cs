using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore; // 현재 플레이어의 점수 / Player's current score
    public Text scoreText; // UI에 표시될 점수 텍스트 / UI text to display the score
    public GameObject GameOverScreen;

    // 점수를 증가시키는 메서드 / Method to add score
    [ContextMenu("Increase Score")]
    public void AddScore()
    {
        playerScore = playerScore + 1; // 점수 증가 / Increase score
        scoreText.text = playerScore.ToString(); // UI 업데이트 / Update UI
    }

    // 게임 오버 처리 / this is related to game over
    public void restartgame()
    {
        Debug.Log("Current Scene Name: " + SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
