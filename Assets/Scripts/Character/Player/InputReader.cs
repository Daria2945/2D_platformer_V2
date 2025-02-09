using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode JupmKey = KeyCode.Space;
    private const KeyCode AttackKey = KeyCode.Q;

    private bool _isJump;
    private bool _canAttack;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(JupmKey))
            _isJump = true;

        if (Input.GetKeyDown(AttackKey))
            _canAttack = true;
    }

    public bool CanJump()
    {
        bool currentValue = _isJump;
        _isJump = false;

        return currentValue;
    }

    public bool CanAttack()
    {
        bool currentValue = _canAttack;
        _canAttack = false;

        return currentValue;
    }
}