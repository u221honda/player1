using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isInvincible = false;

    void Start()
    {
      
    }

    void Update()
    {
        // ここで無敵状態の更新などを行う
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            // 敵に当たった時の処理
            StartCoroutine(InvincibleCoroutine());
            // ダメージを受けたら画面を光らせる
            StartCoroutine(FlashScreenCoroutine());
        }
    }
}
