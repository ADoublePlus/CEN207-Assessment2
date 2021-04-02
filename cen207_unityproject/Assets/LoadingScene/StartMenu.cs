using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("startBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Debug.Log("Click Start");
            Loader.Load(Loader.Scene.GameScene);
        };
    }
}