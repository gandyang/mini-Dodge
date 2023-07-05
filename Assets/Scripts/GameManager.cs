using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버시 활성화 할 텍스트 게임 컴포넌트
    public Text timeText; //생존시간을 표시할  Text컴포넌트
    public Text recordText; //최고기록을 표시할  Text컴포넌트

    private float surviveTime;
    private bool isGameover;
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover){
            surviveTime += Time.deltaTime;
            timeText.text = "Time : "+(int)surviveTime;
        }
        else{
            //게임종료 상태에서  R-재시작 을 누른경우
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("SampleSceen");
            }
        }
    }

    //게임종료 메서드
    public void EndGame(){
        isGameover =true;
        gameoverText.SetActive(true);

        //bestTime키로 이전스코어를 불러옴
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        //현재기록과 최고기록을 비교
        if(surviveTime > bestTime){
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime",bestTime);
        }

        recordText.text = "Best Time: "+(int)bestTime;
    }
}
