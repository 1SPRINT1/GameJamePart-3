using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int Money;
    public int CountSouls;
    public static PlayerManager instance;
    [Header("Данжи")]
    public bool isDanje1;
    public bool isDanje2;
    public int danje1;
    public int danje2;
    [Space(30)]
    [Header("Прокачка")]
    public int isSpoiler;
    public int isBumper;
    public int isObves;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (danje1 == 1)
        {
            isDanje1 = true;
        }
        if (danje2 == 1)
        {
            isDanje2 = true;
        }
    }
    private void Start()
    {
        CountSouls = PlayerPrefs.GetInt("CountSouls", CountSouls);
        danje1 = PlayerPrefs.GetInt("isDanje1", danje1);
        danje2 = PlayerPrefs.GetInt("isDanje2", danje2);
        Money = PlayerPrefs.GetInt("Money", Money);
        isBumper = PlayerPrefs.GetInt("Bumper", isBumper);
        isSpoiler = PlayerPrefs.GetInt("Spoiler", isSpoiler);
        isObves = PlayerPrefs.GetInt("Obves", isObves);
    }
}
