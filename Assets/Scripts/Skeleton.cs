using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    private float speed = 3f;
    public bool walkLeft;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }
    public void walk(){
        Vector3 tempPos = transform.position;
        Vector3 tempLocalScale = transform.localScale;
        if(walkLeft){
            tempPos.x -= speed * Time.deltaTime;
            tempLocalScale.x = -Mathf.Abs(transform.localScale.x);
        }else{
            tempPos.x += speed * Time.deltaTime;
            tempLocalScale.x = Mathf.Abs(transform.localScale.x);
        }
        transform.position = tempPos;
        transform.localScale = tempLocalScale;
    }
    IEnumerator changeDirection()
    {
        yield return new WaitForSeconds(3f);
        walkLeft = !walkLeft;
        StartCoroutine(changeDirection());
    }
}
