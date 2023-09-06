using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    public GameObject scoreText;
    public int score=0;
     void OnTriggerEnter(Collider other)
    {
        score++;
       
    }
    private void LateUpdate()
    {
        scoreText.GetComponent<Text>().text = "" + score;
    }
}
