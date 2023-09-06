using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float      ForwardAccel          =   10f ;
    [SerializeField] private float      ReverseAccel          =    4f ;
    [SerializeField] private float      TurnStrength          =  100f ;
    [SerializeField] private float      GravityForce          =   10f ;
    [SerializeField] private float      MaxSpeed              =  180f ;


    [SerializeField] private float      TurboAmount           =    1f ;
    [SerializeField] private float      TurboBurnSpeed        =   .1f ;
    [SerializeField] private float      TurboRefillSpeed      =  .05f ;

                     private Vector3    SavedPos                      ;


                     private float      _speedInput           =    0f ;
                     private float      _turnInput            =    0f ;
                     private float      _DragValue            =    0f ;
                     private float      _turbo                =    1f ;

                     private Rigidbody  rb                            ;

                     private bool       Grounded                      ;

                     public LayerMask   WhatIsGround                  ;

                     public Transform   rayPoint                      ;

                     public float       groundRayLngth        =   .5f ;




    public float getTurboAmount()
    {
        return TurboAmount;
    }
    public bool getGrounded()
    {
        return Grounded;
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SavedPos = transform.position;
        rb = GetComponent<Rigidbody>();
        _DragValue = rb.drag;
    }




 private void Update()
    {
        if (!Grounded)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = SavedPos;
                transform.Rotate(0f,120f , 0f);
            }
        }
       
        if (Input.GetAxis("Vertical") > 0 )
        {
            _speedInput = Input.GetAxis("Vertical") * ForwardAccel * 1000;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            _speedInput = Input.GetAxis("Vertical") * ReverseAccel * 1000;
        }

        _turnInput = Input.GetAxis("Horizontal");
        if (Grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, _turnInput * TurnStrength* Input.GetAxis("Vertical") * Time.deltaTime, 0f));
            if (Input.GetKey(KeyCode.Space)  && TurboAmount>=0)
            {
                TurboAmount -= TurboBurnSpeed * Time.deltaTime;
                _turbo = 1.5f;
                Debug.Log(_turbo);
            }
            else
            {
                if(TurboAmount<1f)   TurboAmount += TurboRefillSpeed * Time.deltaTime;
                _turbo = 1f;

            }

        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, _turnInput * TurnStrength * Time.deltaTime*1.5f));
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = SavedPos;
        }
        StartCoroutine(savePos());
       
        }


 

    private void FixedUpdate()
    {
       
        float _airDrag =0.1f;
        Grounded = false;
        RaycastHit _Hit;
        if(Physics.Raycast(rayPoint.transform.position,-transform.up,out _Hit, groundRayLngth,WhatIsGround))
        {
            Grounded = true;
        }

        if (Grounded)
        {
            rb.drag = _DragValue;
            if (Mathf.Abs(_speedInput) > 0)
            {
                rb.AddForce(transform.forward * _speedInput*_turbo);
            }
        }
        else
        {
            rb.drag = _airDrag;
            rb.AddForce(Vector3.up * -GravityForce *100);
        }
    }

    IEnumerator savePos()
    {
        yield return new WaitForSeconds(16f);
        SavedPos = transform.position;
    }
}
