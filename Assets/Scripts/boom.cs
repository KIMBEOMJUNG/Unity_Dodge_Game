using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            Renderer renderer = other.GetComponent<Renderer>();
            if (playerController != null)
            {
                Destroy(gameObject);
                playerController.boommode();

                
                foreach (GameObject obj in BulletSpawner.objArray)
                {
                    Destroy(obj);
                }
                
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
