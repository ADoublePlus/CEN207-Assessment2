using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject Panel;

    public GameObject _togglePanelOff;
    public GameObject _togglePanelOn;

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

            //yesButton.SetActive(false);
            //noButton.SetActive(false);

            //textInput.SetActive(false);
        }
    }
}