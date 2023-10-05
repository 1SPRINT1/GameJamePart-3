using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("������ � ����� ���������")]
    public int _playerScore;
    [SerializeField] private Text _textScorePlayer;
    [Space(30)]
    [Header("������ � Componen Counter")]
    public ComponentCounter CompomenetCount;
    public int enemyScore;
    [Space(30)]
    [Header("��������")]
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    private void FixedUpdate()
    {
        enemyScore = CompomenetCount.scoreEnemy;
        _textScorePlayer.text = _playerScore.ToString();
        if (_playerScore > enemyScore)
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
}
