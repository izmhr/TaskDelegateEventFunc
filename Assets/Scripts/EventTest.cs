// [関数指向] イベント
// https://ufcpp.net/study/csharp/sp_event.html#event-keyword

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public delegate void KeyboadEventHandler(char eventCode);
    public event KeyboadEventHandler OnKeyDown;

    void Start()
    {

    }

    void Update()
    {
        // イベントの登録
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 複数回登録することができる
            // これは delegate の仕組みを使っているから。
            OnKeyDown += eventHandler;
        }

        // 登録済みイベントを発火する
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 複数回登録した場合は、複数回発火する。
            OnKeyDown('$');
        }
    }

    void eventHandler(char c)
    {
        Debug.Log(c);
        // イベントが一度実行されたら、自分自身をイベントから解除する。
        OnKeyDown -= eventHandler;
    }
}
