using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    readonly public float spawnRateMin = 0.5f;
    readonly public float spawnRateMax = 3f;
    static int count = 0;
    static int playerbar = 10;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

   public static ArrayList objArray = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
       
    }

    //PlayterController playController = FindObjectOfType<PlayerController>(); target = playerController.transform;

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn>= spawnRate)
        {
            
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

            //Debug.Log("count up! :" + count);
            count++;
            objArray.Add(bullet);

        }
        
    }
}
