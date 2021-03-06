using UnityEngine;

public class EyesRotation : MonoBehaviour
{
    [SerializeField] private Aim _aim;
    [SerializeField, Range(10f, 50f)] private float _rotationAngleRange = 40f;

    private float _yAimOffset, _interpoler;
    private Quaternion _eyesUp, _eyesDown;

    private void Start()
    {
        SetYOffset();
    }

    private void Update()
    {
        SetYOffset();
        Rotate();
    }

    private void SetYOffset()
    {
        _yAimOffset = _aim.transform.position.y - transform.position.y;
    }

    private void Rotate()
    {
        _interpoler = Mathf.InverseLerp(-2f, 2f, _yAimOffset);
        _eyesUp = Quaternion.Euler(_rotationAngleRange, 0f, 0f);
        _eyesDown = Quaternion.Euler(-_rotationAngleRange, 0f, 0f);
        transform.localRotation = Quaternion.Lerp(_eyesUp, _eyesDown, _interpoler);
    }
}