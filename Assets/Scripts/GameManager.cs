﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void MoveToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoStage(string stage)
    {
        SceneManager.LoadScene(stage);
        Time.timeScale = 1;
    }
}
