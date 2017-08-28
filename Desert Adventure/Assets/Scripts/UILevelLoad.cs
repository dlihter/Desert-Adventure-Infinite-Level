using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelLoad : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Application.LoadLevel(1);
    }
}
