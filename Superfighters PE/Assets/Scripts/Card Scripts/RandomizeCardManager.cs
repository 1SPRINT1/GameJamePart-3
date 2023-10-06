using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCardManager : MonoBehaviour
{
    [Header("PosCards")]
    [SerializeField] private Transform posCard1;
    [SerializeField] private Transform posCard2;
    [SerializeField] private Transform posCard3;
    [SerializeField] private Transform posCard4;
    [SerializeField] private GameObject But1;
    [SerializeField] private GameObject But2;
    [SerializeField] private GameObject But3;
    [SerializeField] private GameObject But4;
    [Space(21)]
    [Header("Object Card")]
    [SerializeField] private GameObject[] Cards;
    public int countSpawn;
    public GameManager GM;
    public GameObject GO;


    public void AddCardPOS1()
    {
        Instantiate(Cards[Random.Range(0, Cards.Length)], posCard1.transform.position, Quaternion.identity);
        But1.SetActive(false);
        But2.SetActive(true);
    }
    public void AddCardPOS2()
    {
        Instantiate(Cards[Random.Range(0, Cards.Length)], posCard2.transform.position, Quaternion.identity);
        But2.SetActive(false);
        But3.SetActive(true);
    }
    public void AddCardPOS3()
    {
        Instantiate(Cards[Random.Range(0, Cards.Length)], posCard3.transform.position, Quaternion.identity);
        But3.SetActive(false);
        But4.SetActive(true);
    }
    public void AddCardPOS4()
    {
        Instantiate(Cards[Random.Range(0, Cards.Length)], posCard4.transform.position, Quaternion.identity);
        But4.SetActive(false);
        GM.isExitCard = true;
    }
    public void Winish()
    {
        GM.isWinished = true;
        GM.isExitCard = true;
        GO.SetActive(false);
    }
}
