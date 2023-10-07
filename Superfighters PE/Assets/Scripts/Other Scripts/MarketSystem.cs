using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketSystem : MonoBehaviour
{
    [Header("Значнеи при Покупке и продаже со стороны Дракона")]
    [SerializeField] private int priceSoulsePurchase;
    [SerializeField] private int priceSoulseSell;
    [SerializeField] private Text _textPricePurchase;
    [Space(30)]
    [Header("Таймер")]
    [SerializeField] private float startBTWtime;
    [SerializeField] private float BTWtime;
    [Space(30)]
    [Header("Доступы")]
    public PlayerManager PL;
    public CarMove CM;
    public int countSoulse;
    public int moneyCount;
    public int isBumper;
    public int isSpoiler;
    public int isObves;
    [SerializeField] private bool isShop = false;

    private void Start()
    {
        BTWtime = startBTWtime;
        countSoulse = PlayerPrefs.GetInt("CountSoulse", countSoulse);
        moneyCount = PlayerPrefs.GetInt("Money", moneyCount);
        isBumper = PlayerPrefs.GetInt("Bumper", isBumper);
        isObves = PlayerPrefs.GetInt("Obves", isObves);
        isSpoiler = PlayerPrefs.GetInt("Spoiler", isSpoiler);
        isShop = CM.isShop;
    }

    private void Update()
    {
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
        // Больша проверка нужно чтобы все сохранялось и покупкалось,
        // Если делать через кнопки то не будет это работать
        if (isShop == true)
        {
            // Продажа душ по кнопке
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
            // Покупка Бампера
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (moneyCount >= 350)
                {
                    moneyCount -= 350;
                    isBumper = 1;
                    PlayerPrefs.SetInt("Money", moneyCount);
                    PlayerPrefs.SetInt("Bumper", isBumper);
                }
            }
            // Покупка Обвеса
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (moneyCount >= 400)
                {
                    isObves = 1;
                    moneyCount -= 400;
                    PlayerPrefs.SetInt("Money", moneyCount);
                    PlayerPrefs.SetInt("Obves", isObves);
                }
            }
            // Покупка спойлера
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (moneyCount >= 500)
                {
                    isSpoiler = 1;
                    moneyCount -= 500;
                    PlayerPrefs.SetInt("Money", moneyCount);
                    PlayerPrefs.SetInt("Spoiler", isSpoiler);
                }
            }
        }
    }
    // Завтра переделать чтобы в апдейте искал через нажатие на кнопки 1,2,3 и т.д. ОБЯЗАТЕЛЬНО(Выполнено!)
    public void SellSouls()
    {
        if (countSoulse > 0)
        {
            countSoulse--;
            moneyCount += priceSoulsePurchase;
            PlayerPrefs.SetInt("Money", moneyCount);
        }
    }
    public void PurchaseBumper()
    {
        if (moneyCount >= 350)
        {
            moneyCount -= 350;
            isBumper = 1;
            PlayerPrefs.SetInt("Money", moneyCount);
            PlayerPrefs.SetInt("Bumper", isBumper);
        }
    }
    public void PurchaseObves()
    {
        if (moneyCount >= 400)
        {
            isObves = 1;
            moneyCount -= 400;
            PlayerPrefs.SetInt("Money", moneyCount);
            PlayerPrefs.SetInt("Obves", isObves);
        }
    }
    public void PurchaseSpoiler()
    {
        if (moneyCount >= 500)
        {
            isSpoiler = 1;
            moneyCount -= 500;
            PlayerPrefs.SetInt("Money",moneyCount);
            PlayerPrefs.SetInt("Spoiler", isSpoiler);
        }
    }
}
