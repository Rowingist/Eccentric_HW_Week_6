using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField, Range(0f, 50f)] private float _rotationSpeed = 4f;
    [SerializeField, Range(0f, 45f)] private float _rotationAngleRange = 45f;
    [SerializeField] private Aim _aim;

    private float _targetRotation = 0f;
    private Quaternion _newRotation = Quaternion.identity;
    private Vector3 _toAim;

    private void Update()
    {
        _toAim = _aim.transform.position - transform.position;

        _targetRotation = _toAim.x > 0f ? -_rotationAngleRange : _rotationAngleRange;
        RotateTo(_targetRotation);
    }

    private void RotateTo(float target)
    {
        _newRotation = Quaternion.Euler(0f, target, 0f);
        transform.rotation = Quaternion.Lerp(transform.localRotation, _newRotation, Time.deltaTime * _rotationSpeed);
    }
}