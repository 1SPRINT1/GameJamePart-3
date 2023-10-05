using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public PlayerManager PM;
    public void SceneLoad(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void WinSceneLoad(int sceneIndex)
    {
        PM.CountSouls++;
        SceneManager.LoadScene(sceneIndex);
    }
}
