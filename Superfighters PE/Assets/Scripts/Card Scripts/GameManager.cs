using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("������ � ����� ���������")]
    public int _playerScore;
    [SerializeField] private Text _textScorePlayer;
    public bool isWinished = false;
    [Space(30)]
    [Header("��������")]
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [Header("������� �����������")]
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
               Debug.Log("�� ���� ����� ������� ������� ������ ������!");
                 WinPanel.SetActive(true);
             }
            else
             {
                Debug.Log("�� ������ ������ ���� ����� ��������� �����, ������� ������ ���������");
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
