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
            time = 0.1f;
        }
    }
 
    void BallShot()
    {
        GameObject shotObj = Instantiate(ball, transform.position, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
        Destroy(shotObj, 5.0f); // ボールが5秒後に消えるように設定
    }
}