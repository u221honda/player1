using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private bool isInvincible = false;
    public float invincibleDuration = 3.0f; // 無敵状態の持続時間
    public float blinkInterval = 0.2f; // ポワント滅の間隔

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        if (playerSpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer コンポーネントがアタッチされていません。");
        }
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
        }
    }

    IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;

        // 無敵状態の持続時間だけ点滅する
        float elapsedTime = 0f;
        while (elapsedTime < invincibleDuration)
        {
            playerSpriteRenderer.enabled = !playerSpriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // 点滅終了後、無敵状態を解除し、SpriteRenderer を有効にする
        isInvincible = false;
        playerSpriteRenderer.enabled = true;
    }
}
