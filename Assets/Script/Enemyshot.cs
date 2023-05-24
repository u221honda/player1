using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;
    private float ballSpeed = 10.0f;
    private float time = 1.0f;

    void Update()
    {
        transform.LookAt(player.transform);
        time -= Time.deltaTime;
        if(time <= 0)
        {
            BallShot();
            time = 1.0f;
        }
    }
 
    void BallShot()
    {
        //新しいボールを生成して、発射する
        GameObject shotObj = Instantiate(ball, transform.position, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
        //Objectを消す関数
       Destroy(shotObj, 5f);                                                                       
    }
}