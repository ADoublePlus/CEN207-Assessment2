using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;

    public GameObject _buttonOff;
    public GameObject _buttonOn;

    public void PanelOpener()
    {
        bool isActive = Panel.activeSelf;
        if (Panel != null)
        {
            Panel.SetActive(!isActive);
        }
        if (Panel != isActive)
        {
            _buttonOff.SetActive(false);
            _buttonOn.SetActive(true);
        }
        else
        {
            _buttonOff.SetActive(true);
            _buttonOn.SetActive(false);
        }
    }
}