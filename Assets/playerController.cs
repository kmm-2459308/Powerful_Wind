using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    //Animator animator;
    float jumpForce = 1170.0f;
    float walkForce = 30.0f;
    float maxWalkspeed = 4.0f;

    //public float jumpForce = 5f;
    //private bool isGrounded; // �L�����N�^�[���n�ʂɂ��邩�ǂ���
    //private Rigidbody2D rb; // �������Z�p�̃R���|�[�l���g


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        //rb = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g�̎擾
                                          // this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    //public void RButtonDown()
    //{
    //    transform.Translate(1, 0, 0);
    //}
    //public void LButtonDown()
    //{
    //    transform.Translate(-1, 0, 0);
    //}

    public void JButtonDown()
    {
        if (this.rigid2D.linearVelocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }

        void Update()
    {
        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) &&
            this.rigid2D.linearVelocity.y == 0)
        //if(Input.GetMouseButtonDown(0) &&
        //    this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //���E�ړ�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�v���C���̑��x
        float speedx = Mathf.Abs(this.rigid2D.linearVelocity.x);

        //�X�s�[�h����
        if (speedx < this.maxWalkspeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //�v���C���̑��x�ɉ����ăA�j���[�V�������x��ς���
        //this.animator.speed = speedx / 2.0f;

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    /*public void Jump()
    {
        if (isGrounded) // �n�ʂɂ���Ƃ��̂݃W�����v
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true; // �n�ʂɐڐG���Ă���ꍇ
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false; // �n�ʂ��痣�ꂽ�ꍇ
        }
    }*/
}
