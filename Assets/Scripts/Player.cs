using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proj1;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Script: Start()");
        item obj = new item();
        obj.Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
