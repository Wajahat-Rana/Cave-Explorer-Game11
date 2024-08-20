using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public bool isAlive;
     void Awake()
    {
        isAlive = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Skeleton")
        {
            isAlive = false;
            transform.position = new Vector3(0,2000,0);
        }
        if(other.gameObject.tag == "Cave"){
            Time.timeScale = 0;
        }
    }
}

