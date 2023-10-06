using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private bool isShop = false;
    [Space(30)]
    [Header("Текста")]
    public Text _textMoney;
    public Text _textSouls;
    [Header("Для получения сохранений о покупке прокачки")]
    [SerializeField] private int isSpoiler;
    [SerializeField] private int isBumper;
    [SerializeField] private int isObves;
    private void Start()
    {
        money = PlayerPrefs.GetInt("Money", money);
        souls = PlayerPrefs.GetInt("CountSouls", souls);
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
        _textMoney.text = money.ToString("Деньги: #");
        _textSouls.text = souls.ToString("Души: #");
        money = PlayerPrefs.GetInt("Money", money);
        souls = PlayerPrefs.GetInt("CountSouls", souls);

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
            _force -= (SelfTransform.up * Time.deltaTime) * 0.1f;
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
