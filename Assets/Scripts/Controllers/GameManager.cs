using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int diamondCount;
    public int lifeCount;

    void Awake(){
        MakeSingleton();
    }
    private void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

}
}