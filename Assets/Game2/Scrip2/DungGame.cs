using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungGame : MonoBehaviour
{
    private bool gamePaused = false;

    void Update()
    {
        // Kiểm tra nếu phím Q được nhấn và giữ
        if (Input.GetKey(KeyCode.Q))
        {
            // Dừng trò chơi nếu chưa dừng
            if (!gamePaused)
            {
                PauseGame();
            }
        }
        else
        {
            // Tiếp tục trò chơi nếu đang dừng và phím Q đã được thả ra
            if (gamePaused)
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Dừng thời gian trong trò chơi
        gamePaused = true;
        Debug.Log("Game paused.");
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Tiếp tục thời gian trong trò chơi
        gamePaused = false;
        Debug.Log("Game resumed.");
    }
}