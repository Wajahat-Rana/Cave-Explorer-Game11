using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private TextMeshProUGUI diamondCount;
    private TextMeshProUGUI lifeCount;

    public int score;
    public int life;

    void Awake(){
        MakeInstance();
        lifeCount = GameObject.Find("Life Count").GetComponent<TextMeshProUGUI>();
        diamondCount = GameObject.Find("Diamond Count").GetComponent<TextMeshProUGUI>();
    }

    private void MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }

        public void incrementDiamond(){
            score++;
            diamondCount.text = 'x'+ (score/2).ToString();
        }
        public void decrementLife(){
            life--;
            if(life>=0){
            lifeCount.text = 'x'+ life.ToString();
        }
        }
}
