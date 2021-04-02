using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUI : MonoBehaviour
{
    private void Awake()
    {
        transform.Find("backButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Debug.Log("Click Back Button");
            Loader.Load(Loader.Scene.MainMenu);
        };
    }
}