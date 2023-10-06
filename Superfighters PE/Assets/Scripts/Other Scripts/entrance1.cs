using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entrance1 : MonoBehaviour
{
    public bool dungeon1 = false;
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SceneManager.LoadScene("")
        dungeon1 = true;
        Debug.Log("1");
    }
}
