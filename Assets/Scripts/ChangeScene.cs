﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneLoader(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}