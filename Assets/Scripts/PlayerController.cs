using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Renderer renderer;
    public const float  speed = 8f;
    public static int hp = 10;
    public static bool safe = false;
    public static float deltaTime = 0;
    public static float timer = 10;
    public static float safeboxtimer = 120;
    public static bool nonesafebox = true;
    public static Color maincolor;
    public GameObject safeboxPrefab;
    public GameObject boomPrefab;
    public static bool noneboombox = true;
    public static float boomboxtimer = 60;

    public Text hpobj;
    // Start is called before the first frame update
    void Start()
    {
        hpobj = GameObject.Find("hpobj").GetComponent<Text>();
        hpobj.text = hp+"";
        playerRigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        maincolor = renderer.material.color;
        Instantiate(safeboxPrefab, new Vector3(4,1,4),Quaternion.identity);
        Instantiate(boomPrefab, new Vector3(1, 1, -4), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        //float upInput = Input.GetAxis("Jump");
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

       
        if (Input.GetButtonDown("Jump"))
        {
            transform.localScale = new Vector3(5, 5, 5);
            Debug.Log("plus plus~~!!");
        }
        if (Input.GetButtonDown("Fire3"))
        {
            transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("small small~~!!");
        }

        if(safe == true)
        {
            timer -= Time.deltaTime;
            //Debug.Log("time :" + Mathf.Ceil(timer));
            if(Mathf.Ceil(timer) <= 0)
            {
                safeoff();
            }
        }

        if(nonesafebox == false)
        {
            safeboxtimer -= Time.deltaTime;
            if (safeboxtimer <= 0)
            {
                Instantiate(safeboxPrefab, new Vector3(4, 1, 4), Quaternion.identity);
                safeboxtimer = 120;
            }
        }
        
        if(noneboombox == false)
        {
            Debug.Log("붐박스 진행중");
            boomboxtimer -= Time.deltaTime;
            if (boomboxtimer <= 0)
            {
                Debug.Log("붐박스 재생성");
                Instantiate(boomPrefab, new Vector3(1, 1, -4), Quaternion.identity);
                boomboxtimer = 60;
            }
        }


    }

    public void hit()
    {
        if(safe == false)
        {
            hp = hp - 2;
            Debug.Log("총알 충돌!! 체력:"+hp);
        }
        
        hpobj.text = hp+"";
        if(hp <= 0)
        {
            Die();
            Debug.Log("Player Die");
        }
    }

    public void safemode()
    {
        Debug.Log("Safe Item Mode");
        safe = true;
        nonesafebox = false;
        safeboxtimer = 120;
    }

    public void safeoff()
    {
        Debug.Log("Safe Item is expired");
        safe = false;
        renderer.material.color = maincolor;
        timer = 10;
    }

    public void boommode()
    {
        Debug.Log("붐박스 모드 진입");
        noneboombox = false;
        boomboxtimer = 60;
    }


    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }

}
