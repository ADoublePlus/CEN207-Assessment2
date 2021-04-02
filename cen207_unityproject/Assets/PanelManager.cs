using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject yesButton;
    public GameObject noButton;

    public GameObject inputField;
    public bool QuestionOptions { get; set; }

    private void Start()
    {
        QuestionOptions = false;
        GameManager.GetInstance().OnUserInput += GameManager_OnUserInput;
    }

    public void SetTextOrChoice()
    {
        if (QuestionOptions)
        {
            yesButton.SetActive(true);
            noButton.SetActive(true);
            inputField.SetActive(false);
        }
        else
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            inputField.SetActive(true);
        }
    }
    private void GameManager_OnUserInput(object sender, System.EventArgs e)
    {
        Debug.Log("GameManager_OnUserInput");
        QuestionOptions = GameManager.GetInstance().GetQuestionOptions();
        SetTextOrChoice();
    }
}
