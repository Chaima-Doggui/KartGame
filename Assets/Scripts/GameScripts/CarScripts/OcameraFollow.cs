using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcameraFollow : MonoBehaviour
{
    
    public Transform target;
    [SerializeField] private float smooth = .125f;

    public Vector3 offset;
    private void Update()
    {
       

    }
    public void FixedUpdate()
    {
      
        Vector3 _smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smooth);
        transform.position = _smoothedPosition;
    }
}
