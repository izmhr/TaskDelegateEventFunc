// FuncとAction
// http://kan-kikuchi.hatenablog.com/entry/Delegate

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncAndActionRegister : MonoBehaviour
{
    public FuncAndAction funcAndAction;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            funcAndAction.Register(() =>
            {
                Debug.Log("Trigger Registerd Lambda");
            });
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            funcAndAction.Register2((string _str) =>
            {
                Debug.Log("Trigger Registerd Lambda 2 " + _str);
            });
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            // 超短縮版ラムダで書いてみた
            funcAndAction.Register3(_in => _in * _in);
            //funcAndAction.Register3((int _in) => { return _in * _in; });

            // Memo https://takamints.hatenablog.jp/entry/learning-a-lambda-expression-of-the-csharp
            //それまでは、ラムダ式単体で見て「型が明示されていないのに、どうコンパイルされて実行されているのだ？」
            //と不審に思っていました。 しかし、その、引数の数や型、戻り値の型など、欠落している情報は
            //一緒に使われている Action や Func、またはデリゲートで明示されているってことですね。
        }
    }
}
