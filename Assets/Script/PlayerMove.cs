using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMove : MonoBehaviour
{
    private float speed = 5.0f;
 
    void Update()
    {   //操作部分
        if (Input.GetKey ("up")){
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey ("down")){
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey("right")){
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey ("left")){
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }
}