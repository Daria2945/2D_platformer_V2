using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _delay = 0.1f;
    [SerializeField] private float _detectorRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayerMask;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void OnEnable()
    {
        StartCoroutine(GetIsGrounded());
    }

    private bool CanFindGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _detectorRadius, _groundLayerMask);

        return hit != null && hit.TryGetComponent(out Ground _);
    }

    private IEnumerator GetIsGrounded()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _isGrounded = CanFindGround();

            yield return wait;
        }
    }
}