using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class New_Record : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        if (Basket.new_record)
        {
            gt.text = "Congratulate!You get a new record!";
        }
        else
        {
            gt.text = "Cheer on!You can get a new record next round!";
        }

    }
}
