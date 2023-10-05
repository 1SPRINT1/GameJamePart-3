using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Доступ к счету персонажа")]
    public int _playerScore;
    [SerializeField] private Text _textScorePlayer;
    [Space(30)]
    [Header("Доступ к Componen Counter")]
    public ComponentCounter CompomenetCount;
    public int enemyScore;
    [Space(30)]
    [Header("Панельки")]
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    private void FixedUpdate()
    {
        enemyScore = CompomenetCount.scoreEnemy;
        _textScorePlayer.text = _playerScore.ToString();
        if (_playerScore > enemyScore)
        {
            Debug.Log("По сути игрок победил вызываю панель Победы!");
            WinPanel.SetActive(true);
        }
        else
        {
            Debug.Log("По логике данной игры игрок проиграет иначе, Вызываю панель проигрыша");
            LosePanel.SetActive(true);
        }
    }
}
