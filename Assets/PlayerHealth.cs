using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;       // プレイヤーの最大ヘルス
    private int currentHealth;        // プレイヤーの現在のヘルス
    public Image healthBar;           // HPゲージのUI Imageコンポーネント

    void Start()
    {
        currentHealth = maxHealth;    // ゲーム開始時のヘルス設定
        UpdateHealthBar();            // 初期HPゲージの更新
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            TakeDamage(10);           // 敵に当たったときのダメージ
        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            TakeDamage(15);           // 敵に当たったときのダメージ
        }
        if (collision.gameObject.CompareTag("Enemy3"))
        {
            TakeDamage(20);           // 敵に当たったときのダメージ
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;      // ヘルスを減少
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // ヘルスを0以上、最大ヘルス以下に制限
        UpdateHealthBar();            // HPゲージの更新

        if (currentHealth <= 0)
        {
            Die();                    // ヘルスが0以下になった場合の処理
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;  // HPゲージの割合を設定
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // プレイヤーが死亡したときの処理（例: ゲームオーバー画面を表示）
        Destroy(gameObject);  // プレイヤーオブジェクトを削除
        SceneManager.LoadScene("GameOverScene");
    }
}
