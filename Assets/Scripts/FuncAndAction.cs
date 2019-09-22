// FuncとAction
// http://kan-kikuchi.hatenablog.com/entry/Delegate
// Func<T, TResult> , Action<T> デリゲートとは？ (C#プログラミング)
// https://www.ipentec.com/document/csharp-delegate-func-action-type

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncAndAction : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    // Action はあらかじめ delegate を書いておかなくても、コールバックをその場で簡易的に登録させてくれる方法
    public void Register(Action delegateMethod)
    {
        Debug.Log("Registered!! ");
        delegateMethod();
    }

    // 引数あり版 Action<var>
    public void Register2(Action<string> delegateMethod)
    {
        Debug.Log("Registered2! ");
        delegateMethod("input");
    }

    // 引数と返り値あり版 => Func<ret, var>
    public void Register3(Func<int, int> delegateMedhod)
    {
        Debug.Log("Registerd3! ");
        int ret = delegateMedhod(10);
        Debug.Log("returned " + ret);
    }

    // Func(T, TResult)
    // の定義
    // public delegate TResult Func<in T, out TResult>(T arg);
}
