using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSystem : MonoBehaviour
{
    [Header("������� ��� ������� � ������� �� ������� �������")]
    [SerializeField] private int priceSoulsePurchase;
    [SerializeField] private int priceSoulseSell;
    [Space(30)]
    [Header("������")]
    [SerializeField] private float startBTWtime;
    [SerializeField] private float BTWtime;

    private void Update()
    {
        BTWtime -= Time.deltaTime;
        if (BTWtime <= 0)
        {
            priceSoulsePurchase = Random.Range(50, 300);
            priceSoulseSell = Random.Range(70, 250);
            BTWtime = startBTWtime;
        }
    }
}
