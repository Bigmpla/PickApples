using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject BadapplePrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 20f;
    public float chanceToChangeDirection = 0.02f;
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 1f);
     
    }
    void DropBadApple()
    {
        GameObject apple1 = Instantiate<GameObject>(BadapplePrefab);
        apple1.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    void DropApple()
    {   
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        if(UnityEngine.Random.value < 0.5)
        {
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
        else
        {
            Invoke("DropBadApple", secondsBetweenAppleDrops);
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        //基本运动
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //改变方向
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//右移
        }else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//左移
        }

    }

    void FixedUpdate()
    {
        if (UnityEngine.Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }

   
}
