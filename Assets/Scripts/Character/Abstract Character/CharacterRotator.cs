using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField] private Transform _visual;

    private Rigidbody2D _rigidbody;
    private float _rotationAngle = 180f;

    bool _isFacingRight = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.x != 0)
        {
            if (_rigidbody.velocity.x < 0 && _isFacingRight)
            {
                Rotate();
                _isFacingRight = false;
            }
            else if (_rigidbody.velocity.x > 0 && _isFacingRight == false)
            {
                Rotate();
                _isFacingRight = true;
            }
        }
    }

    private void Rotate()
    {
        _visual.Rotate(0, _rotationAngle, 0);
    }
}