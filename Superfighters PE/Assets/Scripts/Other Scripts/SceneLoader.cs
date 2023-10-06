using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public PlayerManager PM;
    private int souls;
    private void Start()
    {
        souls = PlayerPrefs.GetInt("CountSouls", souls);
    }
    public void SceneLoad(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void WinSceneLoad(int sceneIndex)
    {
        souls++;
        PlayerPrefs.SetInt("CountSouls", souls);
        SceneManager.LoadScene(sceneIndex);
    }

}
