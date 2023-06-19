using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCollect : MonoBehaviour
{

    public Text MyscoreText;
    public float ScoreNum;
    private AdsInitializer adsInit;



    void Start(){
        ScoreNum = PlayerPrefs.GetFloat("score");
        MyscoreText.text = "Score : " + ScoreNum;
    }

    public void CoinReward()
    {
        MyscoreText.text = "Score : " + ScoreNum + 3;
    }

    private void OnTriggerEnter2D(Collider2D Coin){
        if(Coin.tag == "Coin"){
            ScoreNum++;
            Destroy(Coin.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
        }
    }

    public void rewardTaken()
    {
        ScoreNum++;
        ScoreNum++;
        ScoreNum++;
        MyscoreText.text = "Score : " + ScoreNum;
    }

    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("score", ScoreNum);
        //Debug.Log("Score: " + PlayerPrefs.GetFloat("score"));
        PlayerPrefs.Save();

    }


}