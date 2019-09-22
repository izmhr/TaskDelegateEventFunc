// デリゲート(Delegate)やイベント(Event)とは【C#】
// http://kan-kikuchi.hatenablog.com/entry/Delegate

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDelegate : MonoBehaviour
{
    public delegate int HogeDelegate(int x, int y);
    public HogeDelegate hogeDelegate;

    void Start()
    {
        //hogeDelegate = new HogeDelegate((x, y) => (int)Mathf.Max(x, y));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 外部から delegate を複数登録している（便宜上 public で公開して += で積んでる）
            Debug.Log(hogeDelegate(2, 3));
        }
    }

    public void CallFromOutside(HogeDelegate _hogeDelegate)
    {
        Debug.Log(_hogeDelegate(1, 2));
    }
}
