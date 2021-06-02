using UnityEngine;
using UnityEngine.UI;

public class ModalWindowWithHeader : ModalWindow
{
    [SerializeField] private Text header;

    public void SetHeader(string text)
    {
        header.text = text;
    }
}
