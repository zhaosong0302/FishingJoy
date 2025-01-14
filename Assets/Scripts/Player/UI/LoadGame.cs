using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;

public class LoadGame : MonoBehaviour {

    public Slider processView;

	// Use this for initialization
	void Start () {
        LoadGameMethod();
        
	}
	
	// Update is called once per frame
	void Update () {
		

    }
    public void LoadGameMethod()
    {
        StartCoroutine(LoadResourceCorotine());
        StartCoroutine(StartLoading_4(2));
    }

    private IEnumerator StartLoading_4(int scene)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene); 
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }

    IEnumerator LoadResourceCorotine()
    {
        UnityWebRequest request = UnityWebRequest.Get(@"http://localhost/fish.lua.txt");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        File.WriteAllText(@"D:\BaiduNetdiskDownload\XLua\File\XluaProjects\PlayerGamePackage\fish.lua.txt", str);
        UnityWebRequest request1 = UnityWebRequest.Get(@"http://localhost/fishDispose.lua.txt");
        yield return request1.SendWebRequest();
        string str1 = request1.downloadHandler.text;
        File.WriteAllText(@"D:\BaiduNetdiskDownload\XLua\File\XluaProjects\PlayerGamePackage\fishDispose.lua.txt", str1);
    }
    private void SetLoadingPercentage(float v)
    {
        processView.value = v / 100;
    }

   
}
