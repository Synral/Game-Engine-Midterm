using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public float distance;
    public bool direction;
    float moveSpeed = 2.0f;
    float movedDistance = 0.0f;
    bool toggleDirection = false;
    float delay = 2.0f;
    private GameObject target = null;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (target!=null)
            target.transform.position = transform.position + offset;
        if (delay <= 0.0f)
        {

            if (movedDistance <= 0.0f)
            {
                toggleDirection = !toggleDirection;
                delay = 2.0f;
            }
            
            else if (movedDistance >= distance)
            {
                toggleDirection = !toggleDirection;
                delay = 2.0f;
            }
        if (!direction)
        {
            if (toggleDirection)
            {
                transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
                movedDistance += moveSpeed * Time.deltaTime;
            }
            else if (!toggleDirection)
            {
                transform.position = transform.position - new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
                movedDistance -= moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (toggleDirection)
            {
                transform.position = transform.position + new Vector3(0.0f, 0.0f, moveSpeed * Time.deltaTime);
                movedDistance += moveSpeed * Time.deltaTime;
            }
            else if (!toggleDirection)
            {
                transform.position = transform.position - new Vector3(0.0f, 0.0f, moveSpeed * Time.deltaTime);
                movedDistance -= moveSpeed * Time.deltaTime;
            }
        }
    }
}
    private void OnTriggerStay(Collider other)    
    {
        if (other.gameObject.tag == "Player")
            {
                target = other.gameObject;
                offset = target.transform.position - transform.position;
            }
    }
    private void OnTriggerExit(Collider other)    
    {
        if (other.gameObject.tag == "Player")
            {
                target = null;
            }
    }
}
