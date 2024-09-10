using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;       // �v���C���[�̍ő�w���X
    private int currentHealth;        // �v���C���[�̌��݂̃w���X
    public Image healthBar;           // HP�Q�[�W��UI Image�R���|�[�l���g

    void Start()
    {
        currentHealth = maxHealth;    // �Q�[���J�n���̃w���X�ݒ�
        UpdateHealthBar();            // ����HP�Q�[�W�̍X�V
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            TakeDamage(10);           // �G�ɓ��������Ƃ��̃_���[�W
        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            TakeDamage(15);           // �G�ɓ��������Ƃ��̃_���[�W
        }
        if (collision.gameObject.CompareTag("Enemy3"))
        {
            TakeDamage(20);           // �G�ɓ��������Ƃ��̃_���[�W
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;      // �w���X������
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // �w���X��0�ȏ�A�ő�w���X�ȉ��ɐ���
        UpdateHealthBar();            // HP�Q�[�W�̍X�V

        if (currentHealth <= 0)
        {
            Die();                    // �w���X��0�ȉ��ɂȂ����ꍇ�̏���
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;  // HP�Q�[�W�̊�����ݒ�
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // �v���C���[�����S�����Ƃ��̏����i��: �Q�[���I�[�o�[��ʂ�\���j
        Destroy(gameObject);  // �v���C���[�I�u�W�F�N�g���폜
        SceneManager.LoadScene("GameOverScene");
    }
}
