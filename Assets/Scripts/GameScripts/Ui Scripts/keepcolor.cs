using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepcolor : MonoBehaviour
{
    
  static  Color colorgb;
  public Color color;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello there!");
        Debug.Log(colorgb);
        color = colorgb;
    }
   public void getcolor(Color colorrgb)
    {
        colorgb = colorrgb;
    }
}
