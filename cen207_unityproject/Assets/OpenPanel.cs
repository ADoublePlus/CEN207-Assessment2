using UnityEngine;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject Panel;
    public Button _button;

    public GameObject _togglePanelOff;
    public GameObject _togglePanelOn;

    public Text welcomeText;

    void Start()
    {
        PanelOpener();
    }

    public void PanelOpener()
    {
        bool isActive = Panel.activeSelf;
        if (Panel != null)
        {
            Panel.SetActive(!isActive);
        }
        if (Panel != isActive)
        {
            _togglePanelOff.SetActive(false);
            _togglePanelOn.SetActive(true);
        }
        else
        {
            _togglePanelOff.SetActive(true);
            _togglePanelOn.SetActive(false);
        }
    }

    // Error: Toggle takes extra input on Scene Load
}