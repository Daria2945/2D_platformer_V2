using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Item _prefab;

    private Item _item;

    public bool IsFreePoint => _item.IsActive == false;

    private void Awake()
    {
        _item = Instantiate(_prefab, transform);
    }

    public void ShowItem()
    {
        _item.Show();
    }
}