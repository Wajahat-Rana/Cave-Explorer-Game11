using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private TextMeshProUGUI diamondCount;
    private TextMeshProUGUI lifeCount;

    [SerializeField]
    private GameObject levelFinishedPanel;

    public int score;
    public int life;

    void Awake(){
        MakeInstance();
        lifeCount = GameObject.Find("Life Count").GetComponent<TextMeshProUGUI>();
        diamondCount = GameObject.Find("Diamond Count").GetComponent<TextMeshProUGUI>();
    }
    void OnEnable(){
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }
    void OnDisable(){
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode){
        if(scene.name == "Gameplay"){
            if(!GameManager.instance.playerDiedAndGameRestarted){
                score = 0;
                life = 3;
            }else{
                score = GameManager.instance.diamondCount;
                life = GameManager.instance.lifeCount;
            }
            diamondCount.text = 'x'+ (score/2).ToString();
            lifeCount.text = 'x'+ life.ToString();
        }
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
        StartCoroutine(playerDied());
        }

        IEnumerator playerDied(){
           yield return new WaitForSeconds(2f);

            if(life<0){
                SceneManager.LoadScene("Main Menu");
            }
            else{
                GameManager.instance.playerDiedAndGameRestarted = true;
                GameManager.instance.diamondCount = score;
                GameManager.instance.lifeCount = life;
                SceneManager.LoadScene("Gameplay");
            }
        }
        public void nextLevel(){
            //To Be Implemented
        }
        public void goToMainMenu(){
            levelFinishedPanel.SetActive(false);
            SceneManager.LoadScene("Main Menu");
        }
}

