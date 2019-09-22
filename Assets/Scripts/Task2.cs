// Taskを極めろ！async/await完全攻略
// https://qiita.com/acple@github/items/8f63aacb13de9954c5da

// async/awaitキーワード、そして「非同期メソッド」とは
// ・シグネチャにasyncを付けたメソッドのことを「非同期メソッド」と呼びます。
// ・非同期メソッドの特徴はただ一つ、文中でawaitキーワードを使えるようになることです。
// ・そして、awaitキーワードの効果は、「指定したTaskの完了を待つ」「そして、その結果を取り出す」ことです。
// ・最後に、非同期メソッドの戻り値は必ずTask/Task<T> になります
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Press: A");
            Debug.Log($"Update()\tthread ID : " + Thread.CurrentThread.ManagedThreadId);
            var task = RunHeavyMethodAsync1();
            Debug.Log("End of Press: A");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Press: P");
            Debug.Log($"Update()\tthread ID : " + Thread.CurrentThread.ManagedThreadId);
            var task = RunHeavyMethodParallel2();
            Debug.Log("End of Press: P");
        }
    }

    private void HeavyMethod(int x)
    {
        Debug.Log($"HeavyMethod()\tthread ID : " + Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(10 * (100 - x)); // てきとーに時間を潰す
        Debug.Log("\t\tthread ID: " + Thread.CurrentThread.ManagedThreadId + " " + x);
    }

    // 「HeavyMethodを順次実行する」という一つのタスク
    public async Task RunHeavyMethodAsync1()
    {
        for (var i = 0; i < 10; i++)
        {
            var x = i;
            await Task.Run(() => HeavyMethod(x)); // 「HeavyMethodを実行する」というタスクを開始し、完了するまで待機
        } // を、10回繰り返す
    } // というタスクを表す
    // ので、これは順次動作であり、並列ではない。

    public Task RunHeavyMethodParallel2() // asyncじゃないけど、戻り値がTask
    {
        var tasks = new List<Task>(); // TaskをまとめるListを作成
        for (var i = 0; i < 10; i++)
        {
            var x = i;
            var task = Task.Run(() => HeavyMethod(x)); // HeavyMethodを開始するというTask。並列。
            tasks.Add(task); // を、Listにまとめる
        }
        return Task.WhenAll(tasks); // 全てのTaskが完了した時に完了扱いになるたった一つのTaskを作成
    } // 非同期メソッドではないが、戻り値がTaskなので、このメソッドは一つのタスクを表しているといえる。
}
