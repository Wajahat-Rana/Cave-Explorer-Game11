using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    private PlayerScore playerScore;
    private float minX = 0f, maxX = 75f;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScore.isAlive){
            Vector3 temp = transform.position;
            temp.x = player.transform.position.x;
            if(temp.x < minX){
                temp.x = minX;
            }

            if(temp.x > maxX){
                temp.x = maxX;
            }
            temp.y = player.transform.position.y;
            transform.position = temp;
        }
    }
}
