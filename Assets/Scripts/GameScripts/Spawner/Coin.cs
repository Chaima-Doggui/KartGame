using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //instantiate it
    //define field
    //check ifthe player triggered it
    //change position
    public GameObject Prefab;
    private GameObject game;
    public Vector3 center;
    public Vector3 size;
    private Vector3 original;
    private bool spawn = false;


    private void Start()
    {
        
        Vector3 pos = transform.position;
      game=  Instantiate(Prefab, pos, transform.rotation);
        spawn = true;
    }
    private void Update()
    {
        if (spawn) 
        StartCoroutine(switchAndrun());
    }
  IEnumerator switchAndrun()
    {
        spawn = false;
        yield return new WaitForSeconds(5f);
        Vector3 pos = transform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0f, Random.Range(-size.z / 2, size.z / 2));
       game=  Instantiate(Prefab, pos, transform.rotation);
        spawn = true;
    }
     private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position,size);
    }
}
