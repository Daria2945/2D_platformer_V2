using UnityEngine;

[RequireComponent(typeof(SmoothHealthBar))]
public class InitializerHealhtBar : MonoBehaviour
{
    [SerializeField] private Character _character;

    private SmoothHealthBar _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<SmoothHealthBar>();

        _character.InitializeHealth();
        _healthBar.Initialize(_character);
    }
}