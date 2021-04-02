using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

    public event System.EventHandler OnUserInput;

    public string username;

    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    public Color userMessage, info;

    public PanelManager _panelManager;

    [SerializeField]
    List<Message> messageList = new List<Message>();
    private bool _questionOptions;

    void Awake()
    {
        // Set player instance on Awake()
        instance = this;
    }

    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(" Question: " + chatBox.text, Message.MessageType.userMessage);
                chatBox.text = chatBox.text.ToLower();
                // Profanity Check
                if (chatBox.text.Contains("fuck") || chatBox.text.Contains("ass") || chatBox.text.Contains("shit"))
                {
                    SendMessageToChat("Answer: I'm sorry but I can't help you if you are rude to me. Feel free to me ask another question, but without the profanity, please.", Message.MessageType.userMessage);
                    _questionOptions = false;
                }
                else if (chatBox.text.Contains("size") || chatBox.text.Contains("fit"))
                {
                    SendMessageToChat("Answer: Would you like to see the OneStop sizing guide?", Message.MessageType.userMessage);
                    _questionOptions = true;
                    OnUserInput?.Invoke(this, System.EventArgs.Empty);
                }
                else if (chatBox.text.Contains("colo")) // American 'Color' and Australian/British 'Colour'
                {
                    SendMessageToChat("Answer: The range of colours are black, blue, green, red, orange, yellow, pink and purple.", Message.MessageType.userMessage);
                    _questionOptions = false;
                }
                else if (chatBox.text.Contains("material") || chatBox.text.Contains("made"))
                {
                    SendMessageToChat("Answer: This product is made from 100% Cotton. Is there anything else I can help you with?", Message.MessageType.userMessage);
                    _questionOptions = false;
                }
                else if (chatBox.text.Contains("trust") || chatBox.text.Contains("rating"))
                {
                    SendMessageToChat("Answer: This seller has a OneStop Rating of 4.7/5. Would you like to submit a review?", Message.MessageType.userMessage);
                    _questionOptions = true;
                    OnUserInput?.Invoke(this, System.EventArgs.Empty);
                }
                else if ((chatBox.text.Contains("where") && chatBox.text.Contains("my")) || chatBox.text.Contains("when") || chatBox.text.Contains("delivery") || chatBox.text.Contains("track"))
                {
                    SendMessageToChat("Answer: OneStop Delivery Tracking is only available for OneStop account holders. Please contact the seller directly or would you like to sign up for free?", Message.MessageType.userMessage);
                    _questionOptions = true;
                    OnUserInput?.Invoke(this, System.EventArgs.Empty);
                }
                else if (chatBox.text.Contains("pay") || chatBox.text.Contains("check") || chatBox.text.Contains("buy"))
                {
                    SendMessageToChat("Answer: Receive 10% off your entire cart if you sign up today for free or you can use OneStop's quick and easy guest checkout.", Message.MessageType.userMessage);
                    _questionOptions = false;
                }
                else
                {
                    SendMessageToChat("Answer: Sorry, I'm a dumb sloth and I couldn't understand your question. Please try again.", Message.MessageType.userMessage);
                    _questionOptions = false;
                }
                // _panelManager.SetTextOrChoice();
                // SendMessageToChat(username + ": " + chatBox.text, Message.MessageType.userMessage);
                chatBox.text = "";
            }
        }
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed the space bar!", Message.MessageType.info);
                Debug.Log("Space");
            }
        }
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message
        {
            text = text
        };

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.userMessage:
                color = userMessage;
                break;
        }

        return color;
    }

    // Panel Manager needs access to the _questionOptions bool.
    public bool GetQuestionOptions()
    {
        if (_questionOptions)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        userMessage,
        info
    }
}