using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketSystem : MonoBehaviour
{
    [Header("������� ��� ������� � ������� �� ������� �������")]
    [SerializeField] private int priceSoulsePurchase;
    [SerializeField] private int priceSoulseSell;
    [SerializeField] private Text _textPricePurchase;
    [Space(30)]
    [Header("������")]
    [SerializeField] private float startBTWtime;
    [SerializeField] private float BTWtime;
    [Space(30)]
    [Header("�������")]
    public PlayerManager PL;
    public CarMove CM;
    public int countSoulse;
    public int moneyCount;
    public int isBumper;
    public int isSpoiler;
    public int isObves;
    [SerializeField] private bool buyBumper;
    [SerializeField] private bool buySpoiler;
    [SerializeField] private bool buyObves;
    [SerializeField] private GameObject isBumperObj;
    [SerializeField] private GameObject isSpoilerObj;
    [SerializeField] private GameObject isObvesObj;
    [SerializeField] private bool isShop = false;

    private void Start()
    {
        BTWtime = startBTWtime;
        countSoulse = PlayerPrefs.GetInt("CountSoulse", countSoulse);
        moneyCount = PlayerPrefs.GetInt("Money", moneyCount);
        isBumper = PlayerPrefs.GetInt("Bumper", isBumper);
        isObves = PlayerPrefs.GetInt("Obves", isObves);
        isSpoiler = PlayerPrefs.GetInt("Spoiler", isSpoiler);
    }

    private void Update()
    {
        isShop = CM.isShop;
        countSoulse = PlayerPrefs.GetInt("CountSouls", countSoulse);
        moneyCount = PlayerPrefs.GetInt("Money", moneyCount);
        isBumper = PlayerPrefs.GetInt("Bumper", isBumper);
        isObves = PlayerPrefs.GetInt("Obves", isObves);
        isSpoiler = PlayerPrefs.GetInt("Spoiler", isSpoiler);
        _textPricePurchase.text = priceSoulsePurchase.ToString();
        BTWtime -= Time.deltaTime;
        if (BTWtime <= 0)
        {
            priceSoulsePurchase = Random.Range(50, 300);
            priceSoulseSell = Random.Range(70, 250);
            BTWtime = startBTWtime;
        }
        // ������ �������� ����� ����� ��� ����������� � �����������,
        // ���� ������ ����� ������ �� �� ����� ��� ��������
        if (isShop == true)
        {
            // ������� ��� �� ������
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (countSoulse > 0)
                {
                    countSoulse -= 1;
                    moneyCount += priceSoulsePurchase;
                    PlayerPrefs.SetInt("Money", moneyCount);
                    PlayerPrefs.SetInt("CountSouls", countSoulse);
                }
            }
            // ������� �������
            if (buyBumper == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    if (moneyCount >= 350)
                    {
                        moneyCount -= 350;
                        isBumper = 1;
                        buyBumper = true;
                        isBumperObj.SetActive(false);
                        PlayerPrefs.SetInt("Money", moneyCount);
                        PlayerPrefs.SetInt("Bumper", isBumper);
                    }
                }
            }

            // ������� ������
            if (buyObves == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    if (moneyCount >= 400)
                    {
                        isObves = 1;
                        moneyCount -= 400;
                        buyObves = true;
                        isObvesObj.SetActive(false);
                        PlayerPrefs.SetInt("Money", moneyCount);
                        PlayerPrefs.SetInt("Obves", isObves);
                    }
                }
            }
            // ������� ��������
            if (buySpoiler == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (moneyCount >= 500)
                    {
                        isSpoiler = 1;
                        moneyCount -= 500;
                        buySpoiler = true;
                        isSpoilerObj.SetActive(false);
                        PlayerPrefs.SetInt("Money", moneyCount);
                        PlayerPrefs.SetInt("Spoiler", isSpoiler);
                    }
                }
            }
        }
    }
    // ������ ���������� ����� � ������� ����� ����� ������� �� ������ 1,2,3 � �.�. �����������(���������!)
}
