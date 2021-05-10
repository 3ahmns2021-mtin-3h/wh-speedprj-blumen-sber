using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blumen : MonoBehaviour
{
    private int spacePress;
    private int kPress;
    private bool isSpacePressed;
    private bool isKPessed;

    private float startTime, stopTime, timer;
    public GameObject prefabBlume;
    public GameObject parentObj;
    private bool isTimerRunning;
    


    // Start is called before the first frame update
    void Start()
    {
        spacePress = 0;
        kPress = 0;
        isTimerRunning = false;
        isKPessed = isSpacePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = stopTime + Time.time - startTime;
        int seconds = (int)timer % 60;

        if(isTimerRunning)
        {
            if(isSpacePressed && seconds >= 1)
            {
                isSpacePressed = false;
                TimerStop();
                TimerReset();
                CreateBlumen();
            }

            if(isKPessed && seconds >= 1)
            {
                isKPessed = false;
                TimerStop();
                TimerReset();
            }

        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            spacePress++;
            isSpacePressed = true;
            Debug.Log("space press " + spacePress);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            TimerStart();
            //Debug.Log(startTime);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            kPress++;
            isKPessed = true;
            Debug.Log("K Press " + kPress);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimerStart();
        }

    }
    void TimerStart()
    {
        if(isTimerRunning)
        {
            startTime = Time.time;
            isTimerRunning = true;
            
        }

        
    }
    
    

    void TimerStop()
    {
        if (isTimerRunning)
        {
            stopTime = Time.time;
            isTimerRunning = false;
        }

        if(isKPessed)
        {

        }
    }

    void TimerReset()
    {
        timer = startTime = stopTime = 0.0f;

    }

    public void CreateBlumen(int numberBlumen)
    {
        for(int i = 0; i < numberBlumen; i++)
        {
            Instantiate(prefabBlume, new Vector2(i * 2.0f, 0), Quaternion.identity, parentObj.transform);
        }
    }
}
