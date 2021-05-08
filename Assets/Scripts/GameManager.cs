using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime; //1
    private bool isGameover;



    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;//2
        isGameover = false;//4
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");//3
            }
        }

    }
    public void EndGame()
    {
        isGameover = true;//5
        gameoverText.SetActive(true);
        var bestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestTime)//6
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time:" + (int)bestTime;
    }
}
