using UnityEngine;
using UnityEngine.UI;

public class ModalWindow : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] protected Image window;

    protected virtual void Awake()
    {
        Hide();
    }

    public virtual void Hide() //mb anim in future
    {
        window.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    public virtual void ForceHide() //momental without anim
    {
        window.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        window.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
    }
}
