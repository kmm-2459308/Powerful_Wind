using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    public Button leftButton; // 左ボタンの参照
    public Button rightButton; // 右ボタンの参照
    public float moveSpeed = 5f; // 移動速度
    public float smoothTime = 0.3f; // 移動の滑らかさ（スムージング時間）
    private Vector3 velocity = Vector3.zero; // 移動の速度を保持するための変数

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Start()
    {
        // 左右ボタンのイベントリスナーを設定
        AddButtonListeners(leftButton, OnLeftButtonPressed, OnButtonReleased);
        AddButtonListeners(rightButton, OnRightButtonPressed, OnButtonReleased);
    }

    void Update()
    {
        // 移動ベクトルを決定
        Vector3 moveDirection = Vector3.zero;
        if (isMovingLeft)
        {
            moveDirection = Vector3.left;
        }
        else if (isMovingRight)
        {
            moveDirection = Vector3.right;
        }

        // 移動ベクトルをターゲット位置に反映
        Vector3 targetPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // 現在位置を目標位置に向かって滑らかに移動させる
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }

    private void OnLeftButtonPressed()
    {
        isMovingLeft = true; // 左移動を有効にする
        isMovingRight = false; // 右移動を無効にする
    }

    private void OnRightButtonPressed()
    {
        isMovingRight = true; // 右移動を有効にする
        isMovingLeft = false; // 左移動を無効にする
    }

    private void OnButtonReleased()
    {
        isMovingLeft = false; // 左移動を無効にする
        isMovingRight = false; // 右移動を無効にする
    }

    private void AddButtonListeners(Button button, System.Action onPress, System.Action onRelease)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        // ボタンが押されたときのイベントを設定
        EventTrigger.Entry entryDown = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerDown
        };
        entryDown.callback.AddListener((data) => { onPress(); });
        trigger.triggers.Add(entryDown);

        // ボタンが離されたときのイベントを設定
        EventTrigger.Entry entryUp = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerUp
        };
        entryUp.callback.AddListener((data) => { onRelease(); });
        trigger.triggers.Add(entryUp);
    }
}
