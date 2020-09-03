using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float currentScale = 1.0f;
    public void SpeedUp10()
    {
        Time.timeScale = 1.0f;
        currentScale = 1.0f;
    }
    public void SpeedUp15()
    {
        Time.timeScale = 1.5f;
        currentScale = 1.5f;
    }
    public void SpeedUp20()
    {
        Time.timeScale = 2.0f;
        currentScale = 2.0f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = currentScale;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
