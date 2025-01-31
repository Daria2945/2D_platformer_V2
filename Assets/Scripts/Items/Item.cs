using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public bool IsActive { get; private set; }

    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        IsActive = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsActive = false;
        gameObject.SetActive(false);
    }
}