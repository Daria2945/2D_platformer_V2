using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Player))]
public class PlayerMoverInfo : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallSpeed;

    [Header("Detector")]
    [SerializeField] private GroundDetector _groundDetector;

    public Player Player { get; private set; }
    public InputReader InputReader { get; private set; }

    public float MoveSpeed => _moveSpeed;
    public float JumpForce => _jumpForce;
    public float FallSpeed => _fallSpeed;

    public GroundDetector GroundDetector => _groundDetector;

    public bool CanJump { get; private set; }

    private void Awake()
    {
        Player = GetComponent<Player>();
        InputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        CanJump = InputReader.CanJump() && GroundDetector.IsGrounded;
    }
}