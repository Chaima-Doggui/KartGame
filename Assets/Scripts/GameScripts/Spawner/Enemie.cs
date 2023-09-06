using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemie : MonoBehaviour
{
    public Transform player;
    public float range = 20f;
    NavMeshAgent agent;
   
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.transform.GetComponent<CountScore>()!=null)
        collision.transform.GetComponent<CountScore>().score--;
    }

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        //compare the distance between the player and the ai and check if he is within a certain distance
        if (distance <= range)
        {


            //agent.SetDestination(player.position);
            agent.SetDestination(player.position);

            if (distance <= agent.stoppingDistance)
            {
                Vector3 direction = player.position - transform.position;
                direction.y = 0f;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 150f);

           
            }


        }





    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}
