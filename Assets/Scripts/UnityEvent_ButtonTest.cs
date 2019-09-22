using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent_ButtonTest : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void MyAction()
    {
        Debug.Log("On Click");
    }

    public void MyIntAction(int _in)
    {
        Debug.Log(_in * _in);
    }
}
