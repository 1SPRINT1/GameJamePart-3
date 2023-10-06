using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSystem : MonoBehaviour
{
    [Header("Значнеи при Покупке и продаже со стороны Дракона")]
    [SerializeField] private int priceSoulsePurchase;
    [SerializeField] private int priceSoulseSell;
    [Space(30)]
    [Header("Таймер")]
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
