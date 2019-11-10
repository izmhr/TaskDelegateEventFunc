using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CountWhite : MonoBehaviour
{
    public RenderTexture rt;
    Texture2D tex;
    int w, h;
    int count = 0;
    public UnityEngine.UI.RawImage rawImage;
    Color[] texColors;
    Task task = null;

    // Taskをキャンセルする
    // http://light11.hatenadiary.com/entry/2019/03/06/002800
    //CancellationTokenSource tokenSource = new CancellationTokenSource();
    bool stopFlag = false;

    void Start()
    {
        w = rt.width;
        h = rt.height;
        tex = new Texture2D(w, h, TextureFormat.ARGB32, false);
    }

    void Update()
    {
        CopyTexture();
        GetPixels();

        if (Input.GetKeyDown(KeyCode.A))
        {
            task = CountWhiteTask();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(CountWhiteFunc());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            stopFlag = false;
            task = CountWhiteInfiniteTask();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //tokenSource.Cancel();
            stopFlag = true;
        }

        Debug.Log(count);
    }

    void CopyTexture()
    {
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        tex.Apply();
        rawImage.texture = tex;
    }

    void GetPixels()
    {
        texColors = tex.GetPixels();
    }

    int CountWhiteFunc()
    {
        int _c = 0;
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                int index = y * w + x;
                if (texColors[index] == Color.white) _c++;
            }
        }
        return _c;
    }

    async Task CountWhiteTask()
    {
        var start = Time.time;
        count = await Task.Run(() => CountWhiteFunc());
        var time = Time.time - start;
        Debug.Log(time);
    }

    async Task CountWhiteInfiniteTask()
    {
        while (true)
        {
            if (stopFlag) return;
            var start = Time.time;
            count = await Task.Run(() => CountWhiteFunc());
            var time = Time.time - start;
            Debug.Log(time);
        }
    }

    private void OnDestroy()
    {
        //tokenSource.Cancel();
        stopFlag = true;
    }
}
