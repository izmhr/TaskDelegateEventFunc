// 初心者のためのTask.Run(), async/awaitの使い方
// https://qiita.com/Alupaca1363Inew/items/0126270bca99883605de

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    int index = 0;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Press: A");
            Debug.Log($"Update()\t\tthread ID : " + Thread.CurrentThread.ManagedThreadId);
            var task = HogeHogeAsync();
        }
    }

    // 返り値ありの重い処理
    private string HeavyMethod(string str)
    {
        Debug.Log($"HeavyMethod() called via Task.Run(() => )\tthread ID : " + Thread.CurrentThread.ManagedThreadId);

        // 何か重い処理
        Thread.Sleep(1000);

        return str + ": " + index++;
    }

    // 重い同期処理（返り値あり）を非同期にしたい場合
    public async Task HogeHogeAsync()
    {
        Debug.Log($"HogeHogeAsync()\tthread ID : " + Thread.CurrentThread.ManagedThreadId);
        var result = await Task.Run(() => HeavyMethod("hoge"));
        SomethingNextMethod(result);
    }

    private void SomethingNextMethod(string str)
    {
        Debug.Log(str);
    }
}
