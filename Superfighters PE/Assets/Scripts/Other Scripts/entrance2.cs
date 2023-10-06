using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrance2 : MonoBehaviour
{
    public bool dungeon2 = false;
    public entrance1 dung1;
    public GameObject miniBoss;

    public Vector3 pos;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SceneManager.LoadScene("")
        dungeon2 = true;
        Debug.Log("2");

        if (dungeon2 == true & dung1.dungeon1 == true) 
        {
            Debug.Log("!!!");
            Instantiate(miniBoss, pos, Quaternion.identity);
        }
    }


}
