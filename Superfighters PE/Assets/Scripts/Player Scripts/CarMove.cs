using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMove : MonoBehaviour
{
    [Header("Управление")]
    public Transform SelfTransform;
    private Vector3 _force;
    [Space(30)]
    [Header("Доступ к прокачкам и прочему")]
    public PlayerManager PL;
    public GameObject Bumper;
    public GameObject Obves;
    public GameObject Spoiler;
    [SerializeField] private int money;
    [SerializeField] private int souls;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject ShopText;
    public bool isShop = false;
    [Space(30)]
    [Header("Текста")]
    public Text _textMoney;
    public Text _textSouls;
    [Header("Для получения сохранений о покупке прокачки")]
    [SerializeField] private int isSpoiler;
    [SerializeField] private int isBumper;
    [SerializeField] private int isObves;
    [Space(30)]
    [Header("Задния от Тайлеров")]
    public int danje1;
    public int danje2;
    [Space(30)]
    [Header("Выполненые задания")]
    [SerializeField] private GameObject NPC1;
    [SerializeField] private GameObject NPC2;
    [SerializeField] private GameObject NPC3;
    [SerializeField] private GameObject NPC4;
    [SerializeField] private GameObject dunj1;
    [SerializeField] private GameObject dunj2;
    [SerializeField] private GameObject EndPanel;
    [Space(30)]
    [Header("Типо диалоговые окна")]
    [SerializeField] private GameObject Dialoge1;
    [SerializeField] private GameObject Dialoge2;
    [SerializeField] private int completeD1;
    [SerializeField] private int completeD2;
    [SerializeField] private int completeN3;
    [SerializeField] private int completeN4;
    [SerializeField] private int bossComplete;
    [SerializeField] private GameObject WarningBOSS;
    [SerializeField] private GameObject BossOBJ;
    private void Start()
    {
        money = PlayerPrefs.GetInt("Money", money);
        souls = PlayerPrefs.GetInt("CountSouls", souls);
        danje1 = PlayerPrefs.GetInt("isDanje1", danje1);
        danje2 = PlayerPrefs.GetInt("isDanje2", danje2);
        completeD1 = PlayerPrefs.GetInt("CompleteDanje1", completeD1);
        completeD2 = PlayerPrefs.GetInt("CompleteDanje2", completeD2);
        completeN3 = PlayerPrefs.GetInt("NPC3", completeN3);
        completeN4 = PlayerPrefs.GetInt("NPC4", completeN4);
        bossComplete = PlayerPrefs.GetInt("Boss", bossComplete);
    }
    void Update()
    {
        if (isSpoiler == 1)
        {
            Spoiler.SetActive(true);
        }
        if (isBumper == 1)
        {
            Bumper.SetActive(true);
        }
        if (isObves == 1)
        {
            Obves.SetActive(true);
        }
        if (completeD1 == 1)
        {
            Dialoge1.SetActive(false);
            NPC1.SetActive(false);
            dunj1.SetActive(false);
        }
        if (completeD2 == 1)
        {
            Dialoge2.SetActive(false);
            NPC2.SetActive(false);
            dunj2.SetActive(false);
        }
        if (completeN3 == 1)
        {
            NPC3.SetActive(false);
        }
        if (completeN4 == 1)
        {
            NPC4.SetActive(false);
            // EndPanel.SetActive(true);
            WarningBOSS.SetActive(true);
            BossOBJ.SetActive(true);
        }
        if (bossComplete == 1)
        {
            EndPanel.SetActive(true);
        }
        _textMoney.text = money.ToString("Деньги: #");
        _textSouls.text = souls.ToString("Души: #");
        money = PlayerPrefs.GetInt("Money", money);
        souls = PlayerPrefs.GetInt("CountSouls", souls);
        isSpoiler = PlayerPrefs.GetInt("Spoiler", isSpoiler);
        isBumper = PlayerPrefs.GetInt("Bumper", isBumper);
        isObves = PlayerPrefs.GetInt("Obves", isObves);

        SelfTransform.position += _force;

        if (Input.GetKey(KeyCode.W))
        {
            _force += (SelfTransform.up * Time.deltaTime) * 0.15f;
        }
        else
        {
            _force = Vector3.Lerp(_force, Vector3.zero, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _force -= (SelfTransform.up * Time.deltaTime) * 0.06f;
        }
        else
        {
            _force = Vector3.Lerp(_force, Vector3.zero, Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            SelfTransform.Rotate(0, 0, 0.5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            SelfTransform.Rotate(0, 0, -0.5f);
        }
        if (isShop == true && Input.GetKeyDown(KeyCode.E))
        {
            Shop.SetActive(!Shop.activeInHierarchy);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traider"))
        {
            ShopText.SetActive(true);
            isShop = true;
        }
        if (collision.gameObject.CompareTag("NPC1"))
        {
            danje1 = 1;
            PlayerPrefs.SetInt("isDanje1", danje1);
            Dialoge1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("NPC2"))
        {
            danje2 = 1;
            PlayerPrefs.SetInt("isDanje2", danje2);
            Dialoge2.SetActive(true);
        }
        if (collision.gameObject.CompareTag("NPC3"))
        {
            SceneManager.LoadScene(4);
        }
        if (collision.gameObject.CompareTag("NPC4"))
        {
            SceneManager.LoadScene(5);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            SceneManager.LoadScene(6);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Entrance1"))
        {
            if (danje1 == 1)
            {
                SceneManager.LoadScene(2);
            }
        }
        if (collision.gameObject.CompareTag("Entrance2"))
        {
            if (danje2 == 1)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traider"))
        {
            ShopText.SetActive(false);
            isShop = false;
        }
    }
}
