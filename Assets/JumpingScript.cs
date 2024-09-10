using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    public float jumpForce = 10f; // �W�����v�̗�
    public float jumpInterval = 2f; // �W�����v����Ԋu�i�b�j

    private Rigidbody2D rb;
    private float nextJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextJumpTime = Time.time; // ����̃W�����v������ݒ�
    }

    void Update()
    {
        // ���݂̎��Ԃ����ɃW�����v���鎞�Ԃ��߂����ꍇ
        if (Time.time >= nextJumpTime)
        {
            Jump();
            nextJumpTime = Time.time + jumpInterval; // ���̃W�����v�̎��Ԃ�ݒ�
        }
    }

    void Jump()
    {
        // Rigidbody2D���ݒ肳��Ă���ꍇ�ɂ̂݃W�����v����
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Y���̑��x�����Z�b�g
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // �W�����v�͂�������
        }
    }
}
