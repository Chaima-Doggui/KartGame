using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour
{
    public Dropdown dp;
    public void Quit()
    {
        Application.Quit();

    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + dp.value);
    }

}
