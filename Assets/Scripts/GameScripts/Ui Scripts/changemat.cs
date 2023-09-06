using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changemat : MonoBehaviour
{
    Color color;
    // Start is called before the first frame update
    void Start()
    {
       color= gameObject.GetComponent<keepcolor>().color;
         
        gameObject.GetComponent<MeshRenderer>().material.color = color;
        Debug.Log(gameObject.GetComponent<MeshRenderer>().material.color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
