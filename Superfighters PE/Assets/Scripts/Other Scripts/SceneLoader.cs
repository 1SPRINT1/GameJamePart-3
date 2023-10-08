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
    private int NPC3Complete;
    private int NPC4Complete;
    private int bossFight;
    private void Start()
    {
        souls = PlayerPrefs.GetInt("CountSouls", souls);
        danj1Complete = PlayerPrefs.GetInt("CompleteDanje1", danj1Complete);
        NPC3Complete = PlayerPrefs.GetInt("NPC3", NPC3Complete);
        bossFight = PlayerPrefs.GetInt("Boss", bossFight);
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
        PlayerPrefs.SetInt("CompleteDanje2", danj2Complete);
        SceneManager.LoadScene(sceneIndex);
    }
    public void WinSceneLoadNPC3(int sceneIndex)
    {
        souls++;
        NPC3Complete = 1;
        PlayerPrefs.SetInt("CountSouls", souls);
        PlayerPrefs.SetInt("NPC3", NPC3Complete);
        SceneManager.LoadScene(sceneIndex);
    }
    public void WinSceneLoadNPC4(int sceneIndex)
    {
        souls++;
        NPC4Complete = 1;
        PlayerPrefs.SetInt("CountSouls", souls);
        PlayerPrefs.SetInt("NPC4", NPC3Complete);
        SceneManager.LoadScene(sceneIndex);
    }
    public void BossFightEND(int sceneIndex)
    {
        souls++;
        souls++;
        souls++;
        bossFight = 1;
        PlayerPrefs.SetInt("Boss", bossFight);
        PlayerPrefs.SetFloat("CountSouls", souls);
        SceneManager.LoadScene(sceneIndex);
    }
}
