using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static public int time_basic = 0, time_wsec = 0, time_sec = 0, time_min = 0;
    static public bool countining = false;
    [SerializeField] Text time_show;

    void Start()
    {
        
    }

    IEnumerator timer(){

        yield return new WaitForSeconds(0.1f);
        time_basic+=1;
        time_wsec = time_basic % 600 % 10;
        time_sec = time_basic % 600 / 10;
        time_min = time_basic / 600;

        time_show.text = time_min.ToString("00")+":"+time_sec.ToString("00")+":"+time_wsec.ToString("0");
        if(blockController.correct >= 2){
            countining = false;
            blockController.correct = 0;
            print("finish");
            //yield return new WaitForSeconds(1);
        }
        else countining = true;
    }

    void Update()
    {
        if(countining){
            StartCoroutine("timer");
            countining = false;
            //print(time_wsec);
        }

    }
}
