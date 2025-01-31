using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMoverInfo : MonoBehaviour
{
    [Header(" ")]
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _requiredProximityToTargetPoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackDistance;

    [Header(" ")]
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private GroundDetector _groundDetector;

    public Enemy Enemy { get; private set; }

    public Transform[] Waypoints => _waypoints;
    public float RequiredProximityToTargetPoint => _requiredProximityToTargetPoint;
    public float SpeedMove => _moveSpeed;
    public float AttackDistance => _attackDistance;
    public GroundDetector GroundDetector => _groundDetector;

    public Player Target { get; private set; }

    private void Awake()
    {
        Enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _playerDetector.PlayerFound += SetPlayer;
        _playerDetector.PlayerLost += DeletePlayer;
    }

    private void OnDisable()
    {
        _playerDetector.PlayerFound -= SetPlayer;
        _playerDetector.PlayerLost -= DeletePlayer;
    }

    private void SetPlayer(Player player) => Target = player;

    private void DeletePlayer() => Target = null;
}