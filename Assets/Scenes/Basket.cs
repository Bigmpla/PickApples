using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    static public int score_one_round = 0;
    public Text scoreGT;
    static public bool new_record = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        scoreGT = scoreGo.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToViewportPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x * 60;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject; 
        if(collidedWith.tag == "Apple" || collidedWith.tag == "BadApple")
        {
            Destroy(collidedWith); 

            
        }

        int score = int.Parse(scoreGT.text);
        if(collidedWith.tag == "Apple")score += 100;
        else if(collidedWith.tag == "BadApple") score -= 100;
        scoreGT.text = score.ToString();
        score_one_round = score;
        if (score > HighScore.score)
        {
            HighScore.score = score;
            new_record = true;
        }
    }
}
