using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    public Button leftButton; // ���{�^���̎Q��
    public Button rightButton; // �E�{�^���̎Q��
    public float moveSpeed = 5f; // �ړ����x
    public float smoothTime = 0.3f; // �ړ��̊��炩���i�X���[�W���O���ԁj
    private Vector3 velocity = Vector3.zero; // �ړ��̑��x��ێ����邽�߂̕ϐ�

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Start()
    {
        // ���E�{�^���̃C�x���g���X�i�[��ݒ�
        AddButtonListeners(leftButton, OnLeftButtonPressed, OnButtonReleased);
        AddButtonListeners(rightButton, OnRightButtonPressed, OnButtonReleased);
    }

    void Update()
    {
        // �ړ��x�N�g��������
        Vector3 moveDirection = Vector3.zero;
        if (isMovingLeft)
        {
            moveDirection = Vector3.left;
        }
        else if (isMovingRight)
        {
            moveDirection = Vector3.right;
        }

        // �ړ��x�N�g�����^�[�Q�b�g�ʒu�ɔ��f
        Vector3 targetPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // ���݈ʒu��ڕW�ʒu�Ɍ������Ċ��炩�Ɉړ�������
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }

    private void OnLeftButtonPressed()
    {
        isMovingLeft = true; // ���ړ���L���ɂ���
        isMovingRight = false; // �E�ړ��𖳌��ɂ���
    }

    private void OnRightButtonPressed()
    {
        isMovingRight = true; // �E�ړ���L���ɂ���
        isMovingLeft = false; // ���ړ��𖳌��ɂ���
    }

    private void OnButtonReleased()
    {
        isMovingLeft = false; // ���ړ��𖳌��ɂ���
        isMovingRight = false; // �E�ړ��𖳌��ɂ���
    }

    private void AddButtonListeners(Button button, System.Action onPress, System.Action onRelease)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        // �{�^���������ꂽ�Ƃ��̃C�x���g��ݒ�
        EventTrigger.Entry entryDown = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerDown
        };
        entryDown.callback.AddListener((data) => { onPress(); });
        trigger.triggers.Add(entryDown);

        // �{�^���������ꂽ�Ƃ��̃C�x���g��ݒ�
        EventTrigger.Entry entryUp = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerUp
        };
        entryUp.callback.AddListener((data) => { onRelease(); });
        trigger.triggers.Add(entryUp);
    }
}
