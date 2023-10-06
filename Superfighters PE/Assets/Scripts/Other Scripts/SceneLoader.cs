using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public PlayerManager PM;
    private int souls;
    private int danj1;
    private int danj2;
    private void Start()
    {
        souls = PlayerPrefs.GetInt("CountSouls", souls);
    }
    public void SceneLoad(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void WinSceneLoadDANJE1(int sceneIndex)
    {
        souls++;
        danj1 = 1;
        PlayerPrefs.SetInt("CountSouls", souls);
        SceneManager.LoadScene(sceneIndex);
        PlayerPrefs.SetInt("isDanje1", danj1);
    }
    public void WinSceneLoadDANJE2(int sceneIndex)
    {
        souls++;
        danj2 = 1;
        PlayerPrefs.SetInt("CountSouls", souls);
        SceneManager.LoadScene(sceneIndex);
        PlayerPrefs.SetInt("isDanje1", danj2);
    }

}
