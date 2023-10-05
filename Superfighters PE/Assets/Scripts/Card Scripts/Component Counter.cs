using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentCounter : MonoBehaviour
{
    [Header("Счетчик компонентов")]
    public bool isExitCard;
    [SerializeField] private Text _textScore;
    public int scoreEnemy;
    [SerializeField][HideInInspector] private int _emptyCount;

    private void FixedUpdate()
    {
        if (isExitCard == true && _emptyCount != 1)
        {
            scoreEnemy = Random.Range(0,22);
            _emptyCount++;
        }
        _textScore.text = scoreEnemy.ToString();
    }
}
