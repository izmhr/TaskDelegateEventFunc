// デリゲート(Delegate)やイベント(Event)とは【C#】
// http://kan-kikuchi.hatenablog.com/entry/Delegate
// C# デリゲートについて
// https://qiita.com/ysn551/items/71fe3f332ea9a3114d36

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDelegateDoer : MonoBehaviour
{
    public SimpleDelegate simpleDelegate;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            simpleDelegate.CallFromOutside((x, y) => x + y);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SimpleDelegate.HogeDelegate hogeDelegate = (x, y) => x * y;
            simpleDelegate.CallFromOutside(hogeDelegate);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            //simpleDelegate.hogeDelegate += (x, y) => x + y;
            simpleDelegate.hogeDelegate = new SimpleDelegate.HogeDelegate(Method1) + new SimpleDelegate.HogeDelegate(Method2);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            simpleDelegate.hogeDelegate += Method2;
        }
    }

    int Method1(int x, int y)
    {
        Debug.Log(x + y);
        return x + y;
    }

    int Method2(int x, int y)
    {
        Debug.Log(x * y * y);
        return x * y * y;
    }
}
