using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public PlayerManager PM;
    private int souls;
    private int danj1Complete;
    private int danj2Complete;
    private void Start()
    {
        souls = PlayerPrefs.GetInt("CountSouls", souls);
        danj1Complete = PlayerPrefs.GetInt("CompleteDanje1", danj1Complete);
    }
    public void SceneLoad(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void WinSceneLoadDANJE1(int sceneIndex)
    {
        souls++;
        danj1Complete = 1;
        PlayerPrefs.SetInt("CountSouls", souls);
        SceneManager.LoadScene(sceneIndex);
        PlayerPrefs.SetInt("CompleteDanje1", danj1Complete);
    }
    public void WinSceneLoadDANJE2(int sceneIndex)
    {
        souls++;
        danj2Complete = 1;
        PlayerPrefs.SetInt("CountSouls", souls);
        SceneManager.LoadScene(sceneIndex);
        PlayerPrefs.SetInt("CompleteDanje2", danj2Complete);
    }

}
