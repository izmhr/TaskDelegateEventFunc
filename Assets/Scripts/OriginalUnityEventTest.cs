// 【Unity】UnityEventの用法と用量
// https://www.urablog.xyz/entry/2016/09/11/080000
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OriginalUnityEventTest : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.Events.UnityEvent myEvent = new UnityEngine.Events.UnityEvent();

    [System.Serializable]
    public class MyIntEvent : UnityEngine.Events.UnityEvent<int> { }
    [SerializeField]
    private MyIntEvent myIntEvent = new MyIntEvent();

    // [System.Serializable]を使ってEditor上に調整パラメータを出す
    // https://qiita.com/waken/items/30e087480626e3d8229d

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            myEvent.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // エディタ上でイベントを登録した場合、ここで登録した引数は無視される。
            myIntEvent.Invoke(123);
        }

        // スクリプトだけでイベントを加え、さらに、実行後自らを削除してみる例
        // https://answers.unity.com/questions/1492047/unityactionunityevent-remove-listener-from-within.html
        if (Input.GetKeyDown(KeyCode.T))
        {
            //SetEventFromCode(() => Debug.Log("Invoked Medthod whidh is added from code"));
            UnityAction myAction = null;
            myAction = new UnityAction(() =>
                {
                    Debug.Log("Invoked Medthod whidh is added from code");
                    myEvent.RemoveListener(myAction);
                });
            SetEventFromCode(myAction);
        }
    }

    public void SetEventFromCode(UnityAction action)
    {
        myEvent.AddListener(action);
    }
}
