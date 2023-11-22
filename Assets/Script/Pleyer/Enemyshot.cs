using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;
    private float ballSpeed = 10.0f;
    private float time = 1.0f;

    private int vecX;
    private int vecY;
    void Update()
    {
        //transform.LookAt(player.transform);//ここを編集したら玉がplayerに向かわなくなるはず
        time -= Time.deltaTime;
        if(time <= 0)
        {
           
           vecX = Random.Range(-3,3);
           vecY = Random.Range(-3,3);
            BallShot();
            time = 1.0f;//ballの速度
        }
    }
 
    void BallShot()
    {
        //新しいボールを生成して、発射する
        GameObject shotObj = Instantiate(ball,new Vector3(vecX,vecY,30) , Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = -transform.forward * ballSpeed;
        //Objectを消す関数
       Destroy(shotObj, 10f);                                                                       
    }
}