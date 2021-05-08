using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safebox : MonoBehaviour
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
                renderer.material.color = Color.green;
                playerController.safemode();
                //playerController.Die();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
