using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rightleft : MonoBehaviour
{

    public GameObject a;
    Color rgb;

    private Color rgb1;
    private void Start()
    {
        rgb1= new Color(0, 0, 0);
    }
    private void Update()
    {
        
        
    }

    public void next()
    {

        rgb = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        a.GetComponent<SpriteRenderer>().color = rgb;
        //Debug.Log(a.GetComponent<SpriteRenderer>().color);
        gameObject.GetComponent<keepcolor>().getcolor( a.GetComponent<SpriteRenderer>().color);
        rgb1 = rgb;
    }
    public void previous()
    {
        a.GetComponent<SpriteRenderer>().color = rgb1;
    }
}
