using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RadiusView : MonoBehaviour
{
    private SpriteRenderer _alphaRadius;
    private Color _alphaValueActiveRadius = new(1f, 1f, 1f, 0.5f);
    private Color _alphaValueInactiveRadius = new(1f, 1f, 1f, 0f);

    private void Awake()
    {
        _alphaRadius = GetComponent<SpriteRenderer>();
        _alphaRadius.material.color = _alphaValueInactiveRadius;
    }

    public void Show() =>
        _alphaRadius.material.color = _alphaValueActiveRadius;

    public void Hide() =>
        _alphaRadius.material.color = _alphaValueInactiveRadius;
}