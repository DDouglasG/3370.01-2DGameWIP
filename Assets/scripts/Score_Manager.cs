using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour{
    public static Score_Manager Instance;
    public TMP_Text score_text;
    int score = 0;
    private void Awake(){
     Instance = this;   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        score_text.text =  "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void addPoints(){
        score += 1;
        score_text.text =  "Score: " + score.ToString();


    }
}
