using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Доступ к счету персонажа")]
    public int _playerScore;
    [SerializeField] private Text _textScorePlayer;
    public bool isWinished = false;
    [Space(30)]
    [Header("Панельки")]
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [Header("Счетчик компонентов")]
    public bool isExitCard;
    [SerializeField] private Text _textScore;
    public int scoreEnemy;
    [SerializeField] [HideInInspector] private int _emptyCount;
    private void Update()
    {
        _textScore.text = scoreEnemy.ToString();
        _textScorePlayer.text = _playerScore.ToString();
        if (isWinished == true)
        {
             if (_playerScore > _emptyCount && _playerScore <= 21)
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
        if (isExitCard == true && _emptyCount != 1)
        {
            scoreEnemy = Random.Range(1, 22);
            _emptyCount++;
        }
        
    }
}
