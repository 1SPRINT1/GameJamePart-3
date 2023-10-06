using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public int countCard;
    private int _empty;
    [SerializeField] private GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        GM = FindObjectOfType<GameManager>();
        if (_empty == 0)
        {
            GM._playerScore += countCard;
            _empty++;
        }
    }
}
